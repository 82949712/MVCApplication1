using System.Collections.Generic;
using Core.Entity_Models;

namespace Core
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int studentId);
        void UpdateStudentSp(int studentId, string name);
    }

    
}
