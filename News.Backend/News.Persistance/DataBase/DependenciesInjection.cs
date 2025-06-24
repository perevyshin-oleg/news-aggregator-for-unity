using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using News.Application.Interfaces;
using News.Persistance.DataBase;


namespace News.Backend.Infrastructure.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString("DbConnection");
        services.AddDbContext<NewsDbContext>(options =>
            options.UseNpgsql(connectionString));
        services.AddScoped<INewsDbContext>(provider => 
            provider.GetService<NewsDbContext>());
        return services;
    }
}