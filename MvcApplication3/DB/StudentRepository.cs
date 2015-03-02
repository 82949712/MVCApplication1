using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Core;

namespace DB
{
    public class StudentRepository : IStudentRepository
    {
        public IEnumerable<StudentCourse> GetStudentCourses(int studentId)
        {
            using (var context = new StudentDBEntities())
            {
                var spResult = context.sp_get_students_courses(studentId);
                var result = spResult.ToList().GroupBy(x => new { x.StudentId, x.Name })
                    .Select(s => new StudentCourse()
                    {
                        StudentId = s.Key.StudentId,
                        StudentName = s.Key.Name,
                        Courses = s.Select(x => new EnrolledCourse() { CourseId = x.CourseId, CourseName = x.CourseName }).ToList()
                    });
                return result.ToList();
            }
        }

        public IEnumerable<StudentCourse> GetStudents()
        {
            using (var context = new StudentDBEntities())
            {
                return context.Students.Select(s => new StudentCourse{StudentName = s.Name, StudentId = s.StudentId}).ToList();
            }
        } 
    }

    public class MockStudentRepository : IStudentRepository
    {
        public IEnumerable<StudentCourse> GetStudentCourses(int studentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentCourse> GetStudents()
        {
            return new List<StudentCourse>()
            {
                new StudentCourse() {StudentName = "Jason", StudentId = 1},
                new StudentCourse() {StudentName = "Johnson", StudentId = 2},
                new StudentCourse() {StudentName = "Peter", StudentId = 3},
                new StudentCourse() {StudentName = "Abby", StudentId = 4}

            };
        }
    }
}
