using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Web.Core.Tests.ViewEngine
{
    [TestClass]
    public class ViewEngineTests
    {
        [TestMethod]
        public void CanSetViewLocationSearchPaths()
        {
            var areaViewLocationFormatsExpected = new[]
            {
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Core/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml"
            };

            var viewEngine = new CloudCore.Web.Core.ViewEngine();

            var areaViewLocationFormatsResult = viewEngine.AreaViewLocationFormats.ToList();

            Assert.AreEqual(areaViewLocationFormatsExpected.Count(), areaViewLocationFormatsResult.Count());

            Assert.IsTrue(areaViewLocationFormatsResult.Contains(areaViewLocationFormatsExpected[0]));
            Assert.IsTrue(areaViewLocationFormatsResult.Contains(areaViewLocationFormatsExpected[1]));
            Assert.IsTrue(areaViewLocationFormatsResult.Contains(areaViewLocationFormatsExpected[2]));

        }

        [TestMethod]
        public void CanSetAreaMasterLocationFormats()
        {
            var areaMasterLocationFormatsExpected = new[]
            {
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml",
            };

            var viewEngine = new CloudCore.Web.Core.ViewEngine();

            var areaMasterLocationFormatsResult = viewEngine.AreaMasterLocationFormats.ToList();

            Assert.AreEqual(areaMasterLocationFormatsExpected.Count(), areaMasterLocationFormatsResult.Count());

            Assert.IsTrue(areaMasterLocationFormatsResult.Contains(areaMasterLocationFormatsExpected[0]));
            Assert.IsTrue(areaMasterLocationFormatsResult.Contains(areaMasterLocationFormatsExpected[1]));

        }

        [TestMethod]
        public void CanSetAreaPartialViewLocationFormats()
        {
            var areaPartialViewLocationFormatsExpected = new[]
            {
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml"
            };

            var viewEngine = new CloudCore.Web.Core.ViewEngine();

            var areaPartialViewLocationFormatsResult = viewEngine.AreaPartialViewLocationFormats.ToList();

            Assert.AreEqual(areaPartialViewLocationFormatsExpected.Count(), areaPartialViewLocationFormatsResult.Count());

            Assert.IsTrue(areaPartialViewLocationFormatsResult.Contains(areaPartialViewLocationFormatsExpected[0]));
            Assert.IsTrue(areaPartialViewLocationFormatsResult.Contains(areaPartialViewLocationFormatsExpected[1]));

        }

        [TestMethod]
        public void CanSetViewLocationFormats()
        {
            var viewLocationFormatsExpected = new[]
            {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/{1}/{0}.aspx",
                "~/Views/Shared/{0}.aspx"
            };

            var viewEngine = new CloudCore.Web.Core.ViewEngine();

            var viewLocationFormatsResult = viewEngine.ViewLocationFormats.ToList();

            Assert.AreEqual(viewLocationFormatsExpected.Count(), viewLocationFormatsResult.Count());

            Assert.IsTrue(viewLocationFormatsResult.Contains(viewLocationFormatsExpected[0]));
            Assert.IsTrue(viewLocationFormatsResult.Contains(viewLocationFormatsExpected[1]));
        }

        [TestMethod]
        public void CanSetMasterLocationFormats()
        {
            var masterLocationFormatsExpected = new[]
            {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Areas/CUI/Views/Shared/{0}.cshtml"
            };

            var viewEngine = new CloudCore.Web.Core.ViewEngine();

            var masterLocationFormatsResult = viewEngine.MasterLocationFormats.ToList();

            Assert.AreEqual(masterLocationFormatsExpected.Count(), masterLocationFormatsResult.Count());

            Assert.IsTrue(masterLocationFormatsResult.Contains(masterLocationFormatsExpected[0]));
            Assert.IsTrue(masterLocationFormatsResult.Contains(masterLocationFormatsExpected[1]));
        }

        [TestMethod]
        public void CanSetPartialViewLocationFormats()
        {
            var partialViewLocationFormatsExpected = new[]
            {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Areas/CUI/Views/Shared/{0}.cshtml"
            };

            var viewEngine = new CloudCore.Web.Core.ViewEngine();

            var partialViewLocationFormatsResult = viewEngine.PartialViewLocationFormats.ToList();

            Assert.AreEqual(partialViewLocationFormatsExpected.Count(), partialViewLocationFormatsResult.Count());

            Assert.IsTrue(partialViewLocationFormatsResult.Contains(partialViewLocationFormatsExpected[0]));
            Assert.IsTrue(partialViewLocationFormatsResult.Contains(partialViewLocationFormatsExpected[1]));
        }
    }
}
