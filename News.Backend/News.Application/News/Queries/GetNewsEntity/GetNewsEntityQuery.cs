using MediatR;

namespace News.Application.News.Queries.GetNews;

public record GetNewsEntityQuery : IRequest<NewsEntityVm>
{
    public Guid NewsId { get; set; }
}