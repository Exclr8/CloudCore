using System;
using CloudCore.Web.Core.BaseControllers;
using CloudCore.Web.Core.PopUps;
using Frameworkone.UnitTestUtilities.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web.Core.Tests.BaseControllers;

namespace Web.Core.Tests.PopUpClass
{
    [TestClass]
    public class PopUpClassTests : BaseControllerTest<ContextableController>
    {
        private const string Name = "Name";
        private const string Title = "Title";
        private const string Url = "Url";
        private const int Width = 100;
        private const int Height = 100;

        [TestMethod]
        public void CanCreateAndRenderPopUpLoadMarkUp()
        {
            var popUp = new PopUp(Name, Title, Width, Height, Url);

            var result = popUp.Render_PopupJavascript(Controller.HttpContext);

            Assert.AreEqual(ExpectedResult(), result);
        }

        private string ExpectedResult()
        {
            return
                string.Format(
                    @"function load_Name(){{loadPopup('{4}', '{2}px', '{3}px', '{0}', '{1}');}}function closeNamePopup(){{}}",
                    Name, Title, Width, Height, Url);
        }
    }
}
