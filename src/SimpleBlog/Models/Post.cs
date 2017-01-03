using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleBlog.Models
{
    public class Post
    {
        public int PostId { get; set; }
        [Required, StringLength(50,ErrorMessage = "Title must be 50 characters or less")]
        public string Title { get; set; }
        [Required, StringLength(2000, ErrorMessage = "A post must be 2,000 characters or less")]
        public string Content { get; set; }
        public DateTime PostDate { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
