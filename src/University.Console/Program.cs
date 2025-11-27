using System;
using University.Core.Models;


class Program
{
    static void Main(string[] args)
    {
        var teacher = new Teacher(351025, "Иванов Иван Иванович", "ivanivanivan@gmail.com");

        Console.WriteLine(teacher.Id);
        Console.WriteLine(teacher.Name);
        Console.WriteLine(teacher.Email);

        teacher.Name = "Петров Петр Петрович";
        Console.WriteLine($"Новое имя: {teacher.Name}");
    }
}