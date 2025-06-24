using AutoMapper;
using News.Application.News.Queries.GetNewsList;
using News.Persistance.DataBase;
using News.Tests.Common;
using Shouldly;

namespace News.Tests.News.Queries
{
    [Collection("QueryCollection")]
    public class GetNewsListQueryHandlerTests
    {
        private readonly NewsDbContext _context;
        private readonly IMapper _mapper;

        public GetNewsListQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }


        [Fact]
        public async void GetNewsListQueryHandler_Success()
        {
            GetNewsListQueryHandler handler = new GetNewsListQueryHandler(_context, _mapper);
            NewsListVm result = await handler.Handle(new GetNewsListQuery(), CancellationToken.None);
            result.ShouldBeOfType<NewsListVm>();
            result.NewsList.Count.ShouldBe(4);
        }
    }
}
