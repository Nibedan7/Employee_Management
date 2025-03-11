using EmployeeCrud.Data;
using EmployeeCrud.Models.Employee;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCrud.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext _employeeDbContext;
        public EmployeeController(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }

        public IActionResult Index()
        {
            List<Employee> empobj = _employeeDbContext.Employees.ToList();
            return View(empobj);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeDbContext.Employees.Add(employee);
                _employeeDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id == null|| id == 0)
            {
                return NotFound();
            }
            Employee? empid = _employeeDbContext.Employees.Find(id);
            if(empid == null)
            {
                return NotFound();
            }
            return View(empid);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeDbContext.Employees.Update(employee);
                _employeeDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Employee empid = _employeeDbContext.Employees.Find(id);
            if(id == null)
            {
                return NotFound();
            }
            return View(empid);
        }

        [HttpPost,ActionName("Delete")]
       
        public IActionResult Deletepost(int? id)
        {
            Employee empid = _employeeDbContext.Employees.Find(id);
            

            if (empid == null )
            {
                return View();
            }
            _employeeDbContext.Employees.Remove(empid);
            _employeeDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
