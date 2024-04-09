using FlappyBirdTP3.Models;
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
        readonly ScoreService _score_service;

        public ScoresController(UserManager<User> userManager, ScoreService score_service)
        {
            UserManager = userManager;
            _score_service = score_service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Score>>> GetPublicScores()
        {
            if (_score_service.IsScoreSetEmpty())
            {
                return NotFound();
            }
            return Ok(await _score_service.ScoresToList());
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScoreDTO>>> GetMyScores()
        {
            if(_score_service.IsScoreSetEmpty())
            {
                return NotFound();
            }
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User? user = await UserManager.FindByIdAsync(userId);
            if(user != null)
            {
                IEnumerable<Score> scores = user.Scores.ToList();
                return Ok(scores.Where(c => c.User != null).Select(c => new ScoreDTO { 
                    Id = c.Id,
                    TimeInSeconds = c.TimeInSeconds,
                    Date = c.Date,
                    Pseudo = c.User!.UserName,
                    ScoreValue = c.ScoreValue,
                    Visible = c.Visible
                }));
            }
            return StatusCode(StatusCodes.Status400BadRequest, new { Message = "utilisateur non trouvé" });
        }

        [HttpPut]
        public async Task<ActionResult> ChangeScoreVisibility(int id)
        {
            Score score = await _score_service.FindByIdScore(id);
            if (score != null)
            {
                await _score_service.ChangeVisibility(score);
                return Ok();
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Score>> PostScore(Score score)
        {
            if (_score_service.IsScoreSetEmpty())
            {
                return Problem("Entity set 'score' is null");
            }
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User? user = await _score_service.GetUserAsync(userId);
            if(user != null)
            {
                score.User = user;
                score.Date = DateTime.Now;
                user.Scores.Add(score);

                _score_service.CreatePost(score);
                return Ok(score);
            }

            return StatusCode(StatusCodes.Status400BadRequest, new { Message = "utilisateur non trouvé" });
        }
    }
}
