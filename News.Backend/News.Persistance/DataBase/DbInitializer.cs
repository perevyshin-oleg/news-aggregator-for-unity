using News.Application.Interfaces;

namespace News.Persistance.DataBase;

public class DbInitializer
{
    public static void Initialize(NewsDbContext context)
    {
        context.Database.EnsureCreated();
    }
}