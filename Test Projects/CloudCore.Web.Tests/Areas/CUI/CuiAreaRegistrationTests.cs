using System.Web.Mvc;
using System.Web.Routing;
using CloudCore.Web.Areas.CUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.Web.Tests.Areas.CUI
{
    [TestClass]
    public class CuiAreaRegistrationTests
    {
        [TestMethod]
        public void CuiAreaRegistration_RegisterArea_CuiRouteAdded_DataTokensSet()
        {
            // arrange
            const string areaName = "CUI";
            const string routeName = "CUI_default";

            RouteCollection routes = new RouteCollection();
            AreaRegistrationContext context = new AreaRegistrationContext(areaName, routes); 
            var registration = new CuiAreaRegistration();
            
            // act
            registration.RegisterArea(context);

            // assert
            var route = context.Routes[routeName] as Route;
            
            Assert.IsNotNull(route);
            Assert.AreEqual("CUI/{controller}/{action}/{id}", route.Url);
            Assert.AreEqual("Main", route.Defaults["controller"]);
            Assert.AreEqual("Index", route.Defaults["action"]);
            Assert.AreEqual(areaName, route.Defaults["area"]);
            Assert.AreEqual(UrlParameter.Optional, route.Defaults["id"]);
            Assert.AreEqual("Login", route.DataTokens["LoginController"]);
            Assert.AreEqual("Index", route.DataTokens["LoginAction"]);
            Assert.AreEqual(areaName, registration.AreaName);
            Assert.AreEqual(areaName, context.AreaName);
        }
    }
}
