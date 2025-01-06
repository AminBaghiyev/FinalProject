using FinalProject.Core.Entities;
using FinalProject.DL.Contexts;
using FinalProject.DL.Repositories.Abstractions;
using FinalProject.DL.Repositories.Implementations;
using FinalProject.DL.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FinalProject.DL;

public static class ConfigurationServices
{
    public static void AddDLServices(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>
        (
            options => options.UseSqlServer(Connection.GetConnectionString("local"))
        );

        services.AddScoped<IAuditableRepository<Category>, AuditableRepository<Category>>();
        services.AddScoped<IAuditableRepository<Product>, AuditableRepository<Product>>();
        services.AddScoped<IAuditableRepository<Color>, AuditableRepository<Color>>();
        services.AddScoped<IAuditableRepository<Size>, AuditableRepository<Size>>();
    }
}
