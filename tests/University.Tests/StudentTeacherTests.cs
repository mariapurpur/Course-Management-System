using System;
using Xunit;
using University.Core.Models;

namespace University.Tests
{
    public class StudentTeacherTests
    {
        [Fact]
        public void StudentConstructor_Correct()
        {
            int id = 123456;
            string name = "Мильнюсов Зореслав Добрыниевич";
            byte year = 3;
            string specialization = "Языковые модели и искусственный интеллект";

            var student = new Student(id, name, year, specialization);

            Assert.Equal(id, student.Id);
            Assert.Equal(name, student.Name);
            Assert.Equal(year, student.Year);
            Assert.Equal(specialization, student.Specialization);
        }

        [Fact]
        public void StudentProperties_Correct()
        {
            var student = new Student(135795, "Мошкин Тузик Аркадиевич", 1, "преподаватель");

            Assert.Equal(135795, student.Id);
            Assert.Equal("Мошкин Тузик Аркадиевич", student.Name);
            Assert.Equal((byte)1, student.Year);
            Assert.Equal("преподаватель", student.Specialization);

            student.Name = "НоваяФамилия НовоеИмя НовоеОтчество";
            student.Year = 4;
            student.Specialization = "очередная специальность";

            Assert.Equal("НоваяФамилия НовоеИмя НовоеОтчество", student.Name);
            Assert.Equal((byte)4, student.Year);
            Assert.Equal("очередная специальность", student.Specialization);
        }

        [Fact]
        public void TeacherConstructor_Correct()
        {
            int id = 929193;
            string name = "Тоти Алессандро";
            string email = "alestoti@itmo.ru";

            var teacher = new Teacher(id, name, email);

            Assert.Equal(id, teacher.Id);
            Assert.Equal(name, teacher.Name);
            Assert.Equal(email, teacher.Email);
        }

        [Fact]
        public void TeacherProperties_Correct()
        {
            var teacher = new Teacher(101010, "Хихи Хаха Хихиковна", "hihihaha@itmo.ru");

            Assert.Equal(101010, teacher.Id);
            Assert.Equal("Хихи Хаха Хихиковна", teacher.Name);
            Assert.Equal("hihihaha@itmo.ru", teacher.Email);

            teacher.Name = "Хохо Хехе Хохокович";
            teacher.Email = "hohohehe@itmo.ru";

            Assert.Equal("Хохо Хехе Хохокович", teacher.Name);
            Assert.Equal("hohohehe@itmo.ru", teacher.Email);
        }
    }
}