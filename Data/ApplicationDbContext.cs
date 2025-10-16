using StudentManagement.Models;
using Microsoft.EntityFrameworkCore;


namespace StudentManagement.Data {
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Student> Students { get; set; }
    }
}