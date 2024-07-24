using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bloggie.Data;
using Bloggie.Models;
using System.Linq;

namespace Bloggie.Controllers
{
    public class landingPageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public landingPageController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var aiBlogs = _context.BlogPosts
                .Include(bp => bp.Category)
                .Where(bp => bp.Category.Name == "AI")
                .ToList();

            var ecommerceBlogs = _context.BlogPosts
                .Include(bp => bp.Category)
                .Where(bp => bp.Category.Name == "Ecommerce")
                .ToList();

            var blockchainBlogs = _context.BlogPosts
                .Include(bp => bp.Category)
                .Where(bp => bp.Category.Name == "Blockchain")
                .ToList();

            var webDevelopmentBlogs = _context.BlogPosts
                .Include(bp => bp.Category)
                .Where(bp => bp.Category.Name == "Web Development")
                .ToList();

            ViewData["AIBlogs"] = aiBlogs;
            ViewData["EcommerceBlogs"] = ecommerceBlogs;
            ViewData["BlockchainBlogs"] = blockchainBlogs;
            ViewData["WebDevelopmentBlogs"] = webDevelopmentBlogs;

            return View();
        }

        public IActionResult Details(int id)
        {
            var blogPost = _context.BlogPosts
                .Include(bp => bp.Category)
                .FirstOrDefault(bp => bp.Id == id);

            if (blogPost == null)
            {
                return NotFound();
            }

            return View(blogPost);
        }
    }
}
