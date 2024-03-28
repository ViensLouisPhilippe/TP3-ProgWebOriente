using System.ComponentModel.DataAnnotations;

namespace TP3FlappyBird.Models
{
    public class LoginDTO
    {
        [Required]
        public String username { get; set; } = null!;

        [Required]
        public String Password { get; set; } = null!;
    }
}
