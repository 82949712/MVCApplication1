using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Core
{
    public class StudentCourse
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }

        public virtual ICollection<EnrolledCourse> Courses { get; set; }
    }


    public class EnrolledCourse
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }
}
