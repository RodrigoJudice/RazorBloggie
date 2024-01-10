using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;

namespace Bloggie.Web.Repositories;

public interface IBlogPostRepository
{
    Task<IEnumerable<BlogPost>> GetAllAsync();
    Task<IEnumerable<BlogPost>> GetAllAsync(string tagName);
    Task<BlogPost?> GetAsync(Guid id);
    Task<BlogPost?> GetAsync(string urlHandle);
    Task<BlogPost?> AddAsync(BlogPost blogPost);
    Task<BlogPost?> UpdateAsync(EditBlogPostRequest blogPost);
    Task<bool> DeleteAsync(Guid id);
}
