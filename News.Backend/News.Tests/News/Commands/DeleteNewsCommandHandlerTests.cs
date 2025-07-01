using News.Application.Common.Exceptions;
using News.Application.News.Commands.CreateNews;
using News.Application.News.Commands.DeleteNews;
using News.Application.News.Commands.UpdateNews;
using News.Tests.Common;

namespace News.Tests.News.Commands
{
    public class UpdateNewsCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateNewsCommandHandler_Success()
        {
            UpdateNewsEntityCommandHandler handler = new UpdateNewsEntityCommandHandler(Context);
            string updateTitle = "updated title";
            string updateContent = "updated content";

            await handler.Handle(new UpdateNewsEntityCommand
            {
                NewsId = NewsContextFactory.NewsIdForUpdate,
                UserId = NewsContextFactory.UserBId,
                Title = updateTitle,
                Content = updateContent
            }, CancellationToken.None);

            Assert.NotNull(Context.News.SingleOrDefault(news =>
                news.Title == updateTitle));
        }

        [Fact]
        public async Task UpdateNewsCommandHandler_FailOnWrongNewsId()
        {
            UpdateNewsEntityCommandHandler handler = new UpdateNewsEntityCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateNewsEntityCommand()
                    {
                        NewsId = Guid.NewGuid(),
                        UserId = NewsContextFactory.UserAId
                    }, CancellationToken.None));
        }

        [Fact]
        public async Task UpdateNewsCommandHandler_FailOnWrongUserId()
        {
            UpdateNewsEntityCommandHandler handler = new UpdateNewsEntityCommandHandler(Context);
            
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                new UpdateNewsEntityCommand()
                {
                    NewsId = NewsContextFactory.NewsIdForUpdate,
                    UserId = Guid.NewGuid()
                }, CancellationToken.None));
        }
    }
}
