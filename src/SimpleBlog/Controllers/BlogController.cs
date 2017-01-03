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

        public IActionResult WritePost()
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
            return View(model);
        }

        [HttpPost]
        public IActionResult WritePost(Post post)
        {
            post.PostDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Posts.Add(post);
                _context.SaveChanges();
                return RedirectToAction("ListView");
            }
            else
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
                model.Post = post;
                return View("WritePost",model);
            }
        }
    }
}
