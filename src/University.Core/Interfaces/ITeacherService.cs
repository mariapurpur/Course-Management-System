using System.Collections.Generic;
using University.Core.Models;

namespace University.Core.Interfaces
{
    public interface ITeacherService
    {
        void AddTeacher(Teacher teacher);
        void RemoveTeacher(int teacherId);
        Teacher GetTeacher(int teacherId);
        List<Teacher> GetAllTeachers();
    }
}