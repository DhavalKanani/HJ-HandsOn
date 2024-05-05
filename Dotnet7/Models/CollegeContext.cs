using Microsoft.EntityFrameworkCore;
namespace Dotnet7.Models
{
    public class CollegeContext : DbContext
    {
        public CollegeContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    Name = "Dhaval Kanani",
                    Password = "password",
                    Email = "kananid44@gmail.com",
                    Role="user"
                },
                new Student
                {
                    Id = 2,
                    Name = "HJ Infotech",
                    Password = "admin",
                    Email = "info@hjinfotech.com",
                    Role = "admin"
                }
                ); ;
        }


    }
}
