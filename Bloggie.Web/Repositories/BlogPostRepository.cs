using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.Mapper;
using Bloggie.Web.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Repositories;

public class BlogPostRepository : IBlogPostRepository
{
    private readonly BloggieDbContext _context;

    public BlogPostRepository(BloggieDbContext context)
    {
        _context = context;
    }

    public async Task<BlogPost> AddAsync(BlogPost blogPost)
    {
        await _context.BlogPosts.AddAsync(blogPost);
        await _context.SaveChangesAsync();
        return blogPost;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existingBlog = await _context.BlogPosts.FindAsync(id);

        if (existingBlog != null)
        {
            _context.BlogPosts.Remove(existingBlog);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }

    public async Task<IEnumerable<BlogPost>> GetAllAsync()
    {
        return await _context.BlogPosts.ToListAsync();
    }

    public async Task<IEnumerable<BlogPost>> GetAllAsync(string tagName)
    {
        throw new NotImplementedException();
    }

    public async Task<BlogPost?> GetAsync(Guid id)
    {
        return await _context.BlogPosts.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<BlogPost?> GetAsync(string urlHandle)
    {
        return await _context.BlogPosts.FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);
    }

    public async Task<BlogPost?> UpdateAsync(EditBlogPostRequest blogPost)
    {

        var blogPostDomainModel = await _context.BlogPosts
                .AsNoTracking().FirstOrDefaultAsync(b => b.Id == blogPost.Id);

        if (blogPostDomainModel != null)
        {
            var post = (new BlogMapper()).EditBlogPostRequestToBlogPost(blogPost);
            _context.BlogPosts.Update(post);
            await _context.SaveChangesAsync();
        }

        return blogPostDomainModel;

    }

}
