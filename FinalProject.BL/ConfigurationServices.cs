using FinalProject.BL.ExternalServices.Abstractions;
using FinalProject.BL.ExternalServices.Implementations;
using FinalProject.BL.Services.Abstractions;
using FinalProject.BL.Services.Concretes;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FinalProject.BL;

public static class ConfigurationServices
{
    public static void AddBLServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IColorService, ColorService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ISizeService, SizeService>();

        services
            .AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters()
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddSingleton<IJWTTokenService, JWTTokenService>();
    }
}
