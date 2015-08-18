using System;
using CloudCore.Web.Core.BaseViews;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Web.Core.Tests.BaseViews
{
    [TestClass]
    public class CoreViewTests
    {
        [TestMethod]
        public void CanInstaniateViewAndFormLayoutIsAvailable()
        {
            var coreViewTestClass = new CoreViewTestClass
            {
                ViewContext = MockHelper.MockViewContext()
            };

            coreViewTestClass.InitHelpers();

            Assert.IsNotNull(coreViewTestClass.FormLayout);
        }
    }

    public class CoreViewTestClass : CoreView<object>
    {
        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
