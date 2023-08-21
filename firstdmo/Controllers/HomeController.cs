using System.Diagnostics;
using System.Text.Json.Nodes;

namespace firstdemo.Controllers
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

        public async Task Data()
        {
            Response.ContentType = "text/html;charset=utf-8";
            System.Text.StringBuilder tableBuilder = new("<h2>Request headers</h2><table>");
            foreach (var header in Request.Headers)
            {
                tableBuilder.Append($"<tr><td>{header.Key}</td><td>{header.Value}</td></tr>");
            }
            tableBuilder.Append("</table>");
            await Response.WriteAsync(tableBuilder.ToString());
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public string EmailResult(string email)
        {
            return email.ToString();
        }
        public IActionResult Form()
        {
            return View();
        }
        public string ModelReturn(Book book)
        {
            return $"{book.Id} {book.Title}";
        }
        public string RequestQuery()
        {
            string name = Request.Query["email"];
            return $"email: {name}";
        }
    }
}