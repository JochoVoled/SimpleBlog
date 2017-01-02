using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimpleBlog.Models;
using SimpleBlog.ViewModels;

namespace SimpleBlog.Controllers
{
    public class BlogController : Controller
    {
        private BlogDbContext _context;

        public BlogController(BlogDbContext context)
        {
            _context = context;
        }
        // Search, filters ListView based on query
        [HttpGet]
        public IActionResult ListView(string query)
        {
            var model = new PostListViewModel();
            if (query != null)
            {
                model.Posts = _context.Posts.Where(post => post.Category.Name.Contains(query)).ToList();
                model.Posts.AddRange(_context.Posts.Where(post => post.Title.Contains(query)).ToList());
            }
            else
            {
                model.Posts = _context.Posts.ToList();
            }
            model.DateSort();
            return View(model);
        }
        public IActionResult PostView(int id)
        {
            var model = _context.Posts.First(post => post.PostId == id);
            model.Category = _context.Categories.First(cat => cat.Id == model.CategoryId);
            return View(model);
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult WritePost(string error)
        {
            WritePostViewModel model = new WritePostViewModel();
            foreach (var category in _context.Categories)
            {
                model.Categories.Add(new SelectListItem
                {
                    Value = category.Id.ToString(),
                    Text = category.Name
                });
            }
            if (!string.IsNullOrEmpty(error))
            {
                model.Message = error;
            }
            return View(model);
        }

        public void CreatePost(Post post)
        {
            //post.Category = _context.Categories.First(cat => cat.Id == post.CategoryId);
            //return View("PostView", post);
            post.PostDate = DateTime.Now;
            //AddToContext(post);
            //ListView(null);
            try
            {
                _context.Posts.Add(post);
                _context.SaveChanges();
                ListView(null);
            }
            catch
            {
                WritePost("Posting failed");
            }
        }
    }
}
