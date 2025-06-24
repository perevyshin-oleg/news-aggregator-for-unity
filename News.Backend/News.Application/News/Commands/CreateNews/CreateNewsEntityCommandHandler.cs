using MediatR;
using News.Application.Interfaces;
using News.Domain;

namespace News.Application.News.Commands.CreateNews;

public class CreateNewsEntityCommandHandler : IRequestHandler<CreateNewsEntityCommand, Guid>
{
    private readonly INewsDbContext _dbContext;

    public CreateNewsEntityCommandHandler(INewsDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Guid> Handle(CreateNewsEntityCommand request, CancellationToken cancellationToken)
    {
        var newsEntity = new NewsEntity()
        {
            Id = Guid.NewGuid(),
            UserId = request.UserId,
            Tags = request.Tags,
            Title = request.Title,
            Content = request.Content,
            CreatedTime = DateTime.UtcNow,
            ModifiedTime = null
        };
        
        await _dbContext.News.AddAsync(newsEntity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return newsEntity.Id;
    }
}