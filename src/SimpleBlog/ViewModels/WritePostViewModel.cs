using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimpleBlog.Models;

namespace SimpleBlog.ViewModels
{
    public class WritePostViewModel
    {
        public Post Post { get; set; }
        public List<SelectListItem> Categories { get; } = new List<SelectListItem>();
    }
}
