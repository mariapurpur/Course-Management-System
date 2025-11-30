using System;
using System.Collections.Generic;
using System.Linq;
using University.Core.Models;

namespace University.Core.Services
{
    public class StudentService
    {
        private List<Student> _students = new List<Student>();

        public void AddStudent(Student student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));

            _students.Add(student);
        }

        public void RemoveStudent(int studentId)
        {
            if (studentId <= 100000)
                throw new ArgumentException("id должен соответствовать нормам ИСУ ИТМО :(", nameof(studentId));

            var studentToRemove = _students.FirstOrDefault(s => s.Id == studentId);
            if (studentToRemove != null)
            {
                _students.Remove(studentToRemove);
            }
        }

        public Student? GetStudent(int studentId)
        {
            if (studentId <= 100000)
                throw new ArgumentException("id должен соответствовать нормам ИСУ ИТМО :(", nameof(studentId));

            return _students.FirstOrDefault(s => s.Id == studentId);
        }

        public List<Student> GetAllStudents()
        {
            return _students.ToList();
        }
    }
}