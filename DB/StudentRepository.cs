using System.Collections.Generic;
using System.Linq;

namespace DB
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int studentId);
    }

    public class StudentRepository : IStudentRepository
    {
        public IEnumerable<Student> GetAllStudents()
        {
            IEnumerable<Student> students;
            using (var context = new StudentsEntity())
            {
                students = context.Students.ToList();
            }
            return students;
        }

        public Student GetStudentById(int studentId)
        {
            Student student;
            using (var context = new StudentsEntity())
            {
                student = context.Students.Find(studentId);
            }
            return student;
        }
    }
}
