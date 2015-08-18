using System;
using System.Web.Mvc;
using System.Web.Routing;
using CloudCore.Core.Utilities;
using CloudCore.Web.Core.BaseControllers;

namespace CloudCore.Web.Core.Security.Authorization.Attributes
{
    public class CloudCoreAuthorized : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var area = filterContext.RouteData.DataTokens["area"].ToString();
            var controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var action = filterContext.ActionDescriptor.ActionName;
            var modAction = CloudCore.Core.Modules.Environment.LoadedModuleActions.FindAction(area, controllerName, action);

            var controller = (CoreController)filterContext.Controller;

            if (modAction == null)
            {
                DisplayMissingActionConfig(filterContext, action, area, controllerName);
                return;
            }
            

            if (!UserPermission.TestForAccess(modAction.ActionGuid))
            {
                filterContext.Result = DisplayAccessDeniedNoPermission();
                return;
            }
            
            filterContext.Controller.ViewBag.Title = modAction.ActionTitle;
            filterContext.Controller.ViewBag.ActionType = modAction.ActionType.ToString();
            base.OnActionExecuting(filterContext);
        }

        private void DisplayMissingActionConfig(ActionExecutingContext filterContext, string action, string area,
            string controller)
        {
            string configToAdd =
                string.Format(@"Suggested configuration: root.AddSystemAction(""{0}"", SystemActionType.Details, ""{1}"", ""{2}"", ""{3}"", ""{4}"");",
                    Guid.NewGuid().ToString(), GenericUtils.SplitCamelCase(action), area, controller, action);

            string configMessage = string.Format("Action not configured in any module. Area: {0}, Controller: {1}, Action: {2}. Suggested configuration: {3}", area, controller, action, configToAdd);
            
            filterContext.Result = DisplayAccessDeniedAsUndefined(configMessage);
        }

        private RedirectToRouteResult DisplayAccessDeniedAsUndefined(string displayText)
        {
           return new RedirectToRouteResult(new RouteValueDictionary(new  { action = "Undefined", Controller = "Access", area = "CUI", displayText = displayText }));
        }

        private RedirectToRouteResult DisplayAccessDeniedNoPermission()
        {
            return new RedirectToRouteResult(new RouteValueDictionary(new  { action = "Denied", Controller = "Access", area = "CUI" }));
        }
    }
}
