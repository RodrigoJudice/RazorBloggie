using Bloggie.Web.Data;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        var configuration = builder.Configuration;

        // Add services to the container.

        builder.Services.AddRazorPages();

        builder.Services.AddDbContext<BloggieDbContext>(
            options => options.UseNpgsql(configuration.GetConnectionString("Bloggie")
        ));

        builder.Services.AddDbContext<AuthDbContext>(
            options => options.UseNpgsql(configuration.GetConnectionString("BloggieAuth")
        ));

        builder.Services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<AuthDbContext>();

        builder.Services.Configure<IdentityOptions>(options =>
        {
            // Default password settings
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;
        });




        builder.Services.AddScoped<IBlogPostRepository, BlogPostRepository>();

        return builder.Build();

    }
    public static WebApplication ConfigurePipeline(this WebApplication app)
    {


        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapRazorPages();

        return app;
    }
}