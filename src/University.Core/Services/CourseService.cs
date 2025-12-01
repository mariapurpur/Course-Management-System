using System;
using System.Collections.Generic;
using System.Linq;
using University.Core.Interfaces;
using University.Core.Models;

namespace University.Core.Services
{
    public class CourseService : ICourseService
    {
        private readonly List<Course> _courses = new List<Course>();

        public void AddCourse(Course course)
        {
            if (course == null)
                throw new ArgumentNullException(nameof(course));

            _courses.Add(course);
        }

        public void RemoveCourse(uint courseId)
        {
            var courseToRemove = _courses.FirstOrDefault(c => c.Id == courseId);
            if (courseToRemove != null)
            {
                _courses.Remove(courseToRemove);
            }
        }

        public void AssignTeacher(uint courseId, Teacher teacher)
        {
            if (teacher == null)
                throw new ArgumentNullException(nameof(teacher));

            var course = _courses.FirstOrDefault(c => c.Id == courseId);
            if (course != null)
            {
                course.Teacher = teacher;
            }
        }

        public void EnrollStudent(uint courseId, Student student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));

            var course = _courses.FirstOrDefault(c => c.Id == courseId);
            if (course == null)
                throw new ArgumentException("такого курса не нашлось, точно правильно указан id?");

            course.Students.Add(student);
        }

        public List<Course> GetCoursesByTeacher(uint teacherId)
        {
            if (teacherId <= 100000 || teacherId >= 999999)
                throw new ArgumentException("id должен соответствовать нормам ИСУ ИТМО :(", nameof(teacherId));

            return _courses
                .Where(c => c.Teacher != null && c.Teacher.Id == teacherId)
                .ToList();
        }
    }
}