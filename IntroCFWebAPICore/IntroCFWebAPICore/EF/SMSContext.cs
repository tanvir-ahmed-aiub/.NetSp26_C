using IntroCFWebAPICore.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace IntroCFWebAPICore.EF
{
    public class SMSContext : DbContext
    {
        public SMSContext(DbContextOptions<SMSContext> options)
        :base(options) { }
       

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
