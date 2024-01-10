#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
using Bloggie.Web.Data;
using Bloggie.Web.Models.Mapper;
using Bloggie.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Blogs;

public class AddModel : PageModel
{
    private readonly BloggieDbContext _context;

    [BindProperty]
    public AddBlogPost AddBlogPostRequest { get; set; }

    public AddModel(BloggieDbContext context)
    {
        _context = context;

    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {

        var post = (new BlogMapper()).AddBlogPostRequestToBlogPost(AddBlogPostRequest);

        _context.BlogPosts.Add(post);
        await _context.SaveChangesAsync();

        return RedirectToPage("/Admin/Blogs/List");

    }
}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.