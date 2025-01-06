using FinalProject.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Enums = FinalProject.Core.Enums;

namespace FinalProject.DL.Contexts;

public class AppDbContext : IdentityDbContext<AppUser, IdentityRole, string>
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Size> Sizes { get; set; }
    public DbSet<Product> Products { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        #region User Roles
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "be2d8e7a-3bc4-462b-83c8-998b57942350",
                Name = Enums.UserRoles.Admin.ToString(),
                NormalizedName = Enums.UserRoles.Admin.ToString().ToUpper(),
            },
            new IdentityRole
            {
                Id = "8329d499-a035-4462-909b-08852c3eaee0",
                Name = Enums.UserRoles.User.ToString(),
                NormalizedName = Enums.UserRoles.User.ToString().ToUpper(),
            }
        );
        #endregion

        #region Admin
        AppUser admin = new()
        {
            Id = "eb726cd3-71c1-4b46-9c25-fa7038bd185b",
            FirstName = "Super",
            LastName = "Admin",
            UserName = "admin",
            NormalizedUserName = "ADMIN"
        };
        admin.PasswordHash = new PasswordHasher<AppUser>().HashPassword(admin, "admin123");
        builder.Entity<AppUser>().HasData(admin);

        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "be2d8e7a-3bc4-462b-83c8-998b57942350",
                UserId = admin.Id
            }
        );
        #endregion

        base.OnModelCreating(builder);
    }
}
