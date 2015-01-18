using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity_Models
{
    [Table("Student")]
    public partial class Student
    {
        public Student()
        {
            Enrolments = new HashSet<Enrolment>();
        }

        public int StudentId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Enrolment> Enrolments { get; set; }
    }
}
