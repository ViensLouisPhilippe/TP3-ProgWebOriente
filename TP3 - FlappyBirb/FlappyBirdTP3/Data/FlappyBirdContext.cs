using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TP3FlappyBird.Models;

namespace TP3FlappyBird.Data
{
    public class FlappyBirdContext : IdentityDbContext<User>
    {
        public FlappyBirdContext(DbContextOptions<FlappyBirdContext> options) 
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            PasswordHasher<User> hasher = new PasswordHasher<User>();
            User user1 = new User
            {
                Id = "11111111-1111-1111-1111-111111111111",
                UserName = "Test",
                Email = "test@test.com",
                NormalizedEmail = "TEST@TEST.COM",
                NormalizedUserName = "TEST",
                
            };
            user1.PasswordHash = hasher.HashPassword(user1, "test123");
            builder.Entity<User>().HasData(user1);

            User user2 = new User
            {
                Id = "22222222-2222-2222-2222-222222222222",
                UserName = "Maxime",
                Email = "maxime@cegepmontpetit.ca",
                NormalizedEmail = "MAXIME@CEGEPMONTPETIT.CA",
                NormalizedUserName = "MAXIME",

            };
            user1.PasswordHash = hasher.HashPassword(user1, "admin1");
            builder.Entity<User>().HasData(user2);

            builder.Entity<User>().HasData(new
            {
                Id = 1,
                ScoreValue = 1,
                TimeInSeconds = 2.13,
                Date = DateTime.Now,
                IsPublic = true,
                UserId = "11111111-1111-1111-1111-111111111111"
            });
            builder.Entity<User>().HasData(new
            {
                Id = 2,
                ScoreValue = 15,
                TimeInSeconds = 23.50,
                Date = DateTime.Now,
                IsPublic = false,
                UserId = "11111111-1111-1111-1111-111111111111"
            });
            builder.Entity<User>().HasData(new
            {
                Id = 3,
                ScoreValue = 4,
                TimeInSeconds = 5.34,
                Date = DateTime.Now,
                IsPublic = true,
                UserId = "22222222-2222-2222-2222-222222222222"
            });
            builder.Entity<User>().HasData(new
            {
                Id = 4,
                ScoreValue = 7,
                TimeInSeconds = 11.23,
                Date = DateTime.Now,
                IsPublic = false,
                UserId = "22222222-2222-2222-2222-222222222222"
            });
        }

        public DbSet<TP3FlappyBird.Models.Score> Score { get; set; } = default!;
    }
}
