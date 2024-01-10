using Bloggie.Web.Enums;
using Bloggie.Web.Models.Mapper;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Bloggie.Web.Pages.Admin.Blogs;

public class EditModel : PageModel
{
    private readonly IBlogPostRepository _blogPostRepository;

    [BindProperty]
    public EditBlogPostRequest blogPost { get; set; }

    public EditModel(IBlogPostRepository blogPostRepository)
    {
        _blogPostRepository = blogPostRepository;
    }
    public async Task OnGet(Guid id)
    {
        var blogPostDomainModel = await _blogPostRepository.GetAsync(id);
        if (blogPostDomainModel != null)
        {
            blogPost = (new BlogMapper()).BlogPostToEditBlogPostRequest(blogPostDomainModel);
        }

    }

    public async Task<IActionResult> OnPostEdit()
    {

        var updated = await _blogPostRepository.UpdateAsync(blogPost);
        if (updated != null)
        {
            var notification = new Notification()
            {
                Message = "Blog Post Updated Successfully",
                Type = NotificationType.Success

            };
            TempData["Notification"] = JsonSerializer.Serialize(notification);

            return RedirectToPage("/Admin/Blogs/List");
        }
        return Page();

    }

    public async Task<IActionResult> OnPostDelete()
    {
        var deleted = await _blogPostRepository.DeleteAsync(blogPost.Id);
        if (deleted)
        {
            var notification = new Notification
            {
                Type = Enums.NotificationType.Success,
                Message = "Blog was deleted successfully!"
            };

            TempData["Notification"] = JsonSerializer.Serialize(notification);

            return RedirectToPage("/Admin/Blogs/List");
        }

        return Page();
    }

}
