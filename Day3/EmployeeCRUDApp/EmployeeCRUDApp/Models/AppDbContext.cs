using Microsoft.EntityFrameworkCore;
using EmployeeCRUDApp.Models;  

namespace EmployeeCRUDApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }  
    }
}
