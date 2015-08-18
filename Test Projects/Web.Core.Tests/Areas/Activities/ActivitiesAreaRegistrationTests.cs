using System.Web.Mvc;
using System.Web.Routing;
using CloudCore.Web.Core.Areas.Activities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Web.Core.Tests.Areas.Activities
{
    [TestClass]
    public class ActivitiesAreaRegistrationTests
    {
        [TestMethod]
        public void ActivitiesAreaRegistration_RegisterArea_ActivitiesRouteAdded()
        {
            // arrange
            const string areaName = "Activities";
            const string routeName = "Activities_default";

            RouteCollection routes = new RouteCollection();
            AreaRegistrationContext context = new AreaRegistrationContext(areaName, routes);
            var registration = new ActivitiesAreaRegistration();

            // act
            registration.RegisterArea(context);

            // assert
            var route = context.Routes[routeName] as Route;
            
            Assert.IsNotNull(route);
            Assert.AreEqual("Activities/{controller}/{action}/{id}", route.Url);
            Assert.AreEqual("Main", route.Defaults["controller"]);
            Assert.AreEqual("Index", route.Defaults["action"]);
            Assert.AreEqual(areaName, route.Defaults["area"]);
            Assert.AreEqual(UrlParameter.Optional, route.Defaults["id"]);
            Assert.AreEqual(areaName, registration.AreaName);
            Assert.AreEqual(areaName, context.AreaName);
        }
    }
}
