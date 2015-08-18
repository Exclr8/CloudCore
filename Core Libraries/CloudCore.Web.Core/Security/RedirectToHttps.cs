using System;

namespace CloudCore.Web.Core.Security
{
    public class RedirectToHttps : System.Web.Mvc.RequireHttpsAttribute
    {
        private bool _redirect;

        public RedirectToHttps()
        {
            _redirect = WebApplication.Configuration.WebSettings.RedirectToHttps;
        }

        public RedirectToHttps(bool redirect)
        {
            _redirect = redirect;
        }

        public override void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext) 
        {
            if (filterContext == null){
                throw new ArgumentNullException("filterContext");
            }

            if (/*filterContext.HttpContext != null && */ !_redirect /* && filterContext.HttpContext.Request.IsLocal*/)
            {
                return;
            }
 
            base.OnAuthorization(filterContext);
        }

        protected override void HandleNonHttpsRequest(System.Web.Mvc.AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            if (/*filterContext.HttpContext != null && */!_redirect /* && filterContext.HttpContext.Request.IsLocal*/)
            {
                return;
            }

            base.HandleNonHttpsRequest(filterContext);
        }
 
    }
}
