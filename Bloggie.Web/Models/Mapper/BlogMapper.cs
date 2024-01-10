using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Riok.Mapperly.Abstractions;

namespace Bloggie.Web.Models.Mapper
{
    [Mapper]
    public partial class BlogMapper
    {
        public partial BlogPost AddBlogPostRequestToBlogPost(AddBlogPost editBlogPostRequest);
        public partial BlogPost EditBlogPostRequestToBlogPost(EditBlogPostRequest editBlogPostRequest);
        public partial EditBlogPostRequest BlogPostToEditBlogPostRequest(BlogPost blogPost);
    }
}
