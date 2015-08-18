using CloudCore.Configuration.ConfigFile;
using CloudCore.Web.Core.Security.Authentication;
using Frameworkone.ThirdParty.PostageApp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CloudCore.Web.Core.MvcFilters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        void IExceptionFilter.OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
                return;

            var actionName = filterContext.RequestContext.RouteData.Values["action"].ToString();
            var controllerName = filterContext.RequestContext.RouteData.Values["controller"].ToString();
            var requestType = filterContext.RequestContext.HttpContext.Request.RequestType;

            var exceptionObj = filterContext.Exception;

            var aggregateException = exceptionObj as AggregateException;
            if (aggregateException != null)
                aggregateException.Flatten();

            var key = FormatExecutingMethodName(controllerName, actionName, requestType);
            exceptionObj.Data.Add(key, String.Format("Failed in {0} action.", actionName));

            var exceptionMessage = FormatExceptionMessage(exceptionObj, "", CloudCoreIdentity.Fullname);
            SendNotificationEmail(exceptionMessage);
            
            filterContext.ExceptionHandled = false;
        }

        private string FormatExecutingMethodName(string controllerName, string actionName, string actionType = null)
        {
            return actionType != null
                ? String.Format("{0}.{1}[{2}]", controllerName, actionName, actionType)
                : String.Format("{0}.{1}", controllerName, actionName);
        }

        private void SendNotificationEmail(string message)
        {
            var templateName = "exception_report";

            var exceptionRecipients = ReadConfig.CommonCloudCoreApplicationSettings.ExceptionRecipients;
            var recipients = new List<EmailRecipient>();
            for (int index = 0; index < exceptionRecipients.Count; index++)
            {
                recipients.Add(new EmailRecipient() { RecipientEmail = exceptionRecipients[index].RecipientAddress });
            }

            if (recipients.Any())
            {
                var globalVariables = new Dictionary<string, string>
                {
                    { "exceptioncontent", message.Replace("\n", "<br />") },
                    { "subject", "Exception Report" },
                };

                var postageAppClient = new PostageAppClient()
                {
                    TemplateName = templateName,
                    GlobalVariables = globalVariables.ToList(),
                    Recipients = recipients
                };

                postageAppClient.Send();
            }
        }

        private string FormatExceptionMessage(Exception exceptionObject, string indent = "", string userName = null)
        {
            var sb = new StringBuilder();

            if (userName != null)
            {
                sb.AppendLine("");
                sb.AppendLine(String.Format("{0}User:", indent));
                sb.AppendLine(String.Format("{0}{1}", indent, userName));
            }
            sb.AppendLine("");
            sb.AppendLine("<br/>");
            sb.AppendLine(String.Format("{0}Message:", indent));
            sb.AppendLine(String.Format("{0}{1}", indent, exceptionObject.Message));
            sb.AppendLine("");
            sb.AppendLine("<br/>");
            sb.AppendLine(String.Format("{0}Stack Trace:", indent));
            sb.AppendLine(String.Format("{0}{1}", indent, exceptionObject.StackTrace));

            if (exceptionObject.Data.Count > 0)
            {
                sb.AppendLine("<br/>");
                sb.AppendLine(String.Format("{0}Data:", indent));
                foreach (var value in exceptionObject.Data.Cast<DictionaryEntry>())
                {
                    sb.AppendLine(String.Format("{0}{1}", indent, value.Value.ToString()));
                }
            }

            if (exceptionObject.InnerException != null)
            {
                sb.Append(FormatExceptionMessage(exceptionObject.InnerException, indent += "    ", null));
            }

            return sb.ToString();
        }
    }
}
