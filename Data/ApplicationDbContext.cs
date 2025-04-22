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
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // تنظیمات پیش‌فرض برای جدول Users
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            // تنظیمات پیش‌فرض برای جدول Bookings
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany()
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);

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