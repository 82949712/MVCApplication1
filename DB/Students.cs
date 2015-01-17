using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string StudentNumber { get; set; }

        public virtual ICollection<Course> Enrolments { get; set; }
    }

    public class Enrolment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnrolmentId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }

    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
