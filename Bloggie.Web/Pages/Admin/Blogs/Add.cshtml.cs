#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
using Bloggie.Web.Models.Mapper;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Bloggie.Web.Pages.Admin.Blogs;

[Authorize(Roles = "Admin")]
public class AddModel : PageModel
{
    private readonly IBlogPostRepository _blogPostRepository;


    [BindProperty]
    public AddBlogPost AddBlogPostRequest { get; set; }

    public AddModel(IBlogPostRepository blogPostRepository)
    {
        _blogPostRepository = blogPostRepository;

    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {

        var post = (new BlogMapper()).AddBlogPostRequestToBlogPost(AddBlogPostRequest);

        await _blogPostRepository.AddAsync(post);

        var notification = new Notification
        {
            Type = Enums.NotificationType.Success,
            Message = "New blog created!"
        };

        TempData["Notification"] = JsonSerializer.Serialize(notification);


        return RedirectToPage("/Admin/Blogs/List");

    }
}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.