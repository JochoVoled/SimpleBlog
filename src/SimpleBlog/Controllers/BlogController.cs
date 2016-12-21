using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SimpleBlog.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult ListView()
        {
            return View();
        }

        // Search, filters ListView based on query
        [HttpGet]
        public IActionResult ListView(string query)
        {
            return View();
        }
        public IActionResult PostView()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
