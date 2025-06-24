using MediatR;
using Microsoft.EntityFrameworkCore;
using News.Application.Interfaces;
using News.Application.Common.Exceptions;
using News.Domain;

namespace News.Application.News.Commands.UpdateNews;

public class UpdateNewsEntityCommandHandler : IRequestHandler<UpdateNewsEntityCommand>
{
    private readonly INewsDbContext _dbContext;

    public UpdateNewsEntityCommandHandler(INewsDbContext dbContext)
    {
        _dbContext = dbContext;
    }
        
    public async Task Handle(UpdateNewsEntityCommand request, CancellationToken cancellationToken)
    {
        NewsEntity? newsEntity = await _dbContext.News
            .FirstOrDefaultAsync(note => note.Id == request.NewsId, cancellationToken);

        if (newsEntity == null 
            || newsEntity.Id != request.NewsId 
            || newsEntity.UserId != request.UserId)
        {
            throw new NotFoundException(nameof(NewsEntity), request.NewsId);
        }
            
        newsEntity.Title = request.Title;
        newsEntity.Content = request.Content;
        newsEntity.Tags = request.Tags;
        newsEntity.ModifiedTime = DateTime.UtcNow;
            
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}