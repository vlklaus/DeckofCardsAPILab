using _060324_Deck_of_Cards_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _060324_Deck_of_Cards_API.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DeckResult()
        {
            DeckModel result = DeckDAL.GetDeck();
            if(result.remaining < 5)
            {
                DeckDAL.Shuffle();
            }
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
