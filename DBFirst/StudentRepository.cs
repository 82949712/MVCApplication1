using System.Collections.Generic;
using System.Linq;

namespace DBFirst
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int studentId);
        void UpdateStudentSp(int studentId, string name);
    }

    public class StudentRepository : IStudentRepository
    {
        public IEnumerable<Student> GetAllStudents()
        {
            IEnumerable<Student> students;
            using (var context = new Entities())
            {
                students = context.Students.ToList();
            }
            return students;
        }

        public Student GetStudentById(int studentId)
        {
            Student student;
            using (var context = new Entities())
            {
                student = context.Students.Find(studentId);
            }
            return student;
        }

        public void UpdateStudentSp(int studentId, string name)
        {
            using (var context = new Entities())
            {
                context.sp_update_student_name(name, studentId);
            }
        }
    }
}
