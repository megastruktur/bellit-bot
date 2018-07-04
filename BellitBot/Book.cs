using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BellitBot
{
    using System;

    [Serializable]
    public class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Cover { get; set; }
        public int Year { get; set; }
        public int Place { get; set; }
        public int SelectedTimes = 0;
    }
}