using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Pages.Admin.Blogs
{
    public class ListModel : PageModel
    {
        private readonly BloggieDbContext _context;
        public List<BlogPost> BlogPosts { get; set; }

        public ListModel(BloggieDbContext context)
        {
            _context = context;
        }

        public async Task OnGet()
        {
            BlogPosts = await _context.BlogPosts.ToListAsync();
        }
    }
}
