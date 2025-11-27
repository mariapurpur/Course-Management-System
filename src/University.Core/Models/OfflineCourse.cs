using System;
using System.Collections.Generic;

namespace University.Core.Models
{
    public class OfflineCourse : Course
    {
        public string Classroom { get; set; }
        public string Schedule { get; set; }

        // конструктор
        public OfflineCourse(int id, string title, string classroom, string schedule) : base(id, title)
        {
            Classroom = classroom;
            Schedule = schedule;
        }
    }
}