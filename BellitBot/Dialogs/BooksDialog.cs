namespace BellitBot.Dialogs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web;
    using Microsoft.Bot.Builder.Dialogs;
    using Microsoft.Bot.Builder.FormFlow;
    using Microsoft.Bot.Connector;

    [Serializable]
    public class BooksDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            //await context.PostAsync("Добро пожаловать в поиск книг!");

            var booksFormDialog = FormDialog.FromForm(this.BuildBooksForm, FormOptions.PromptInStart);

            context.Call(booksFormDialog, this.ResumeAfterBooksFormDialog);
        }

        private IForm<BooksQuery> BuildBooksForm()
        {
            OnCompletionAsyncDelegate<BooksQuery> processBooksSearch = async (context, state) =>
            {
                await context.PostAsync($"Ищем книжки...");


                //await context.PostAsync($"Ok. Searching for Books in {state.Destination} from {state.CheckIn.ToString("MM/dd")} to {state.CheckIn.AddDays(state.Nights).ToString("MM/dd")}...");
            };

            return new FormBuilder<BooksQuery>()
                .Field(nameof(BooksQuery.Q1))
                .AddRemainingFields()
                //.Message("Ищем подходящие книги...")
                .OnCompletion(processBooksSearch)
                .Build();
        }

        private async Task ResumeAfterBooksFormDialog(IDialogContext context, IAwaitable<BooksQuery> result)
        {
            try
            {
                var searchQuery = await result;                
                var books = await this.GetBooksAsync(searchQuery);
                var book = books.First();

                await context.PostAsync($"Мы нашли для Вас подходящую книгу:");

                var resultMessage = context.MakeMessage();
                resultMessage.AttachmentLayout = AttachmentLayoutTypes.Carousel;
                resultMessage.Attachments = new List<Attachment>();

                // Create a hero card.
                HeroCard heroCard = new HeroCard()
                {
                    Title = book.Name,
                    Subtitle = book.Author,
                    Images = new List<CardImage>()
                    {
                        new CardImage() { Url = book.Cover }
                    },
                    Buttons = new List<CardAction>()
                    {
                        new CardAction()
                        {
                            Title = "Яшчэ раз",
                            Type = ActionTypes.PostBack,
                            Value = "Хачу яшчэ"
                        }
                    }
                    //Buttons = new List<CardAction>()
                    //{
                    //    new CardAction()
                    //    {
                    //        Title = "More details",
                    //        Type = ActionTypes.OpenUrl,
                    //        Value = $"https://www.bing.com/search?q=books+in+" + HttpUtility.UrlEncode(book.Author)
                    //    }
                    //}
                };

                resultMessage.Attachments.Add(heroCard.ToAttachment());

                await context.PostAsync(resultMessage);
            }
            catch (FormCanceledException ex)
            {
                string reply;

                if (ex.InnerException == null)
                {
                    reply = "You have canceled the operation. Quitting from the BooksDialog";
                }
                else
                {
                    reply = $"Oops! Something went wrong :( Technical Details: {ex.InnerException.Message}";
                }

                await context.PostAsync(reply);
            }
            finally
            {
                context.Done<object>(null);
            }
        }

        private async Task<IEnumerable<Book>> GetBooksAsync(BooksQuery searchQuery)
        {
            var books = BooksQuery.GetBooksList();

            var list = searchQuery.GetListNames();
            books = FillBooksSelectedTimes(books, list);

            books.Sort((h1, h2) => h2.SelectedTimes.CompareTo(h1.SelectedTimes));

            return books;
        }

        /**
         * Counts books and fills in the SelectedTimes property.
         */
        List<Book> FillBooksSelectedTimes(List<Book> books, List<string[]> answersList)
        {
            List<Book> returnBooks = new List<Book>();

            foreach (string[] answerList in answersList)
            {
                foreach (Book book in books)
                {
                    foreach (string bookName in answerList)
                    {
                        if (book.Name == bookName)
                        {
                            book.SelectedTimes++;
                        }
                    }
                    returnBooks.Add(book);
                }

            }
            return books;
        }
    }
}
 