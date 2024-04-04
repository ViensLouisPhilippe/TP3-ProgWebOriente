using Microsoft.AspNetCore.Identity;

namespace TP3FlappyBird.Models
{
    public class User : IdentityUser
    {
        public virtual List<Score> Scores { get; set; } = null!;
    }
}
