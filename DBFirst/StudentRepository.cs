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

        public List<Student> GetStudentCourses(int studentId)
        {
            var context = new Entities();
            var result = context.sp_get_students_courses(studentId);
         

            var student = result.GroupBy(x => new {StudentId = x.StudentId, Name = x.Name}).Select(g => new Student(){
                StudentId = g.Key.StudentId,
                Name = g.Key.Name,
                Enrolments = g.Select(x => new Enrolment(){EnrolmentId = x.EnrolmentId, CourseId = x.CourseId}).ToList()
            });

            return student.ToList();
        }
    }
}
