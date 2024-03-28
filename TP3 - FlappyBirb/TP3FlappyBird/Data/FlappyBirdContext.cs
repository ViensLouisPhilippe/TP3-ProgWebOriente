using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TP3FlappyBird.Models;

namespace TP3FlappyBird.Data
{
    public class FlappyBirdContext : IdentityDbContext<User>
    {
        public FlappyBirdContext(DbContextOptions<FlappyBirdContext> options) 
            :base(options) { }


    }

    public DbSet<TP3FlappyBird.Models.Score> Score { get; set; } = default!;
}
