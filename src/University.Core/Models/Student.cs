using System;


namespace University.Core.Models
{
    public class Student
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public byte Year { get; set; }
        public string Specialization { get; set; }

        public Student(uint id, string name, byte year, string specialization)
        {
            Id = id;
            Name = name;
            Year = year;
            Specialization = specialization;
        }
    }
}