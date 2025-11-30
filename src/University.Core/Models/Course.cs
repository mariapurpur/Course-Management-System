using System.Collections.Generic;


namespace University.Core.Models
{
    public abstract class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Teacher? Teacher { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();

        public Course(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}