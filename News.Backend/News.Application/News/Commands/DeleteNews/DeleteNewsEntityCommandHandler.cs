using MediatR;
using Microsoft.EntityFrameworkCore;
using News.Application.Interfaces;
using News.Application.Common.Exceptions;
using News.Domain;

namespace News.Application.News.Commands.DeleteNews
{
    public class DeleteNewsEntityCommandHandler : IRequestHandler<DeleteNewsEntityCommand>
    {
        private readonly INewsDbContext _dbContext;

        public DeleteNewsEntityCommandHandler(INewsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(DeleteNewsEntityCommand request, CancellationToken cancellationToken)
        {
            NewsEntity? newsEntity = await _dbContext.News
                .FirstOrDefaultAsync(note => note.Id == request.NewsId, cancellationToken);

            if (newsEntity == null 
                || newsEntity.Id != request.NewsId
                || newsEntity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(NewsEntity), request.NewsId);
            }

            _dbContext.News.Remove(newsEntity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}