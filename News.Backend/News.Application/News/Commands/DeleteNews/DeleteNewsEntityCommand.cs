using MediatR;

namespace News.Application.News.Commands.DeleteNews
{
    public class DeleteNewsEntityCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid NewsId { get; set; }
    }
}
