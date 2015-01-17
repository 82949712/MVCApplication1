using System.Data.Entity;

namespace DB
{
    public class StudentsEntity : DbContext
    {
        public StudentsEntity()
            : base("DefaultConnection")
        {
            
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrolment> Enrolments { get; set; }
    }
}