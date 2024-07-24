using Bloggie.Models;
using Bloggie.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Bloggie.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bloggie.Controllers
{
    public class WriteController : Controller
    {
        private readonly ChatGPTService _chatGptService;
        private readonly ApplicationDbContext _context;

        public WriteController(ChatGPTService chatGptService, ApplicationDbContext context)
        {
            _chatGptService = chatGptService;
            _context = context;
        }

        // GET: Write/Create
        public IActionResult Create()
        {
            // Pass categories to the view
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // POST: Write/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogPost blogPost, string generateContent)
        {
            if (ModelState.IsValid)
            {
                if (generateContent != null)
                {
                    // Fetch the category asynchronously
                    var category = await _context.Categories.FindAsync(blogPost.CategoryId);

                    // Check if the category is null
                    if (category != null)
                    {
                        string prompt = $"Write a blog post about {blogPost.Title} in the category of {category.Name}";
                        blogPost.Content = await _chatGptService.GenerateContentAsync(prompt);
                    }
                }

                blogPost.CreatedAt = DateTime.UtcNow;
                _context.Add(blogPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Pass categories to the view
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
            return View(blogPost);
        }

        // GET: Write/Index
        public async Task<IActionResult> Index()
        {
            var blogPosts = await _context.BlogPosts.Include(b => b.Category).ToListAsync();
            return View(blogPosts);
        }
    }
}
