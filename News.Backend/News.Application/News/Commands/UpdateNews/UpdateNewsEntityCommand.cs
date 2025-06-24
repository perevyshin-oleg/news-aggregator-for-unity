using MediatR;

namespace News.Application.News.Commands.UpdateNews
{
    public class UpdateNewsEntityCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid NewsId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string[]? Tags { get; set; }
    }
}
