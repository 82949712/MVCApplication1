using System.Data.Entity;
using Core.Entity_Models;

namespace CodeFirstFromDB
{
    public partial class StudentEntity : DbContext
    {
        public StudentEntity()
            : base("name=StudentEntity")
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Enrolment> Enrolments { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasMany(e => e.Enrolments)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Enrolments)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);
        }
    }
}
