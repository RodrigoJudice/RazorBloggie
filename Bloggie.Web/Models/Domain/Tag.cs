#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
using System.ComponentModel.DataAnnotations.Schema;

namespace Bloggie.Web.Models.Domain;

public class Tag
{
    public Guid Id { get; set; }

    [Column(TypeName = "varchar(200)")]
    public string Name { get; set; }

    public Guid BlogPostId { get; set; }
}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
