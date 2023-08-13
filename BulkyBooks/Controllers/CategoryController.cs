using Microsoft.AspNetCore.Mvc;

namespace BulkyBooks.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
