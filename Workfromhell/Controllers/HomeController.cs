using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Workfromhell.Models.db;
using Workfromhell.Models;

namespace Workfromhell.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CompanyContext _db;

        public HomeController(ILogger<HomeController> logger, CompanyContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            Console.WriteLine("Hello");
            var result = from i in _db.Customers select i;
            Console.WriteLine(result.Count()); //better way ro check if query result is null or not
            if (result == null)
                {
                    Console.WriteLine("Nothing");
                }

            return View();
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