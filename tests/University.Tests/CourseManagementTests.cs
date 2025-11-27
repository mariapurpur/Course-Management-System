using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using University.Core.Models;

namespace University.Tests
{
    public class CourseManagementTests
    {
        private CourseManagement _management;
        private Teacher _teacher1;
        private Teacher _teacher2;
        private Student _student1;
        private Student _student2;
        private OnlineCourse _onlineCourse;
        private OfflineCourse _offlineCourse;

        public CourseManagementTests()
        {
            _management = new CourseManagement();

            _teacher1 = new Teacher(1, "Суханова М. В.", "sukhanova@gmail.com");
            _teacher2 = new Teacher(2, "Мошкина Г. К.", "moshka@gmail.com");
            _student1 = new Student(1, "Сидоров А. Б.", 2, "программирование");
            _student2 = new Student(2, "Козлова А. Б.", 3, "математический анализ");
            _onlineCourse = new OnlineCourse(1, "введение в c++", "Zoom", "https://zoom.us/");
            _offlineCourse = new OfflineCourse(2, "интегрирование функций", "ауд 205", "ПН/СР 10:00-12:00");
        }

        [Fact]
        public void AddCourse_Correct()
        {
            _management.AddCourse(_onlineCourse);

            _management.AssignTeacher(_onlineCourse.Id, _teacher1);
            var teacherCourses = _management.GetCoursesByTeacher(_teacher1.Id);

            Assert.Single(teacherCourses);
            Assert.Contains(teacherCourses, c => c.Id == _onlineCourse.Id);
        }

        [Fact]
        public void RemoveCourse_Correct()
        {
            _management.AddCourse(_offlineCourse);
            _management.AssignTeacher(_offlineCourse.Id, _teacher2);

            _management.RemoveCourse(_offlineCourse.Id);

            var teacherCourses = _management.GetCoursesByTeacher(_teacher2.Id);
            Assert.Empty(teacherCourses);
        }

        [Fact]
        public void AssignTeacher_Correct()
        {
            _management.AddCourse(_onlineCourse);

            _management.AssignTeacher(_onlineCourse.Id, _teacher1);

            Assert.Equal(_teacher1, _onlineCourse.Teacher);
        }

        [Fact]
        public void EnrollStudent_CorrectInput()
        {
            _management.AddCourse(_onlineCourse);

            _management.EnrollStudent(_onlineCourse.Id, _student1);

            Assert.Contains(_student1, _onlineCourse.Students);
        }

        [Fact]
        public void EnrollStudent_Correct()
        {
            Assert.Throws<ArgumentException>(() => _management.EnrollStudent(555554, _student1));
        }

        [Fact]
        public void GetCoursesByTeacher_CorrectInput()
        {
            var courseForTeacher1_1 = new OnlineCourse(2, "тестовый онлайн курс 1", "LMS", "https://lms...");
            var courseForTeacher1_2 = new OfflineCourse(3, "тестовый оффлайн курс", "ауд 301", "ЧТ 14:00-16:00");
            var courseForTeacher2 = new OnlineCourse(4, "тестовый онлайн курс 2", "Zoom", "https://zoom...");

            _management.AddCourse(courseForTeacher1_1);
            _management.AddCourse(courseForTeacher1_2);
            _management.AddCourse(courseForTeacher2);

            _management.AssignTeacher(courseForTeacher1_1.Id, _teacher1);
            _management.AssignTeacher(courseForTeacher1_2.Id, _teacher1);
            _management.AssignTeacher(courseForTeacher2.Id, _teacher2);

            var teacher1Courses = _management.GetCoursesByTeacher(_teacher1.Id);

            Assert.Equal(2, teacher1Courses.Count);
            Assert.Contains(teacher1Courses, c => c.Id == courseForTeacher1_1.Id);
            Assert.Contains(teacher1Courses, c => c.Id == courseForTeacher1_2.Id);
            Assert.DoesNotContain(teacher1Courses, c => c.Id == courseForTeacher2.Id);
        }

        [Fact]
        public void GetCoursesByTeacher_Correct()
        {
            var teacherCourses = _management.GetCoursesByTeacher(_teacher1.Id);

            Assert.Empty(teacherCourses);
        }
    }
}