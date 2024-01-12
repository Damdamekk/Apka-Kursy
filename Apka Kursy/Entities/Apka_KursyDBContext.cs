using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Apka_Kursy.Entities
{
    public class Apka_KursyDBContext : DbContext
    {
        private string _connectionString =
            "Server=tcp:apkakursydbserver.database.windows.net,1433;Initial Catalog=Apka_Kursy_db2;Persist Security Info=False;User ID=Admin1;Password=Silnehaslo123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public DbSet<Users> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Image> Images { get; set; }

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
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
