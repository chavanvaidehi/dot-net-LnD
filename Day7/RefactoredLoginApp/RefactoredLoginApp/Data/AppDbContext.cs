using Microsoft.EntityFrameworkCore;
using RefactoredLoginApp.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace RefactoredLoginApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", Password = "1234" }
            );
        }
    }
}
