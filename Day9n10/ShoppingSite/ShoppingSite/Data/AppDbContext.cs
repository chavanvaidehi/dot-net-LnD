using Microsoft.EntityFrameworkCore;
using ShoppingSite.Models;

namespace ShoppingSite.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Bluetooth Speaker", Description = "Portable speaker with bass boost", Price = 1999, ImageUrl = "/images/speaker.jpg" },
                new Product { Id = 2, Name = "Smart Watch", Description = "Track fitness & notifications", Price = 3499, ImageUrl = "/images/watch.jpg" },
                new Product { Id = 3, Name = "Wireless Earbuds", Description = "Noise cancelling, water resistant", Price = 2999, ImageUrl = "/images/earbuds.jpg" },
                new Product { Id = 4, Name = "Laptop Bag", Description = "Water-resistant with USB port", Price = 1899, ImageUrl = "/images/bag.jpg" },
                new Product { Id = 5, Name = "Gaming Mouse", Description = "RGB lights and high DPI", Price = 1499, ImageUrl = "/images/mouse.jpg" },
                new Product { Id = 6, Name = "Fitness Band", Description = "Tracks steps and heart rate", Price = 1299, ImageUrl = "/images/band.jpg" },
                new Product { Id = 7, Name = "Power Bank", Description = "10000 mAh, fast charging", Price = 999, ImageUrl = "/images/powerbank.jpg" },
                new Product { Id = 8, Name = "Wireless Keyboard", Description = "Compact and rechargeable", Price = 1699, ImageUrl = "/images/keyboard.jpg" },
                new Product { Id = 9, Name = "Webcam HD", Description = "1080p webcam with mic", Price = 2099, ImageUrl = "/images/webcam.jpg" }
            );
        }

    }
}
