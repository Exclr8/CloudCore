using System;
using System.Security.Policy;
using System.Web.Mvc;
using CloudCore.Core.DependencyResolution;
using CloudCore.Web.Core;
using CloudCore.Web.Core.BaseModels;
using Frameworkone.Domain;
using Frameworkone.UnitTestUtilities;
using Frameworkone.UnitTestUtilities.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Web.Core.Tests.BaseModels
{
    [TestClass]
    public class BaseContextModelTests
    {
        public const int Key = 1;
        public const string Title = "Title";
        public const string Link = "Link";
        private BaseContextModelTestClass contextModel;

        [TestInitialize]
        public void Init()
        {
            IoC.Initialize();
            contextModel = new BaseContextModelTestClass();
        }

        [TestMethod]
        public void CanCreateContextModelAndAddCro()
        {
            contextModel.AddKeyed(MockHelper.MockCacheReusableObject(), Key);

            Assert.IsTrue(CastContextModelToICroRendererAndReturn().CanDisplay());
        }

        [TestMethod]
        public void CanSetKey()
        {
            contextModel.AddKeyed(MockHelper.MockCacheReusableObject(), Key);

            contextModel.Key = Key;

            Assert.IsFalse(CastContextModelToICroRendererAndReturn().CanDisplay());
        }

        [TestMethod]
        public void CanAddToSideBar()
        {
            var sideBar = new CloudCore.Web.Core.Sidebar();
            contextModel.InitializeSidebar(sideBar, null);

            Assert.IsTrue(sideBar.CanDisplay);

            sideBar.ForEach(i => Assert.AreEqual(1, i.Items.Count));         
        }

        [TestMethod]
        public void CanDispose()
        {
            contextModel.AddKeyed(MockHelper.MockCacheReusableObject(), Key);

            contextModel.Dispose();

            try
            {
                CastContextModelToICroRendererAndReturn().CanDisplay();
            }
            catch (NullReferenceException ex)
            {                    
               Assert.IsNotNull(ex, "CROList has been disposed of in contextModel");
            }

        }

        [TestMethod]
        public void CanOverrideOnKeyChanged()
        {
            contextModel.OnKeyChanged();
        }

        [TestMethod]
        public void CanGetCroContent()
        {
            contextModel.AddKeyed(MockHelper.MockCacheReusableObject(), Key);
            contextModel.AddKeyed(MockHelper.MockCacheReusableObject(), 2);
            contextModel.AddKeyed(MockHelper.MockCacheReusableObject(), 3);

            var result = CastContextModelToICroRendererAndReturn().GetCROContent(null);

            Assert.AreEqual(@"[{""CROTitle"":""CroTitle"",""Items"":[]},{""CROTitle"":""CroTitle"",""Items"":[]},{""CROTitle"":""CroTitle"",""Items"":[]}]",
                                result);
        }

        [TestMethod]
        public void CanOverrideRefreshContext()
        {
            contextModel.RefreshContext(MockHelper.MockRepository());
        }

        private ICRORenderer CastContextModelToICroRendererAndReturn()
        {
            return contextModel;
        }
    }

    public class BaseContextModelTestClass : BaseContextModel
    {

        public override void InitializeSidebar(CloudCore.Web.Core.Sidebar sidebar, UrlHelper urlHelper)
        {
            base.InitializeSidebar(sidebar, urlHelper);

            sidebar.AddSidebarItem(SidebarObjectType.ManageConfigure, BaseContextModelTests.Title, BaseContextModelTests.Link);
            sidebar.AddSidebarItem(SidebarObjectType.ReportDocument, BaseContextModelTests.Title, BaseContextModelTests.Link);
            sidebar.AddSidebarItem(SidebarObjectType.ViewDisplay, BaseContextModelTests.Title, BaseContextModelTests.Link);
        }

        public void OnKeyChanged()
        {
            OnKeyChanged(BaseContextModelTests.Key);
        }

        protected override void OnKeyChanged(long key)
        {
            base.OnKeyChanged(key);
        }

        public override void RefreshContext(IRepository repository)
        {
            base.RefreshContext(repository);
        }
    }
}
