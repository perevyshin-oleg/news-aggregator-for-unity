using MediatR;

namespace News.Application.News.Commands.CreateNews;

public class CreateNewsEntityCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }
    public string[]? Tags { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
}