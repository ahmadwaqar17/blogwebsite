using Bloggie.Data;
using Bloggie.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Bloggie.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            var existingUser = _context.Users
                .FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);

            if (existingUser != null)
            {
                return RedirectToAction("Index", "LandingPage");
            }

            ModelState.AddModelError("", "Invalid username or password");
            return View(user);
        }
        public IActionResult Register()
        {
            return View();
        }

        // POST: /User/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User model)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login");
            }

            return View(model);
        }
    }
}
