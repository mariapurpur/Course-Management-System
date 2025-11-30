using System.Collections.Generic;
using University.Core.Models;

namespace University.Core.Interfaces
{
    public interface ICourseService
    {
        void AddCourse(Course course);
        void RemoveCourse(int courseId);
        void AssignTeacher(int courseId, Teacher teacher);
        void EnrollStudent(int courseId, Student student);
        List<Course> GetCoursesByTeacher(int teacherId);
    }
}