using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TP3FlappyBird.Models;

namespace TP3FlappyBird.Data
{
    public class ScoreService
    {
        protected readonly FlappyBirdContext _context;

        public ScoreService(FlappyBirdContext context)
        {
            _context = context;
        }
        public async Task<Score?> CreatePost(Score score)
        {
            if(IsScoreSetEmpty()) return null;
            _context.Score.Add(score);
            await _context.SaveChangesAsync();
            return score;
        }

        public bool IsScoreSetEmpty()
        {
            return _context == null || _context.Score == null;
        }
        public async Task ChangeVisibility(Score score)
        {
            if(IsScoreSetEmpty()) return;
            score.IsPublic = !score.IsPublic;
            await _context.SaveChangesAsync();
        }
        public async Task<Score> FindByIdScore(int id)
        {
            Score score = await _context.Score.FindAsync(id);
            return score;
        }
        public async Task<IEnumerable<Score>?> ScoresToList()
        {
            if (IsScoreSetEmpty()) return null;
            return await _context.Score.ToListAsync();
        }
        public async Task<User?> GetUserAsync(string id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}
