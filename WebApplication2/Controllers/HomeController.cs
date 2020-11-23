using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;

// localhost/Controller/Methode
namespace WebApplication2
{
    public class HomeController : Controller
    {
        private MijnContext context;

        public HomeController(MijnContext context) 
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}