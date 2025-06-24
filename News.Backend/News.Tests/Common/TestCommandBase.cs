using News.Persistance.DataBase;

namespace News.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly NewsDbContext Context;

        public TestCommandBase()
        {
            Context = NewsContextFactory.Create();
        }

        public void Dispose()
        {
            NewsContextFactory.Destroy(Context);
        }
    }
}
