using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Services;

// localhost/Controller/Methode
namespace WebApplication2
{
    public class HomeController : Controller
    {
        private MijnContext context;
        private IMijnService service;

        public HomeController(MijnContext context, IMijnService service) 
        {
            this.context = context;
            this.service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public string HelloWorld() 
        {
            return service.Hello();
        }
    }
}