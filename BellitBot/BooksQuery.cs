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
        [Template(TemplateUsage.NotUnderstood, "Пожалуйста, повторите ввод")]
        [Template(TemplateUsage.EnumSelectOne, "Якім кнігам вы аддаеце перавагу? {||}", ChoiceStyle = ChoiceStyleOptions.Auto)]
        public Question1? Q1;
        // Answers
        [Serializable]
        public enum Question1
        {
            [Terms("Першая")]
            [Describe("Першая")]
            [BooksAttribute(new string[] { "Дагератып", "Зваротная перспектыва", "Быў у пана верабейка гаварушчы" })]
            one,
            [Terms("Другая")]
            [Describe("Другая")]
            [BooksAttribute(new string[] { "Быў у пана верабейка гаварушчы", "Белая муха, забойца мужчын", "Таўсьціла і лешч" })]
            two,
            [Terms("Трэцяя")]
            [Describe("Трэцяя")]
            [BooksAttribute(new string[] { "Белая муха, забойца мужчын", "Дагератып" })]
            three
        }

        // Question 2
        [Template(TemplateUsage.EnumSelectOne, "Якая з гэтых цытат характэрызуе вашае жыццё? {||}", ChoiceStyle = ChoiceStyleOptions.Auto)]
        public Question2? Q2;
        // Answers
        [Serializable]
        public enum Question2
        {
            [Terms("Я мужчина")]
            [Describe("Я мужчина")]
            [BooksAttribute(new string[] { "Дагератып", "Зваротная перспектыва" })]
            one,
            [Terms("Я женщина")]
            [Describe("Я женщина")]
            [BooksAttribute(new string[] { "Быў у пана верабейка гаварушчы", "Белая муха, забойца мужчын" })]
            two
        }

        // Question 3
        [Template(TemplateUsage.EnumSelectOne, "Куды б вы паехалі на адпачынак? {||}", ChoiceStyle = ChoiceStyleOptions.Auto)]
        public Question3? Q3;
        // Answers
        [Serializable]
        public enum Question3
        {
            [Terms("Браслаўскія азёры")]
            [Describe("Браслаўскія азёры")]
            [BooksAttribute(new string[] { "Быў у пана верабейка гаварушчы", "Белая муха, забойца мужчын" })]
            one,
            [Terms("Грэцыя")]
            [Describe("Грэцыя")]
            [BooksAttribute(new string[] { "Быў у пана верабейка гаварушчы", "Белая муха, забойца мужчын" })]
            two,
            [Terms("Нямеччына")]
            [Describe("Нямеччына")]
            [BooksAttribute(new string[] { "Быў у пана верабейка гаварушчы", "Белая муха, забойца мужчын" })]
            three,
            [Terms("Грэнландыя")]
            [Describe("Грэнландыя")]
            [BooksAttribute(new string[] { "Быў у пана верабейка гаварушчы", "Белая муха, забойца мужчын" })]
            four,
            [Terms("Застануся дома")]
            [Describe("Застануся дома")]
            [BooksAttribute(new string[] { "Быў у пана верабейка гаварушчы", "Белая муха, забойца мужчын" })]
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