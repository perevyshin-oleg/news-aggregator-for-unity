using Microsoft.EntityFrameworkCore;
using News.Domain;

namespace News.Application.Interfaces;

public interface INewsDbContext
{
    DbSet<NewsEntity> News { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}