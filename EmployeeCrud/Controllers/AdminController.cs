using EmployeeCrud.Data;
using EmployeeCrud.Models;
using EmployeeCrud.Models.Employee;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace EmployeeCrud.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext _db;

        public AdminController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            // Check if the user is logged in
            if (HttpContext.Session.GetString("LoggedInAdmin") == null)
            {
                // Redirect to the login page if not logged in
                return RedirectToAction("Login");
            }

            // If logged in, show the employee list
            List<Employee> empobj = _db.Employees.ToList();
            return View(empobj);
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Admin obj)
        {
            string username = obj.User_name?.Trim();
            string password = obj.Password?.Trim();

            // Check the credentials against the database
            var admin = _db.Admins.FirstOrDefault(a => a.User_name == username && a.Password == password);

            if (admin != null)
            {
                // Set the session variable to indicate the user is logged in
                HttpContext.Session.SetString("LoggedInAdmin", admin.User_name);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password");
                return View();
            }
        }

        // logout functionality here
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("LoggedInAdmin");
            return RedirectToAction("Login");
        }

        // crud operation

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Add(employee);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Employee? empid = _db.Employees.Find(id);
            if (empid == null)
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
                _db.Employees.Update(employee);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Employee empid = _db.Employees.Find(id);
            if (id == null)
            {
                return NotFound();
            }
            return View(empid);
        }

        [HttpPost, ActionName("Delete")]

        public IActionResult Deletepost(int? id)
        {
            Employee empid = _db.Employees.Find(id);


            if (empid == null)
            {
                return View();
            }
            _db.Employees.Remove(empid);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
