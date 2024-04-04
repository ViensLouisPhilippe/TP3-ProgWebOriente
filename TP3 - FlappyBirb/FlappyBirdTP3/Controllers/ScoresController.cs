using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TP3FlappyBird.Data;
using TP3FlappyBird.Models;

namespace TP3FlappyBird.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ScoresController : Controller
    {
        readonly UserManager<User> UserManager;
        readonly FlappyBirdContext _dbContext;

        public ScoresController(UserManager<User> userManager, FlappyBirdContext dbContext)
        {
            UserManager = userManager;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Score>>> GetPublicScores()
        {
            if (_dbContext.Score == null)
            {
                return NotFound();
            }
            return _dbContext.Score.ToList();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Score>>> GetMyScores()
        {
            if(_dbContext.Score == null)
            {
                return NotFound();
            }
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User? user = await UserManager.FindByIdAsync(userId);
            if(user != null)
            {
                return user.Scores;
            }
            return StatusCode(StatusCodes.Status400BadRequest, new { Message = "utilisateur non trouvé" });
        }

        [HttpPut]
        public async Task<ActionResult> ChangeScoreVisibility(int id)
        {
            Score score = await _dbContext.Score.FindAsync(id);
            if (score != null)
            {
                score.Visible = !score.Visible;
                await _dbContext.SaveChangesAsync();
                return Ok();
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Score>> PostScore(Score score)
        {
            if (_dbContext.Score == null)
            {
                return Problem("Entity set 'score' is null");
            }
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User? user = await _dbContext.Users.FindAsync(userId);
            if(user != null)
            {
                score.User = user;
                score.Date = DateTime.Now;
                user.Scores.Add(score);

                _dbContext.Score.Add(score);
                await _dbContext.SaveChangesAsync();
                return Ok(score);
            }

            return StatusCode(StatusCodes.Status400BadRequest, new { Message = "utilisateur non trouvé" });
        }
    }
}
