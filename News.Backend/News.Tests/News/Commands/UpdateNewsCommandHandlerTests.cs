using News.Application.Common.Exceptions;
using News.Application.News.Commands.CreateNews;
using News.Application.News.Commands.DeleteNews;
using News.Tests.Common;

namespace News.Tests.News.Commands
{
    public class UpdateNewsCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateNewsCommandHandler_Success()
        {
            DeleteNewsEntityCommandHandler handler = new DeleteNewsEntityCommandHandler(Context);

            await handler.Handle(new DeleteNewsEntityCommand
            {
                NewsId = NewsContextFactory.NewsIdForDelete,
                UserId = NewsContextFactory.UserAId
            }, CancellationToken.None);

            Assert.Null(Context.News.SingleOrDefault(news =>
                news.Id == NewsContextFactory.NewsIdForDelete));
        }

        [Fact]
        public async Task DeleteNoteCommandHandler_FailOnWrongNewsId()
        {
            DeleteNewsEntityCommandHandler handler = new DeleteNewsEntityCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteNewsEntityCommand()
                    {
                        NewsId = Guid.NewGuid(),
                        UserId = NewsContextFactory.UserAId
                    }, CancellationToken.None));
        }

        [Fact]
        public async Task DeleteNoteCommandHandler_FailOnWrongUserId()
        {
            DeleteNewsEntityCommandHandler deleteHandler = new DeleteNewsEntityCommandHandler(Context);
            CreateNewsEntityCommandHandler createHandler = new CreateNewsEntityCommandHandler(Context);
            Guid newsId = await createHandler.Handle(
                new CreateNewsEntityCommand()
                {
                    Title = "NewsTitle",
                    UserId = NewsContextFactory.UserAId
                }, CancellationToken.None);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await deleteHandler.Handle(
                    new DeleteNewsEntityCommand
                    {
                        NewsId = newsId,
                        UserId = NewsContextFactory.UserBId
                    }, CancellationToken.None));
        }
    }
}
