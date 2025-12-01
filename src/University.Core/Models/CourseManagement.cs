using System;
using System.Collections.Generic;
using System.Linq;

namespace University.Core.Models
{
    public class CourseManagement
    {
        // добаить студента на курс
        public void EnrollStudent(uint courseId, Student student)
        {
            var course = _courses.FirstOrDefault(c => c.Id == courseId);

            if (course == null)
            {
                throw new ArgumentException($"курса с id {courseId} не нашлось");
            }
            course.Students.Add(student);
        }

        // получить список курсов от конкретного препода
        public List<Course> GetCoursesByTeacher(uint teacherId)
        {
            return _courses
                .Where(c => c.Teacher != null && c.Teacher.Id == teacherId)
                .ToList();
        }

        // добавление курсов
        public void AddCourse(Course course)
        {
            _courses.Add(course);
        }


        // удаление курса по его id
        public void RemoveCourse(uint courseId)
        {
            var course = _courses.FirstOrDefault(c => c.Id == courseId);
            if (course != null)
            {
                _courses.Remove(course);
            }
        }


        // назначение преподавателя на курс по id курса
        public void AssignTeacher(uint courseId, Teacher teacher)
        {
            var course = _courses.FirstOrDefault(c => c.Id == courseId);
            if (course != null)
            {
                course.Teacher = teacher;
            }
        }
        private List<Course> _courses = new List<Course>();
    }
}