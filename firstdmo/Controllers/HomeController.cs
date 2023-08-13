using firstdmo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json.Nodes;

namespace firstdmo.Controllers
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
        public string Index2()
        {
            return "Salom dunyo";
        }
        
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public string MyName([FromBody] JsonObject model)
        {
            return model["Name"].ToString();
        }

        public string Description([FromQuery] string query)
        {
            return query[0].ToString();
        }

        public IActionResult Register() 
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