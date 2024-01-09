using Bloggie.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Data
{
    public class BloggieDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }

    }
}
