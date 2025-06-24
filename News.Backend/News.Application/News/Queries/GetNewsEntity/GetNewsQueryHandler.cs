using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using News.Application.Interfaces;
using News.Application.Common.Exceptions;
using News.Domain;

namespace News.Application.News.Queries.GetNews;

public class GetNewsQueryHandler : IRequestHandler<GetNewsEntityQuery, NewsEntityVm>
{
    private readonly IMapper _mapper;
    private readonly INewsDbContext _dbContext;

    public GetNewsQueryHandler(IMapper mapper, INewsDbContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }

    public async Task<NewsEntityVm> Handle(GetNewsEntityQuery request, CancellationToken cancellationToken)
    {
        NewsEntity? newsEntity = await _dbContext.News
            .FirstOrDefaultAsync(news => news.Id == request.NewsId, cancellationToken);

        if (newsEntity == null)
        {
            throw new NotFoundException(nameof(NewsEntity), request.NewsId);
        }
        
        return _mapper.Map<NewsEntityVm>(newsEntity);
    }
}