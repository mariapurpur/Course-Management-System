using System.Collections.Generic;


namespace University.Core.Models
{
    public abstract class Course
    {
        public uint Id { get; set; }
        public string Title { get; set; }
        public Teacher? Teacher { get; set; }
        public List<Student> Students { get; private set; } = new List<Student>();

        public Course(uint id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}