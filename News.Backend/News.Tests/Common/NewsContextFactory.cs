using Microsoft.EntityFrameworkCore;
using News.Domain;
using News.Persistance.DataBase;

namespace News.Tests.Common
{
    public class NewsContextFactory
    {
        public static Guid UserAId = Guid.NewGuid();
        public static Guid UserBId = Guid.NewGuid();

        public static Guid NewsIdForDelete = Guid.NewGuid();
        public static Guid NewsIdForUpdate = Guid.NewGuid();

        public static NewsDbContext Create()
        {
            DbContextOptions<NewsDbContext> options = new DbContextOptionsBuilder<NewsDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            NewsDbContext context = new NewsDbContext(options);
            context.Database.EnsureCreated();
            context.News.AddRange(
                new NewsEntity
                {
                    CreatedTime = DateTime.UtcNow,
                    Content = "Lorem ipsum",
                    ModifiedTime = null,
                    Id = Guid.Parse("C3F5B25D-96E9-4CA4-A978-F236D6E49A31"),
                    Title = "Title1",
                    UserId = UserAId
                },
                new NewsEntity
                {
                    CreatedTime = DateTime.UtcNow,
                    Content = "Lorem ipsum 2",
                    ModifiedTime = null,
                    Id = Guid.Parse("F2A52E8F-BBB4-47A7-8595-4BD41D42640F"),
                    Title = "Title2",
                    UserId = UserBId
                },
                new NewsEntity
                {
                    CreatedTime = DateTime.UtcNow,
                    Content = "Lorem ipsum 3",
                    ModifiedTime = null,
                    Id = NewsIdForDelete,
                    Title = "Title3",
                    UserId = UserAId
                },
                new NewsEntity
                {
                    CreatedTime = DateTime.UtcNow,
                    Content = "Lorem ipsum 4",
                    ModifiedTime = null,
                    Id = NewsIdForUpdate,
                    Title = "Title4",
                    UserId = UserBId
                });
            context.SaveChanges();
            return context;
        }

        public static void Destroy(NewsDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
