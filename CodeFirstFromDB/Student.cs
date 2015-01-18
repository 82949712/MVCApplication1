namespace CodeFirstFromDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
