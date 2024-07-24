using Microsoft.AspNetCore.Mvc;
using Bloggie.Data;
using Bloggie.Models;
using System.Linq;

namespace Bloggie.Controllers
{
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BlogController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Details(int id)
        {
            var blogPost = _context.BlogPosts
                .FirstOrDefault(b => b.Id == id);

            if (blogPost == null)
            {
                return NotFound();
            }

            return View(blogPost);
        }
    }
}
