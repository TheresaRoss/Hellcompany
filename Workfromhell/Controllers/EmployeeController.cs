using Microsoft.AspNetCore.Mvc;
using Workfromhell.Models.db;
using Workfromhell.Models;
namespace Workfromhell.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly CompanyContext _db;

        public EmployeeController(CompanyContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var em = from e in _db.Employees select e;
            Console.WriteLine("Total data in Employee table {0}", em.Count());
            return View(em);
        }

        public IActionResult Create()
        {
            Console.WriteLine("Yo man");
            //RedirectToAction("Index");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Lastname,Age,Joined")] Employee employee)
        {
            Console.WriteLine("What the hell happenned!");
            //Console.WriteLine(employee.Name); //this is how to get data from form via asp-for
            //Console.WriteLine(employee.Lastname);
            //Console.WriteLine(employee.Age);
         
            if (ModelState.IsValid)
            {
                Console.WriteLine("Validated!!!");
                _db.Add(employee);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }
    }
}
