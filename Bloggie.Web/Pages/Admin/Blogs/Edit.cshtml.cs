using Bloggie.Web.Data;
using Bloggie.Web.Models.Mapper;
using Bloggie.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Pages.Admin.Blogs
{
    public class EditModel : PageModel
    {
        private readonly BloggieDbContext _context;

        [BindProperty]
        public EditBlogPostRequest BlogPost { get; set; }

        public EditModel(BloggieDbContext context)
        {
            _context = context;
        }
        public async Task OnGet(Guid id)
        {
            var blogPostDomainModel = await _context.BlogPosts.FindAsync(id);
            if (blogPostDomainModel != null)
            {

                BlogPost = (new BlogMapper()).BlogPostToEditBlogPostRequest(blogPostDomainModel);
            }

        }

        public async Task<IActionResult> OnPostEdit()
        {
            var blogPostDomainModel = await _context.BlogPosts
                .AsNoTracking().FirstOrDefaultAsync(b => b.Id == BlogPost.Id);

            if (blogPostDomainModel != null)
            {
                var post = (new BlogMapper()).EditBlogPostRequestToBlogPost(BlogPost);
                _context.BlogPosts.Update(post);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Admin/Blogs/List");

        }

        public async Task<IActionResult> OnPostDelete()
        {
            var blogPosted = await _context.BlogPosts.FindAsync(BlogPost.Id);
            if (blogPosted != null)
            {
                _context.BlogPosts.Remove(blogPosted);
                await _context.SaveChangesAsync();

                return RedirectToPage("/Admin/Blogs/List");
            }

            return Page();
        }




    }
}
