﻿namespace TP3FlappyBird.Models
{
    public class Score
    {
        public int Id { get; set; }

        public int ScoreValue { get; set; }

        public decimal Temps { get; set; }

        public DateTime Date { get; set; }

        public bool Visible { get; set; } = true;

        public virtual User? User { get; set; }
    }
}