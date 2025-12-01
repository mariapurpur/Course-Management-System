using System.Collections.Generic;
using University.Core.Models;

namespace University.Core.Interfaces
{
    public interface ITeacherService
    {
        void AddTeacher(Teacher teacher);
        void RemoveTeacher(uint teacherId);
        Teacher GetTeacher(uint teacherId);
        List<Teacher> GetAllTeachers();
    }
}