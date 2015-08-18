using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CloudCore.Web.Core.BaseControllers;
using CloudCore.Web.Core.Caching.CachedReusableObjects;
using CloudCore.Web.Core.LayoutSettings;
using Frameworkone.Domain;
using Frameworkone.ThirdParty.PostageApp;
using Moq;

namespace Frameworkone.UnitTestUtilities.Web
{
    public static class MockHelper
    {
        public static HttpContextBase MockHttpContextBase(NameValueCollection queryStringCollection = null)
        {
            Frameworkone.UnitTestUtilities.Web.MockHttpContext.CreateNewHttpContext(); 

            var request = new Mock<HttpRequestBase>(MockBehavior.Strict);

            if (queryStringCollection != null)
                SetupMockRequestQuerystringValues(request, queryStringCollection);

            request.SetupGet(x => x.ApplicationPath).Returns("/");
            request.SetupGet(x => x.Url).Returns(new Uri("http://localhost/", UriKind.Absolute));
            request.SetupGet(x => x.ServerVariables).Returns(new System.Collections.Specialized.NameValueCollection());

            var response = new Mock<HttpResponseBase>(MockBehavior.Strict);
            response.Setup(x => x.ApplyAppPathModifier(Moq.It.IsAny<String>())).Returns((String url) => url);
            var cookies = new HttpCookieCollection();
            response.SetupGet(x => x.Cookies).Returns(cookies); // This also failed to work

            var context = new Mock<HttpContextBase>(MockBehavior.Strict);
            context.SetupGet(x => x.Request).Returns(request.Object);
            context.SetupGet(x => x.Response).Returns(response.Object);
            context.SetupGet(x => x.Response.Cookies).Returns(new HttpCookieCollection()); // still can't call the Clear() method
            context.SetupGet(p => p.User.Identity.Name).Returns("blah");
            context.SetupGet(p => p.User.Identity.IsAuthenticated).Returns(true);

            return context.Object;
        }

        private static void SetupMockRequestQuerystringValues(Mock<HttpRequestBase> request, NameValueCollection queryStringCollection)
        {
            request.SetupGet(x => x.QueryString).Returns(queryStringCollection);
        }

        public static T MockController<T>() where T : CoreController
        {
            var controller = new Mock<T>(MockRepository());

            SetFakeControllerContext(controller.Object, MockHttpContextBase());

            return controller.Object;
        }

        public static T MockControllerWithMailMan<T>() where T : CoreController
        {
            var controller = new Mock<T>(MockRepository(), MockMailMan());

            SetFakeControllerContext(controller.Object, MockHttpContextBase());

            return controller.Object;
        }

        public static TempDataDictionary MockControllerTempData()
        {
            return new Mock<TempDataDictionary>().Object;
        }

        /// <summary>
        /// Creates a basic Repository
        /// </summary>
        /// <returns>mocked repository object</returns>
        public static IRepository MockRepository()
        {
            return CreateSimpleGenericMock<IRepository>();
        }

        public static IMailMan MockMailMan()
        {
            return CreateSimpleGenericMock<IMailMan>();
        }

        /// <summary>
        /// Creates a repository with a FindAll Specification
        /// </summary>
        /// <typeparam name="TEntity">The entity type</typeparam>
        /// <param name="returnData">ienumerable of type TEntity</param>
        /// <returns>mocked repository</returns>
        public static IRepository MockRepository<TEntity>(IEnumerable<TEntity> returnData) where TEntity : Entity    
        {
            var mock = new Mock<IRepository>(MockBehavior.Loose);

           // mock.Setup(x => x.FindAll<TEntity>(It.IsAny<ISpecification>())).Returns(returnData);

            return mock.Object;
        }

        public static ViewContext MockViewContext()
        {
            return CreateSimpleGenericMock<ViewContext>();
        }

       

        public static CachedReusableObject MockCacheReusableObject()
        {
            var mock = new Mock<CachedReusableObject>();

            mock.Setup(x => x.GetTitle()).Returns("CroTitle");

            return mock.Object;
        }


        public static T MockWebViewPage<T>() where T : WebViewPage
        {
            var mock = new Mock<T>(MockBehavior.Loose) { CallBase = true };
            mock.SetupGet(x => x.Context).Returns(MockHttpContextBase());
            mock.SetupGet(x => x.Layout).Returns("layoutName");
            mock.SetupGet(x => x.VirtualPath).Returns("virtualPathName");
            mock.SetupGet(x => x.Page).Returns(new object { });
            mock.SetupGet(x => x.PageData).Returns(new Dictionary<object, dynamic>()
            {
                {new object(), new object()}
            });

            var page = mock.Object;
            //var helper = new HtmlHelper<object>(new ViewContext { ViewData = CreateSimpleGenericMock<ViewDataDictionary>() }, page, CreateSimpleGenericMock<RouteCollection>());
            var helper = new HtmlHelper<object>(new ViewContext { ViewData = new ViewDataDictionary() }, page, new RouteCollection());
            page.ViewContext = MockViewContext();
            page.Html = helper;

            return page;
        }


        public static T CreateSimpleGenericMock<T>() where T : class
        {
            var mock = new Mock<T>(MockBehavior.Loose);

            return mock.Object;
        }

        public static void SetFakeControllerContext(this Controller controller, HttpContextBase httpContext)
        {
            SetFakeControllerContext(controller, httpContext, new RouteData());
        }
        public static void SetFakeControllerContext(this Controller controller, HttpContextBase httpContext, RouteData routeData)
        {
            var context = new ControllerContext(new RequestContext(httpContext, routeData), controller);
            controller.ControllerContext = context;
        }

    }
}
