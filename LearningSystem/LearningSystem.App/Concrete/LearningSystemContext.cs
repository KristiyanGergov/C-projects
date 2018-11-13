using LearningSystem.Domain.Entity;
using System.Data.Entity;

namespace LearningSystem.App.Concrete
{
    public class LearningSystemContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Login> Logins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasMany(student => student.Courses).WithMany(course => course.Students);
        }
    }
}