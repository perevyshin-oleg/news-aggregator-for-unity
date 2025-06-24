using Microsoft.EntityFrameworkCore;
using News.Application.Interfaces;
using News.Domain;
using News.Backend.Infrastructure.Persistances.EntityTypeConfigurations;

namespace News.Persistance.DataBase;

public class NewsDbContext : DbContext, INewsDbContext
{
    public DbSet<NewsEntity> News { get; set; }
    
    public NewsDbContext(DbContextOptions<NewsDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new NewsEntityConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}