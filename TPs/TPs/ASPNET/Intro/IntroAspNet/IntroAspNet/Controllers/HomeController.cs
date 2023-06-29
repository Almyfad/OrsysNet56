using IntroAspNet.Models;
using IntroAspNet.Services;
using IntroAspNet.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IntroAspNet.Controllers
{
    public class HomeController : Controller
    {

        private readonly IMessagerie _messagerie;
        public HomeController(IMessagerie messagerie)
        {
           _messagerie = messagerie;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet("Contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost("Contact")]
        public IActionResult Contact(ContactViewModel modele)
        {
            if (ModelState.IsValid)
            {
                _messagerie.EnvoyerEmail($"{modele.Sujet},{modele.Message} de{ modele.Nom}-{ modele.Email}","webmaster @app.com");
            }
            return View();
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
