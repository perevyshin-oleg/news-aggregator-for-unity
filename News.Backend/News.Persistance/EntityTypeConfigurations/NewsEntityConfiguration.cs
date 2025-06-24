using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News.Domain;

namespace News.Backend.Infrastructure.Persistances.EntityTypeConfigurations;

public class NewsEntityConfiguration: IEntityTypeConfiguration<NewsEntity>
{
    public void Configure(EntityTypeBuilder<NewsEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Title);
        builder.Property(e => e.Content);
    }
}