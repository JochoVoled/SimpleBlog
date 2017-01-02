using Microsoft.EntityFrameworkCore;

namespace SimpleBlog.Models
{
    public class BlogDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; } // todo will I get a NullReferenceException here?
        public DbSet<Category> Categories { get; set; } 

        public BlogDbContext(DbContextOptions options) : base(options) {}
    }
}
