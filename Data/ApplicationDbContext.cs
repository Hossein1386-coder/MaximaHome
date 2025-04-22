using Microsoft.EntityFrameworkCore;
using MaximaHome.Models;

namespace MaximaHome.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // تنظیمات پیش‌فرض برای جدول Users
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            // ایجاد کاربر ادمین پیش‌فرض
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    Password = BCrypt.Net.BCrypt.HashPassword("Maxima@1403"),
                    FullName = "مدیر سیستم",
                    PhoneNumber = "09123456789",
                    Role = "Admin",
                    CreatedAt = DateTime.Now
                }
            );
        }
    }
} 