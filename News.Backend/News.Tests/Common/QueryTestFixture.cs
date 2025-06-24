using AutoMapper;
using News.Application.Common.Mapping;
using News.Application.Interfaces;
using News.Persistance.DataBase;

namespace News.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public NewsDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = NewsContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(INewsDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            NewsContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
