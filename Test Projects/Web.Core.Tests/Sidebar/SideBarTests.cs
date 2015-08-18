using System;
using System.Linq;
using CloudCore.Web.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Web.Core.Tests.Sidebar
{
    [TestClass]
    public class SideBarTests
    {
        private const string Title = "Title1";
        private const string Link = "Link1";
        private CloudCore.Web.Core.Sidebar sideBar = null;

        [TestInitialize]
        public void Init()
        {
            sideBar = new CloudCore.Web.Core.Sidebar();
        }

        [TestMethod]
        public void CanCreateDetaultSidebar()
        {
            Assert.AreEqual(3, sideBar.Count);
        }

        [TestMethod]
        public void ViewAndDisplayExists()
        {
            Assert.IsNotNull(GetSideBarItemList("View & Display"));
        }

        [TestMethod]
        public void ManageAndConfigureExists()
        {
            Assert.IsNotNull(GetSideBarItemList("Manage & Configure"));
        }

        [TestMethod]
        public void ReportAndDocumentsExists()
        {
            Assert.IsNotNull(GetSideBarItemList("Report & Documents"));
        }

        [TestMethod]
        public void CanAddItem()
        {
            AddSideBarItem();
            var items = GetSideBarItemList("View & Display").Items;

            Assert.AreEqual(1, items.Count);
            var item = items.First(i => i.Link == Link && i.Title == Title);

            Assert.IsNotNull(item);
        }

        private SidebarObjectList GetSideBarItemList(string title)
        {
            return sideBar.First(s => s.Title == title);
        }

        [TestMethod]
        public void CanDisplaySideBar()
        {
            AddSideBarItem();
            Assert.IsTrue(sideBar.CanDisplay);
        }

        private void AddSideBarItem()
        {
            sideBar.AddSidebarItem(SidebarObjectType.ViewDisplay, Title, Link);
        }

    }

}
