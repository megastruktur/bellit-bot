using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BellitBot
{
    using System;
    using Microsoft.Bot.Builder.FormFlow;

    [Serializable]
    public class BooksQuery
    {
        [Template(TemplateUsage.NotUnderstood, "Пожалуйста, повторите ввод")]
        [Template(TemplateUsage.EnumSelectOne, "Ваш возраст {||}", ChoiceStyle = ChoiceStyleOptions.Auto)]
        public Question1? Age; // type: Enumeration

        [Template(TemplateUsage.EnumSelectOne, "Ваш пол {||}", ChoiceStyle = ChoiceStyleOptions.Auto)]
        public Question2? Gender; // type: Enumeration
        [Template(TemplateUsage.EnumSelectOne, "Еще кое-что {||}", ChoiceStyle = ChoiceStyleOptions.Auto)]
        public Question3? Something; // type: Enumeration


        [Serializable]
        public enum Question1
        {
            [Terms("18")]
            [Describe("18")]
            age18 = 1,
            [Terms("20")]
            [Describe("20")]
            age20 = 2,
            [Terms("30")]
            [Describe("30")]
            age30 = 3
        }

        [Serializable]
        public enum Question2
        {
            [Terms("Я мужчина")]
            [Describe("Я мужчина")]
            M = 4,
            [Terms("Я женщина")]
            [Describe("Я женщина")]
            F = 5
        }

        [Serializable]
        public enum Question3
        {
            [Terms("раз")]
            [Describe("раз")]
            One = 6,
            [Terms("два")]
            [Describe("два")]
            Two = 7,
            [Terms("три")]
            [Describe("три")]
            Three = 8
        }

        public static List<Book> GetBooksList()
        {
            var books = new List<Book>();

            books.Add(new Book()
            {
                Name = "Дагератып",
                Author = "Людміла Рублеўская",
                Cover = "https://pen-centre.by/img/2_rubleuskaja.jpg",
                SelectedTimes = 0
            });

            books.Add(new Book()
            {
                Name = "Белая муха, забойца мужчын",
                Author = "Альгерд Бахарэвіч",
                Cover = "http://gedroyc.by/img/2016/baharewicz160210-xxdwg.jpg",
                SelectedTimes = 0
            });

            books.Add(new Book()
            {
                Name = "Быў у пана верабейка гаварушчы",
                Author = "Зміцер Бартосік",
                Cover = "https://pen-centre.by/img/1_bartosik.png",
                SelectedTimes = 0
            });

            books.Add(new Book()
            {
                Name = "Таўсьціла і лешч",
                Author = "Андрэй Адамовіч",
                Cover = "http://gedroyc.by/img/2016/29-602778.jpg",
                SelectedTimes = 0
            });

            books.Add(new Book()
            {
                Name = "Зваротная перспектыва",
                Author = "Адам Глобус",
                Cover = "https://pen-centre.by/img/3_hlobus.jpg",
                SelectedTimes = 0
            });


            return books;
        }
        
        /**
         * Get answers and their book variants.
         */
        public static Dictionary<Enum, string[]> GetVariantsDictionary()
        {
            var dict = new Dictionary<Enum, string[]>();
            dict.Add(Question1.age18, new string[] { "Дагератып", "Зваротная перспектыва", "Быў у пана верабейка гаварушчы" });
            dict.Add(Question1.age20, new string[] { "Быў у пана верабейка гаварушчы", "Белая муха, забойца мужчын", "Таўсьціла і лешч" });
            dict.Add(Question1.age30, new string[] { "Белая муха, забойца мужчын", "Дагератып" });
            dict.Add(Question2.M, new string[] { "Дагератып", "Зваротная перспектыва" });
            dict.Add(Question2.F, new string[] { "Быў у пана верабейка гаварушчы", "Белая муха, забойца мужчын" });
            dict.Add(Question3.One, new string[] { "Быў у пана верабейка гаварушчы", "Белая муха, забойца мужчын" });
            dict.Add(Question3.Two, new string[] { "Быў у пана верабейка гаварушчы", "Белая муха, забойца мужчын" });
            dict.Add(Question3.Three, new string[] { "Быў у пана верабейка гаварушчы", "Белая муха, забойца мужчын" });
            return dict;
        }
    }
}