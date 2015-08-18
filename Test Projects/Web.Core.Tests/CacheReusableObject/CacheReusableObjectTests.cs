using System;
using System.Web.Mvc;
using CloudCore.Web.Core.BaseModels;
using CloudCore.Web.Core.Caching.CachedReusableObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web.Core.Tests.BaseModels;

namespace Web.Core.Tests.CacheReusableObject
{
    [TestClass]
    public class CacheReusableObjectTests
    {
        [TestMethod]
        public void CanUpdateKey()
        {
            var cacheReusableObjectTestClass = new CacheReusableObjectTestClass { Key = 1 };

            Assert.AreEqual(1, cacheReusableObjectTestClass.Key);
        }

        [TestMethod]
        public void KeySetToDefault()
        {
            var cacheReusableObjectTestClass = new CacheReusableObjectTestClass();

            Assert.AreEqual(-999999, cacheReusableObjectTestClass.Key);
        }
    }

    public class CacheReusableObjectTestClass : CachedReusableObject
    {
        public override string GetTitle()
        {
            return "Title";
        }

        protected override void Refresh()
        {
        }

        public override void AddContent(CROContent content, UrlHelper urlHelper)
        {
            base.AddContent(content, urlHelper);
        }
    }
}
