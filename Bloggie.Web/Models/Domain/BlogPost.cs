#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
using System.ComponentModel.DataAnnotations.Schema;

namespace Bloggie.Web.Models.Domain;

public class BlogPost
{
    public Guid Id { get; set; }

    [Column(TypeName = "varchar(200)")]
    public string Heading { get; set; }

    [Column(TypeName = "varchar(200)")]
    public string PageTitle { get; set; }

    [Column(TypeName = "varchar(200)")]
    public string Content { get; set; }

    [Column(TypeName = "varchar(200)")]
    public string ShortDescription { get; set; }

    [Column(TypeName = "varchar(200)")]
    public string FeaturedImageUrl { get; set; }

    [Column(TypeName = "varchar(200)")]
    public string UrlHandle { get; set; }

    public DateTime PublishedDate { get; set; }

    [Column(TypeName = "varchar(200)")]
    public string Author { get; set; }

    public bool Visible { get; set; }

    // Navigation Property
    //public ICollection<Tag> Tags { get; set; }
    //public ICollection<BlogPostLike> Likes { get; set; }
    //public ICollection<BlogPostComment> Comments { get; set; }
}

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.