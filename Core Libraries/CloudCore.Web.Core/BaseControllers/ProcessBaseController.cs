using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using CloudCore.Domain.Workflow;
using CloudCore.Web.Core.LayoutAttributes;
using CloudCore.Web.Core.Security.Authentication;

using CloudCore.Data;

namespace CloudCore.Web.Core.BaseControllers
{
    /// <summary>
    /// Should be inherited by your controllers for internal actions for process views.
    /// Provides notification and notification redirect functionality.
    /// Includes internal layout for authorised and authenticated users
    /// Provides functionality to navigate through processes
    /// </summary>
    [WorkItemLayout]
    [CloudCoreAuthenticated]
    public abstract class ProcessBaseController : CoreController
    {
        public ActionResult FlowNavigate(long instanceId, bool started = false)
        {
            if (!started)
            {
                Data.CloudCoreDB.Context.Cloudcore_WorkItemFlow(instanceId, CloudCoreIdentity.UserId, null);
            }
            return new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Tasklist", action = "Index", area = "CUI" }));
        }

        public ActionResult FlowNavigate(long instanceId, string outcome, bool started = false)
        {
            if (!started)
            {

                Data.CloudCoreDB.Context.Cloudcore_WorkItemFlow(instanceId, CloudCoreIdentity.UserId, outcome);

            }
            return new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Tasklist", action = "Index", area = "CUI" }));
        }
       
    }
}
