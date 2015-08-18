using System;
using System.Collections.Specialized;
using System.Web.Mvc;
using CloudCore.Web.Core.BaseViews;
using CloudCore.Web.Core.LayoutSettings;
using Frameworkone.UnitTestUtilities;
using Frameworkone.UnitTestUtilities.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Web.Core.Tests.BaseViews
{
    [TestClass]
    public class WebViewTests
    {
        private WebViewTestClass webViewTestClass;
        
        [TestInitialize]
        public void NewWebView()
        {
            webViewTestClass = new WebViewTestClass
            {
                ViewContext = MockHelper.MockViewContext()
            };
        }

        [TestMethod]
        public void CanInstaniateAndPopUpHelperExists()
        {
            webViewTestClass.InitHelpers();
            Assert.IsNotNull(webViewTestClass.PopUps);
        }

        [TestMethod]
        public void CanInstaniateAndViewSettingsExists()
        {
            webViewTestClass.ViewData["ViewSettings"] = MockHelper.MockViewSettings();
            webViewTestClass.InitPage();
            Assert.IsNotNull(webViewTestClass.Settings);
        }
    }

    public class WebViewTestClass : WebView<object>
    {
        public override void Execute()
        {

        }

        public void InitPage()
        {
            InitializePage();
        }
    }
}
