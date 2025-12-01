using System;


namespace University.Core.Models
{
    public class Teacher
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Teacher(uint id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
    }
}