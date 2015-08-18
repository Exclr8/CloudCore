using System;
using System.Collections.Specialized;
using CloudCore.Web.Core.BaseViews;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Web.Core.Tests.BaseViews
{
    [TestClass]
    public class LookUpViewTests
    {
        [TestMethod]
        public void LookUpView_CanSetLookUpControlValuesAsHref()
        {
            var lookUpViewTestClass = new LookUpViewTestClass
            {
                ViewContext = MockHelper.MockViewContext(),
                Context = MockHelper.MockHttpContextBase(new NameValueCollection
                                                        {
                                                            {"idName", "idNameValue"},
                                                            {"valueName", "valueNameValue"}
                                                        })
            };

            var result = lookUpViewTestClass.SetLookUpControlValuesAsHref("idValue", "nameValue", "hrefText").ToString();

            Assert.AreEqual(@"<a href=""#"" onclick=""parent.setLookUpControlValues('idNameValue', 'idValue', 'valueNameValue', 'nameValue');"">hrefText</a>", 
                result);

        }
    }

    public class LookUpViewTestClass : LookupView<object>
    {
        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
