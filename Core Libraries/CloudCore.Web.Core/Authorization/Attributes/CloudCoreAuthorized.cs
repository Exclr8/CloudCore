using CloudCore.Core;
using CloudCore.Modules;
using CloudCore.Utilities;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace CloudCore.Authorization
{
    public interface ICloudCoreAuthorized
    {
    
    }

    public class CloudCoreAuthorized : ActionFilterAttribute, ICloudCoreAuthorized
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var area = filterContext.RouteData.DataTokens["area"].ToString();
            var controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var action = filterContext.ActionDescriptor.ActionName;
            var modAction = ModuleEnvironment.ModuleActions.FindAction(area, controller, action);
            // do we have any permissions defined?
            if (modAction == null)
            {
                string valueTransform = string.Format(@"root.AddSystemAction(""{0}"", SystemActionType.Details, ""{1}"", ""{2}"", ""{3}"", ""{4}"");", Guid.NewGuid().ToString(), GenericUtils.SplitCamelCase( action ), area, controller, action);
                filterContext.Result = RedirectToAccessDeniedAsUndefined(valueTransform);
                return;
            }

            // has the user been granted the permission?
            if (!UserPermission.TestForAccess(modAction.ActionGuid))
            {
                filterContext.Result = RedirectToAccessDeniedNoPermission();
                return;
            }
            else
            {
                filterContext.Controller.ViewBag.Title = modAction.ActionTitle;
                filterContext.Controller.ViewBag.ActionType = modAction.ActionType.ToString();
            }
            base.OnActionExecuting(filterContext);
        }

        private RedirectToRouteResult RedirectToAccessDeniedAsUndefined(string displayText)
        {
           return new RedirectToRouteResult(new RouteValueDictionary(new  { action = "Undefined", Controller = "Access", area = "CUI", displayText = displayText }));
        }

        private RedirectToRouteResult RedirectToAccessDeniedNoPermission()
        {
            return new RedirectToRouteResult(new RouteValueDictionary(new  { action = "Denied", Controller = "Access", area = "CUI" }));
        }
    }
}
