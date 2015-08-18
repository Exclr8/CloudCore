using Frameworkone.Domain;
using Rhino.Mocks;

namespace CloudCore.Domain.Tests
{
    public abstract class TestBase
    {
        protected IRepository Repository { get; private set; }

        protected TestBase()
        {
            Initialize();
        }

        private void Initialize()
        {
            Repository = MockRepository.GenerateStrictMock<IRepository>();

        }
    }
}
