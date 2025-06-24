using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using News.Application.Interfaces;

namespace News.Application.News.Queries.GetNewsList;

public class GetNewsListQueryHandler : IRequestHandler<GetNewsListQuery, NewsListVm>
{
    private readonly INewsDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetNewsListQueryHandler(INewsDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<NewsListVm> Handle(GetNewsListQuery request, CancellationToken cancellationToken)
    {
        List<NewsLookupDto> newsQuery = await _dbContext.News
            .ProjectTo<NewsLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        
        return new NewsListVm() {NewsList = newsQuery};
    }
}