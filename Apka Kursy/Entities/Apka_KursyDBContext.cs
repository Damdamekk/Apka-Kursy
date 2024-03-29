﻿using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Apka_Kursy.Entities
{
    public class Apka_KursyDBContext : DbContext
    {
        private string _connectionString =
            "Server=";//add your server adress

        public DbSet<Users> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<CourseDate> CourseDate { get; set; }
        public DbSet<CoursesCategory> CoursesCategory { get; set; }
        public DbSet<ForumCategory> ForumCategory { get; set; }
        public DbSet<ForumPost> ForumPost { get; set; }
        public DbSet<Lesson> Lesson { get; set; }
        public DbSet<LessonVideo> LessonVideo { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Signup> Signup { get; set; }
        public DbSet<SignupMessage> SignupMessage { get; set; }
        public DbSet<BuyCourse> BuyCourse { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .Property(u => u.Email)
                .IsRequired();

            modelBuilder.Entity<Role>()
                .Property(u => u.Name)
                .IsRequired();
            modelBuilder.Entity<Role>()
                .HasData(
                new Role()
                {
                    Id = 1,
                    Name = "Admin"
                },
                new Role()
                {
                    Id = 2,
                    Name = "Kursant"
                },
                new Role()
                {
                    Id = 3,
                    Name = "Nauczyciel"
                }
                );
            modelBuilder.Entity<Course>()
                .Property(c => c.Price)
                .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<BuyCourse>()
                .Property(u => u.AmountPaid)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
