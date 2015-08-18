using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.Domain.Tests.Favourites
{
    [TestClass]
    public class FavouriteIdTests
    {
        private readonly Guid nonUniqueGuid = Guid.NewGuid();

        [TestMethod]
        public void FavouriteId_DifferentIds_Equals_ReturnsFalse()
        {
            FavouriteId favouriteId1 = Get_New_Unique_FavouriteId();
            FavouriteId favouriteId2 = Get_New_Unique_FavouriteId();

            Assert.IsFalse(favouriteId1.Equals(favouriteId2));
        }

        private FavouriteId Get_New_Unique_FavouriteId()
        {
            return new FavouriteId { UserId = 1, Reference = Guid.NewGuid() };
        }

        [TestMethod]
        public void FavouriteId_SameIds_Equals_ReturnsTrue()
        {
            var favouriteId1 = Get_New_NonUnique_FavouriteId();
            var favouriteId2 = Get_New_NonUnique_FavouriteId();

            Assert.IsTrue(favouriteId1.Equals(favouriteId2));
        }

        private FavouriteId Get_New_NonUnique_FavouriteId()
        {
            return new FavouriteId { UserId = 1, Reference = nonUniqueGuid };
        }

        [TestMethod]
        public void FavouriteId_ToString_ReturnsCombinedIds()
        {
            FavouriteId fav = new FavouriteId { UserId = 145, Reference = new Guid("FA9744A6-5462-4B4A-BD70-C8760884D247")};
            var favStringRepresentation = fav.ToString();
            Assert.AreEqual(favStringRepresentation, "145:fa9744a6-5462-4b4a-bd70-c8760884d247");
        }

        [TestMethod]
        public void FavouriteId_DifferentObjectTypes_Equals_ReturnsFalse()
        {
            var favourite = Get_New_NonUnique_FavouriteId();
            var someOtherObject = new List<int>();

            // ReSharper disable once SuspiciousTypeConversion.Global
            Assert.IsFalse(favourite.Equals(someOtherObject));
        }
    }
}
