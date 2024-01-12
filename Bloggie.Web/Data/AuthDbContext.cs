using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Data;

public class AuthDbContext : IdentityDbContext
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var superAdminRoleId = "998C7B53-1A28-41F4-9A13-C930FA78C8DC";
        var adminRoleId = "8F5A3AE3-B0DE-458D-840A-6C1563E302F7";
        var userRoleId = "96F6AE01-A451-4124-8AB1-262D9F63E20C";


        // Seed Roles (User, Amind, Super Admin)
        var roles = new List<IdentityRole>
        {
            new() {Name = "SuperAdmin", NormalizedName = "SUPERADMIN", Id = superAdminRoleId},
            new() {Name = "Admin", NormalizedName = "ADMIN", Id = adminRoleId},
            new() {Name = "User", NormalizedName = "USER" , Id = userRoleId }
        };

        builder.Entity<IdentityRole>().HasData(roles);

        // Add Super Admin User
        var superAdminId = "E75B99F9-EC8F-4F67-9637-701A2933E332";
        IdentityUser superAdminUser = new()
        {
            Id = superAdminId,
            UserName = "superadmin@bloggie.com",
            Email = "superadmin@bloggie.com",
            NormalizedEmail = "superadmin@bloggie.com".ToUpper(),
            NormalizedUserName = "superadmin@bloggie.com".ToUpper(),
        };

        superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>()
            .HashPassword(superAdminUser, "SuperAdmin@123");

        builder.Entity<IdentityUser>().HasData(superAdminUser);

        // Add All Roles to Super Admin User
        var superAdminUserRoles = new List<IdentityUserRole<string>>
        {
            new() {RoleId = superAdminRoleId, UserId = superAdminId},
            new() {RoleId = adminRoleId, UserId = superAdminId},
            new() {RoleId = userRoleId, UserId = superAdminId}
        };

        builder.Entity<IdentityUserRole<string>>().HasData(superAdminUserRoles);

    }
}
