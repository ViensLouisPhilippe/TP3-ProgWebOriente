using Microsoft.AspNetCore.Mvc;

namespace TP3FlappyBird.Controllers
{
    public class ScoresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
