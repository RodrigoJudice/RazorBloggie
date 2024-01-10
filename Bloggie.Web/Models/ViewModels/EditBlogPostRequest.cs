#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
using System.ComponentModel.DataAnnotations;

namespace Bloggie.Web.Models.ViewModels;

public class EditBlogPostRequest
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public string Heading { get; set; }
    [Required]
    public string PageTitle { get; set; }
    [Required]
    public string Content { get; set; }
    [Required]
    public string ShortDescription { get; set; }
    [Required]
    public string FeaturedImageUrl { get; set; }
    [Required]
    public string UrlHandle { get; set; }
    [Required]
    public DateTime PublishedDate { get; set; }
    [Required]
    public string Author { get; set; }
    public bool Visible { get; set; }
}

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.