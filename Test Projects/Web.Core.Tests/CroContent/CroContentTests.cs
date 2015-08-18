using System;
using System.Linq;
using CloudCore.Web.Core.Caching.CachedReusableObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Web.Core.Tests.CroContent
{
    [TestClass]
    public class CroContentTests
    {
        private CROContent croContent;
        private const string Title = "Title";
        private const string Value = "Value";
        private const string Email = "Email";
        private const string Url = "Url";

        [TestInitialize]
        public void Init()
        {
            croContent = new CROContent();
        }

        [TestMethod]
        public void CanAddHtmlContentToCroContent()
        {
            croContent.AddHtmlContent(Title, Value);

            var item = croContent.Items.First(i => i.Title == Title && i.Value == Value && i.Type == "Html");

            AssertNotNullAndOfType(item, typeof(HtmlContentItem));
        }

        [TestMethod]
        public void CanAddEmailContentToCroContent()
        {
            croContent.AddEmailContent(Title, Value, Email);

            var item = croContent.Items.First(i => i.Title == Title && i.Value == Value && i.Type == "Email");

            AssertNotNullAndOfType(item, typeof(EmailContentItem));
            Assert.AreEqual(Email, ((EmailContentItem)item).Email);
        }

        [TestMethod]
        public void CanAddUrlContentToCroContent()
        {
            croContent.AddUrlContent(Title, Value, Url);

            var item = croContent.Items.First(i => i.Title == Title && i.Value == Value && i.Type == "Link");

            AssertNotNullAndOfType(item, typeof(LinkContentItem));
            Assert.AreEqual(Url, ((LinkContentItem)item).Url);
        }

        private static void AssertNotNullAndOfType(HtmlContentItem item, Type type)
        {
            Assert.IsNotNull(item);
            Assert.IsInstanceOfType(item, type);
        }
    }
}
