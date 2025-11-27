using System;
using System.Collections.Generic;

namespace University.Core.Models
{
    public class OnlineCourse : Course
    {
        public string Platform { get; set; }
        public string Link { get; set; }

        // конструктор
        public OnlineCourse(int id, string title, string platform, string link) : base(id, title)
        {
            Platform = platform;
            Link = link;
        }
    }
}