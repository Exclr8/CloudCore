using System.IO;
using System.Reflection;
using System.Web;
using System.Web.SessionState;
using CloudCore.Core;

namespace Frameworkone.UnitTestUtilities.Web
{
    public class MockHttpContext
    {

        private static HttpContext _current;
        public static HttpContext Current
        {
            get
            {
                if (_current == null)
                {
                    _current = CreateNewHttpContext();
                }

                return _current;
            }
        }

        public MockHttpContext()
        {
            _current = CreateNewHttpContext();
        }

        public static HttpContext CreateNewHttpContext()
        {
            var httpRequest = new HttpRequest("", "http://localhost/", "");
            var stringWriter = new StringWriter();
            var httpResponce = new HttpResponse(stringWriter);
            var httpContext = new HttpContext(httpRequest, httpResponce);

            var sessionContainer = new HttpSessionStateContainer("id", new SessionStateItemCollection(),
                new HttpStaticObjectsCollection(), 10, true,
                HttpCookieMode.AutoDetect,
                SessionStateMode.InProc, false);

            httpContext.Items["AspSession"] = typeof(HttpSessionState).GetConstructor(
                BindingFlags.NonPublic | BindingFlags.Instance,
                null, CallingConventions.Standard,
                new[] { typeof(HttpSessionStateContainer) },
                null)
                .Invoke(new object[] { sessionContainer });

            HttpContext.Current = httpContext;
            _current = httpContext;
            
            return httpContext;
        }
    }
}
