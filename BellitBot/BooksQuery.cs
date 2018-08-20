using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BellitBot
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using Microsoft.Bot.Builder.FormFlow;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    //using static System.Net.Mime.MediaTypeNames;

    [Serializable]
    public class BooksQuery
    {
        // Question 1
        [Template(TemplateUsage.NotUnderstood, "Калі ласка, паўтарыце ўвод")]
        [Template(TemplateUsage.EnumSelectOne, "Напачатку - якія ў Вас стасункі з літаратурай? {||}", ChoiceStyle = ChoiceStyleOptions.Auto)]
        public Question1? Q1;
        // Answers
        [Serializable]
        public enum Question1
        {
            [Terms("Чытаю шмат і штодзенна")]
            [Describe("Чытаю шмат і штодзенна")]
            [BooksAttribute(new string[] { "Сядзіба", "Сабакі Эўропы" })]
            one,
            [Terms("Не чытаў ўжо дауно")]
            [Describe("Не чытаў ўжо дауно")]
            [BooksAttribute(new string[] { "(В)ядомыя гісторыі" })]
            two,
            [Terms("Чытаю толькі прафесійную літаратуру")]
            [Describe("Чытаю толькі прафесійную літаратуру")]
            [BooksAttribute(new string[] { "Між светам тым і гэтым", "Русалкі клічуць" })]
            three,
            [Terms("Чытаю рэдка, але метка")]
            [Describe("Чытаю рэдка, але метка")]
            [BooksAttribute(new string[] { "На заснежаны востраў" })]
            four
        }

        // Question 2
        [Template(TemplateUsage.EnumSelectOne, "Якім кнігам вы аддаеце перавагу? {||}", ChoiceStyle = ChoiceStyleOptions.Auto)]
        public Question2? Q2;
        // Answers
        [Serializable]
        public enum Question2
        {
            [Terms("Тым, дзе ўсё добра, потым дрэнна, а на прыканцы вяселле")]
            [Describe("Тым, дзе ўсё добра, потым дрэнна, а на прыканцы вяселле")]
            [BooksAttribute(new string[] { "(В)ядомыя гісторыі" })]
            one,
            [Terms("Тыя, у якіх жартаў больш, чым у шоу Петрасяна")]
            [Describe("Тыя, у якіх жартаў больш, чым у шоу Петрасяна")]
            [BooksAttribute(new string[] { "Між светам тым і гэтым" })]
            two,
            [Terms("Тыя, пасля якіх страшна спаць")]
            [Describe("Тыя, пасля якіх страшна спаць")]
            [BooksAttribute(new string[] { "Сядзіба" })]
            three,
            [Terms("Тыя, пасля якіх хочацца сумаваць")]
            [Describe("Тыя, пасля якіх хочацца сумаваць")]
            [BooksAttribute(new string[] { "На заснежаны востраў" })]
            four,
            [Terms("Тыя, цытаты з якіх можна паставіць у статус")]
            [Describe("Тыя, цытаты з якіх можна паставіць у статус")]
            [BooksAttribute(new string[] { "Русалкі клічуць", "Сабакі Эўропы" })]
            five
        }

        // Question 3
        [Template(TemplateUsage.EnumSelectOne, "Куды б вы паехалі на адпачынак? {||}", ChoiceStyle = ChoiceStyleOptions.Auto)]
        public Question3? Q3;
        // Answers
        [Serializable]
        public enum Question3
        {
            [Terms("У гістарычны Полацк")]
            [Describe("У гістарычны Полацк")]
            [BooksAttribute(new string[] { "Сядзіба" })]
            one,
            [Terms("Куды-небудзь у Еўропу")]
            [Describe("Куды-небудзь у Еўропу")]
            [BooksAttribute(new string[] { "На заснежаны востраў" })]
            two,
            [Terms("Да бабулі ў веску на блінцы")]
            [Describe("Да бабулі ў веску на блінцы")]
            [BooksAttribute(new string[] { "Русалкі клічуць" })]
            three,
            [Terms("У Турцыю, чакай мяне, ALL INCLUSIVE!")]
            [Describe("У Турцыю, чакай мяне, ALL INCLUSIVE!")]
            [BooksAttribute(new string[] { "Між светам тым і гэтым", "Сабакі Эўропы" })]
            four,
            [Terms("На Браславы")]
            [Describe("На Браславы")]
            [BooksAttribute(new string[] { "(В)ядомыя гісторыі" })]
            five
        }

        // Question 4        
        [Template(TemplateUsage.EnumSelectOne, "Ваш любімы беларускі прысмак? {||}", ChoiceStyle = ChoiceStyleOptions.Auto)]
        public Question4? Q4;
        // Answers
        [Serializable]
        public enum Question4
        {
            [Terms("Старка і дранікі")]
            [Describe("Старка і дранікі")]
            [BooksAttribute(new string[] { "На заснежаны востраў" })]
            one,
            [Terms("Шаўрма з манетачкі")]
            [Describe("Шаўрма з манетачкі")]
            [BooksAttribute(new string[] { "Сабакі Эўропы", "Між светам тым і гэтым" })]
            two,
            [Terms("Я беларускую ежу ўвогуле не ем. А навошта, калі ёсць паста карбанара?")]
            [Describe("Толькі гастрабары - магу сабе дазволіць!")]
            [BooksAttribute(new string[] { "Русалкі клічуць", "Сядзіба" })]
            three,
            [Terms("Матулін халаднік з яечкам!")]
            [Describe("Матулін халаднік з яечкам")]
            [BooksAttribute(new string[] { "(В)ядомыя гісторыі" })]
            four
        }

        // Question 5        
        [Template(TemplateUsage.EnumSelectOne, "Якую з гэтых карцінак Вы б абралі для авы на фэйсбуку? {||}", ChoiceStyle = ChoiceStyleOptions.Auto)]
        public Question5? Q5;
        // Answers
        [Serializable]
        public enum Question5
        {
            [Terms("1")]
            [Describe("1")]
            [BooksAttribute(new string[] { "На заснежаны востраў" })]
            one,
            [Terms("2")]
            [Describe("2")]
            [BooksAttribute(new string[] { "Між светам тым і гэтым" })]
            two,
            [Terms("3")]
            [Describe("3")]
            [BooksAttribute(new string[] { "Русалкі клічуць" })]
            three,
            [Terms("4")]
            [Describe("4")]
            [BooksAttribute(new string[] { "(В)ядомыя гісторыі" })]
            four,
            [Terms("5")]
            [Describe("5")]
            [BooksAttribute(new string[] { "Сабакі Эўропы" })]
            five,
            [Terms("6")]
            [Describe("6")]
            [BooksAttribute(new string[] { "Сядзіба" })]
            six
        }

        // Question 6        
        [Template(TemplateUsage.EnumSelectOne, "Зараз будзе скаладана. Якая з гэтых цытат характэрызуе Ваша жыццё? {||}", ChoiceStyle = ChoiceStyleOptions.Auto)]
        public Question6? Q6;
        // Answers
        [Serializable]
        public enum Question6
        {
            [Terms("Першая")]
            [Describe("Першая")]
            [BooksAttribute(new string[] { "На заснежаны востраў" })]
            one,
            [Terms("Другая")]
            [Describe("Другая")]
            [BooksAttribute(new string[] { "Між светам тым і гэтым" })]
            two,
            [Terms("Трэцяя")]
            [Describe("Трэцяя")]
            [BooksAttribute(new string[] { "Русалкі клічуць" })]
            three,
            [Terms("Чацвёртая")]
            [Describe("Чацвёртая")]
            [BooksAttribute(new string[] { "Сабакі Эўропы" })]
            four,
            [Terms("Пятая")]
            [Describe("Пятая")]
            [BooksAttribute(new string[] { "(В)ядомыя гісторыі" })]
            five,
            [Terms("Шостая")]
            [Describe("Шостая")]
            [BooksAttribute(new string[] { "Сядзіба" })]
            six
        }

        // Question 7        
        [Template(TemplateUsage.EnumSelectOne, "Уявім, што Вы жадаеце прачытаць пэўную кнігу. Куды вы за ёй пойдзеце? {||}", ChoiceStyle = ChoiceStyleOptions.Auto)]
        public Question7? Q7;
        // Answers
        [Serializable]
        public enum Question7
        {
            [Terms("У звычайную кнігарню")]
            [Describe("у звычайную кнігарню")]
            [BooksAttribute(new string[] { "Русалкі клічуць" })]
            one,
            [Terms("Да сяброў, у іх звычайна ўсё такое ёсць")]
            [Describe("Да сяброў, у іх звычайна ўсё такое ёсць")]
            [BooksAttribute(new string[] { "Сядзіба" })]
            two,
            [Terms("Спампую ў Інтэрнэце")]
            [Describe("Спампую ў Інтэрнэце")]
            [BooksAttribute(new string[] { "Між светам тым і гэтым" })]
            three,
            [Terms("Буду шукаць у перакупшчыкаў")]
            [Describe("Буду шукаць у перакупшчыкаў")]
            [BooksAttribute(new string[] { "Сабакі Эўропы" })]
            four,
            [Terms("Буду спадзявацца на моц букросігу")]
            [Describe("Буду спадзявацца на моц букросігу")]
            [BooksAttribute(new string[] { "На заснежаны востраў" })]
            five,
            [Terms("Ну, у бібліятэцы")]
            [Describe("Ну, у бібліятэцы")]
            [BooksAttribute(new string[] { "(В)ядомыя гісторыі" })]
            six
        }

        // Question 8        
        [Template(TemplateUsage.EnumSelectOne, "Ну Вы, канешне, цікавы суразмоўца! Распавядзеце нам, як Вы чытаеце? {||}", ChoiceStyle = ChoiceStyleOptions.Auto)]
        public Question8? Q8;
        // Answers
        [Serializable]
        public enum Question8
        {
            [Terms("Запоем")]
            [Describe("Запоем")]
            [BooksAttribute(new string[] { "На заснежаны востраў" })]
            one,
            [Terms("Абавязкова з кубачкам кавы у руцэ")]
            [Describe("Абавязкова з кубачкам кавы у руцэ")]
            [BooksAttribute(new string[] { "(В)ядомыя гісторыі" })]
            two,
            [Terms("Толькі у транспарце")]
            [Describe("Толькі у транспарце")]
            [BooksAttribute(new string[] { "Між светам тым і гэтым" })]
            three,
            [Terms("На працы")]
            [Describe("На працы")]
            [BooksAttribute(new string[] { "Сядзіба", "Русалкі клічуць" })]
            four,
            [Terms("Замест працы")]
            [Describe("Замест працы")]
            [BooksAttribute(new string[] { "Сабакі Эўропы" })]
            five
        }

        // Question 9        
        [Template(TemplateUsage.EnumSelectOne, "Аб набалелым: калі б Вы былі кіраўніком маленькага, але вельмі сумленнага народа, то Вы б?.. {||}", ChoiceStyle = ChoiceStyleOptions.Auto)]
        public Question9? Q9;
        // Answers
        [Serializable]
        public enum Question9
        {
            [Terms("Перадалі ўладу ў рукі пралетарыяту")]
            [Describe("Перадалі ўладу ў рукі пралетарыяту")]
            [BooksAttribute(new string[] { "На заснежаны востраў" })]
            one,
            [Terms("Заснавалі б абсалютную манархію")]
            [Describe("Заснавалі б абсалютную манархію")]
            [BooksAttribute(new string[] { "Між светам тым і гэтым" })]
            two,
            [Terms("Распрацавалі б канстытуцыю, якая б абмяжоўвала Вашыя ж правы")]
            [Describe("Распрацавалі б канстытуцыю, якая б абмяжоўвала Вашыя ж правы")]
            [BooksAttribute(new string[] { "Русалкі клічуць" })]
            three,
            [Terms("Перадалі свае паўнамоцтвы сыну мамінай сяброўкі")]
            [Describe("Перадалі свае паўнамоцтвы сыну мамінай сяброўкі")]
            [BooksAttribute(new string[] { "Сядзіба" })]
            four,
            [Terms("Усталявалі б матрыярхат і культ продкаў")]
            [Describe("Усталявалі б матрыярхат і культ продкаў")]
            [BooksAttribute(new string[] { "Сабакі Эўропы" })]
            five,
            [Terms("Афінская дэмакратыя - наш крок у будучыню!")]
            [Describe("Афінская дэмакратыя - наш крок у будучыню!")]
            [BooksAttribute(new string[] { "(В)ядомыя гісторыі" })]
            six
        }

        // Question 10        
        [Template(TemplateUsage.EnumSelectOne, "Апошняе пытанне. З якім чалавекам Вы б пайшлі і ў агонь, і ў ваду? {||}", ChoiceStyle = ChoiceStyleOptions.Auto)]
        public Question10? Q10;
        // Answers
        [Serializable]
        public enum Question10
        {
            [Terms("З тым, хто ўмее і жартаваць і гатаваць")]
            [Describe("З тым, хто ўмее і жартаваць і гатаваць")]
            [BooksAttribute(new string[] { "На заснежаны востраў" })]
            one,
            [Terms("З самым вопытным - карацей, з бывалым ваякам")]
            [Describe("З самым вопытным - карацей, з бывалым ваякам")]
            [BooksAttribute(new string[] { "Сядзіба", "Сабакі Эўропы" })]
            two,
            [Terms("З найбольш начытаным - бо з кім яшчэ паразмаўляеш на філасоўскія і жыццёвыя тэмы?")]
            [Describe("З найбольш начытаным - бо з кім яшчэ паразмаўляеш на філасоўскія і жыццёвыя тэмы?")]
            [BooksAttribute(new string[] { "Русалкі клічуць" })]
            three,
            [Terms("З тым, хто заўседы кажа толькі праўду і ніколі не схлусіць")]
            [Describe("З тым, хто заўседы кажа толькі праўду і ніколі не схлусіць")]
            [BooksAttribute(new string[] { "(В)ядомыя гісторыі" })]
            four,
            [Terms("З самым жывучым, які знойдзе выхад у любым выпадку і выйдзе сухім з вады")]
            [Describe("З самым жывучым, які знойдзе выхад у любым выпадку і выйдзе сухім з вады")]
            [BooksAttribute(new string[] { "Між светам тым і гэтым" })]
            five
        }

        /**
         * Here all questions should be specified.
         */
        public List<string[]> GetListNames()
        {
            List<string[]> list = new List<string[]>();

            list.Add(Q1.GetAttribute<BooksAttribute>().Names);
            list.Add(Q2.GetAttribute<BooksAttribute>().Names);
            list.Add(Q3.GetAttribute<BooksAttribute>().Names);

            return list;
        }

        /**
         * Load Books list from JSON.
         */
        public static List<Book> GetBooksList()
        {

            StreamReader reader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("BellitBot.Resources.Books.json"));
            string json = reader.ReadToEnd();

            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(json);

            return books;
        }
    }

    public static class EnumExtensions
    {
        public static TAttribute GetAttribute<TAttribute>(this Enum value)
            where TAttribute : Attribute
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            return type.GetField(name)
                .GetCustomAttributes(false)
                .OfType<TAttribute>()
                .SingleOrDefault();
        }
    }

    public class BooksAttribute : Attribute
    {
        internal BooksAttribute(string[] names)
        {
            this.Names = names;
        }
        public string[] Names { get; private set; }
    }
}