using System.Text.Json.Serialization;
using TP3FlappyBird.Models;

namespace FlappyBirdTP3.Models
{
    public class ScoreDTO
    {
        public int Id { get; set; }

        public int ScoreValue { get; set; }

        public decimal TimeInSeconds { get; set; }

        public DateTime? Date { get; set; }

        public bool Visible { get; set; } = true;

        public string Pseudo { get; set; } = null!;
    }
}
