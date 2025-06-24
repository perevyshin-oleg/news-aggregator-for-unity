using MediatR;

namespace News.Application.News.Queries.GetNewsList;

public record GetNewsListQuery : IRequest<NewsListVm> { }