using System.Linq;
using CloudCore.Domain;
using Frameworkone.UnitTestUtilities.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Data.Tests
{
    [TestClass]
    public class FavouriteTests : CloudCoreRepositoryRollbackDatabaseTestContext
    {
        [TestMethod]
        [Ignore]
        public void CanGetFavourites()
        {
            //TODO: We need to insert a Favourite before this test will work

            var items = Repository.FindAll<Favourite>(r => r.Id.UserId == 4 && r.Type == FavouriteType.Menu).Select(r => r.Id.Reference).ToList();

            Assert.AreEqual(2, items.Count);
        }
    }
}
