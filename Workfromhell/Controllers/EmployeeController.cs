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
          
            //RedirectToAction("Index");
            return View();
        }

        public IActionResult Detail(int id)
        {
            //Console.WriteLine(id);
            var em = _db.Employees.FirstOrDefault(m => m.EmployeeId == id);
            if(em == null)
            {
                return NotFound();
            }
            return View(em);
        }

        public IActionResult Edit(int id)
        {
            //Console.WriteLine(id);
            var em = _db.Employees.FirstOrDefault(m => m.EmployeeId == id);
            if (em == null)
            {
                return NotFound();
            }
            return View(em);

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,Name,Lastname,Age,Joined")] Employee employee)
        {
            Console.WriteLine("ID to update {0}",id);
            if (ModelState.IsValid)
            {
                Console.WriteLine("Validate!!!");
                _db.Update(employee);  //Need primary key to know which element to update, If there are no primary key
                //it will create new entry in database
                await _db.SaveChangesAsync();
                
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var em = await _db.Employees.FindAsync(id);
            if (em == null)
            {
                return NotFound();
            }

            _db.Employees.Remove(em);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
