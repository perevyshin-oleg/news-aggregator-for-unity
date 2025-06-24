using Microsoft.EntityFrameworkCore;
using News.Application.News.Commands.CreateNews;
using News.Tests.Common;

namespace News.Tests.News.Commands
{
    public class CreateNewsCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateNewsCommandHandler_Success()
        {
            CreateNewsEntityCommandHandler handler = new CreateNewsEntityCommandHandler(Context);
            string newsName = "news name";
            string newsContent = "news content";

            Guid newsId = await handler.Handle(
                new CreateNewsEntityCommand
                {
                    Title = newsName,
                    Content = newsContent,
                    UserId = NewsContextFactory.UserAId
                },
                CancellationToken.None);

            Assert.NotNull(
                await Context.News.SingleOrDefaultAsync(news => news.Id == newsId
                && news.Title == newsName
                && news.Content == newsContent));
        }
    }
}
