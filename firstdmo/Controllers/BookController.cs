using firstdemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace firstdemo.Controllers
{
    public class BookController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        public string Show()
        {
            return "";
        }
        [HttpPost]
        public string Index(Book book)
        {
            return $"{book.Id}, {book.Title}, {book.Description}, {book.Phone}, {book.Count}, {book.Email}";
        }
    }
}
