using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bloggie.Data;
using Bloggie.Models;
using System;
using System.Linq;

namespace Bloggie.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categoriesWithBlogs = _context.Categories
                .Include(c => c.BlogPosts)
                .ToList();

            var blogsOfCategories = categoriesWithBlogs
                .SelectMany(c => c.BlogPosts)
                .ToList();

            ViewBag.Categories = categoriesWithBlogs;
            ViewBag.Blogs = blogsOfCategories;

            return View();
        }

        public IActionResult Details(int id)
        {
            var category = _context.Categories
                .Include(c => c.BlogPosts)
                .FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }
    }
}
