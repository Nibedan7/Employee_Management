using EmployeeCrud.Data;
using EmployeeCrud.Models;
using EmployeeCrud.Models.Employee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EmployeeCrud.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("LoggedInUser") == null)
            {
                return RedirectToAction("Login");
            }
            List<Employee> empobj = _db.Employees.ToList();

            var department= _db.Employees.Select(e => e.Department).Distinct().ToList();
            return View(department);
        }
        public IActionResult Department(string department)
        {
            if(HttpContext.Session.GetString("LoggedInUser") == null)
            {
                return RedirectToAction("Login");
            }

            var employeeInDepartment = _db.Employees.Where(e => e.Department == department).ToList();
            return View(employeeInDepartment);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User obj)
        {
            string email = obj.Email?.Trim();
            string password = obj.Password?.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewData["ErrorMessage"] = "Email and Password cannot be empty!";
                return View();
            }

            var user = await _db.Users
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                HttpContext.Session.SetString("LoggedInUser", user.Email);
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["ErrorMessage"] = "Invalid email or password.";
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("LoggedInUser");
            return RedirectToAction("Login");
        }

        public IActionResult Register()
         {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User obj)
        {
            if (ModelState.IsValid)
            {
                // Check if the email already exists in the database
                var existingUser = _db.Users.FirstOrDefault(u => u.Email == obj.Email);
                if (existingUser != null)
                {
                    // Email already exists
                    ModelState.AddModelError("Email", "This email is already taken.");
                    return View(obj);
                }

                // Hash the password before saving the user
                //var passwordHasher = new PasswordHasher<User>();
                //var hashedPassword = passwordHasher.HashPassword(obj, obj.Password);

                // Set the hashed password
                //obj.Password = hashedPassword;

                // Add the user to the database
                _db.Users.Add(obj);
                _db.SaveChanges();

                // Redirect to login page after successful registration
                return RedirectToAction("Login");
            }
            return View(obj);
        }

        }
    }
