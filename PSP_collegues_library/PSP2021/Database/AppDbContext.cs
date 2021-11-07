using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "TestName1",
                    Surname = "TestSurame1",
                    PhoneNumber = "+37061111111",
                    Email = "TestEmail1@gmail.com",
                    Address = "TestADress1",
                    Password = "TestPassword1."

                },
                new User
                {
                    Id = 2,
                    Name = "TestName2",
                    Surname = "TestSurame2",
                    PhoneNumber = "+37062222222",
                    Email = "TestEmail2@gmail.com",
                    Address = "TestADress2",
                    Password = "TestPassword2."

                },
                new User
                {
                    Id = 3,
                    Name = "TestName3",
                    Surname = "TestSurame3",
                    PhoneNumber = "+37063333333",
                    Email = "TestEmail3@gmail.com",
                    Address = "TestADress3",
                    Password = "TestPassword3."

                }
            );
        }
    }
}
