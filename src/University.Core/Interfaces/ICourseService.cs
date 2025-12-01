using System.Collections.Generic;
using University.Core.Models;

namespace University.Core.Interfaces
{
    public interface ICourseService
    {
        void AddCourse(Course course);
        void RemoveCourse(uint courseId);
        void AssignTeacher(uint courseId, Teacher teacher);
        void EnrollStudent(uint courseId, Student student);
        List<Course> GetCoursesByTeacher(uint teacherId);
    }
}