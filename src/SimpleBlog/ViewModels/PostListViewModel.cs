using System.Collections.Generic;
using SimpleBlog.Models;

namespace SimpleBlog.ViewModels
{
    public class PostListViewModel
    {
        public List<Post> Posts { get; set; }
        public string Query { get; set; }

        public void DateSort()
        {
            for (var i = 1; i < Posts.Count; i++)
            {
                if (Posts[i-1].PostDate <= Posts[i].PostDate) continue;
                var temp = Posts[i-1];
                Posts[i-1] = Posts[i];
                Posts[i] = temp;
                i = 0;
            }
        }
    }
}
