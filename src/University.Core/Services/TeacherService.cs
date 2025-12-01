using System;
using System.Collections.Generic;
using System.Linq;
using University.Core.Interfaces;
using University.Core.Models;

namespace University.Core.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly List<Teacher> _teachers = new List<Teacher>();

        public void AddTeacher(Teacher teacher)
        {
            if (teacher == null)
                throw new ArgumentNullException(nameof(teacher));

            _teachers.Add(teacher);
        }

        public void RemoveTeacher(uint teacherId)
        {
            if (teacherId <= 100000 || teacherId >= 999999)
                throw new ArgumentException("id должен соответствовать нормам ИСУ ИТМО :(", nameof(teacherId));

            var teacherToRemove = _teachers.FirstOrDefault(t => t.Id == teacherId);
            if (teacherToRemove != null)
            {
                _teachers.Remove(teacherToRemove);
            }
        }

        public Teacher GetTeacher(uint teacherId)
        {
            if (teacherId <= 100000 || teacherId >= 999999)
                throw new ArgumentException("id должен соответствовать нормам ИСУ ИТМО :(", nameof(teacherId));

            var teacher = _teachers.FirstOrDefault(t => t.Id == teacherId);
            if (teacher != null)
            {
                return teacher;
            }

            throw new ArgumentException("такого учителя не нашлось, точно правильно указан id?", nameof(teacherId));
        }

        public List<Teacher> GetAllTeachers()
        {
            return _teachers.ToList();
        }
    }
}