using Microsoft.EntityFrameworkCore;

namespace demo1.Models
{
    public class ITIStudentContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<DepartmentNames> DepartmentNames { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ITIStudent; Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
