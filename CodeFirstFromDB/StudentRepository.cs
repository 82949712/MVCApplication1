using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Entity_Models;

namespace CodeFirstFromDB
{
    public class StudentRepository : IStudentRepository
    {
        public IEnumerable<Student> GetAllStudents()
        {
            IEnumerable<Student> students;
            using (var context = new StudentEntity())
            {
                students = context.Students.ToList();
            }
            return students;
        }

        public Student GetStudentById(int studentId)
        {
            Student student;
            using (var context = new StudentEntity())
            {
                student = context.Students.Find(studentId);
            }
            return student;
        }

        public void UpdateStudentSp(int studentId, string name)
        {
            using (var context = new StudentEntity())
            {
                //var student = new Student() {StudentId = studentId, Name = name};
                //context.Students.Attach(student);
                //context.Entry(student).State = EntityState.Modified;
                //context.SaveChanges();

                //Use stored procedure
                context.Database.ExecuteSqlCommand("exec sp_update_student_name @Name, @Id",
                    new SqlParameter("@Name", name),
                    new SqlParameter("@Id", studentId));

            }
        }

        //public List GetStudentCourses(int studentId)
        //{
        //    using (var context = new StudentEntity())
        //    {
        //        var result = context.Database.SqlQuery<>("sp_get_students_courses", studentId);
        //        return result.ToList();
        //    }
        //}
    }
}
