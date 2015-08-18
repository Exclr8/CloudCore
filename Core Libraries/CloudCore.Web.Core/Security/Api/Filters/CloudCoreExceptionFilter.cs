using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Web.Http.Filters;

namespace CloudCore.Web.Core.Security.Api.Filters
{
    public class CloudCoreExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            HttpResponseMessage responseMessage;

            if (context.Exception is SecurityException)
            {
                responseMessage = context.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, context.Exception.Message, context.Exception);
            }
            else if (context.Exception is NotImplementedException)
            {
                responseMessage = context.Request.CreateErrorResponse(HttpStatusCode.NotImplemented, context.Exception.Message, context.Exception);

            }
            else if (context.Exception is ArgumentException)
            {
                responseMessage = context.Request.CreateErrorResponse(HttpStatusCode.BadRequest, context.Exception.Message, context.Exception);
            }
            else if (context.Exception is FileNotFoundException)
            {
                responseMessage = context.Request.CreateErrorResponse(HttpStatusCode.NotFound, context.Exception.Message, context.Exception);
            }
            else
            {
                responseMessage = context.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, context.Exception.Message, context.Exception);
            }

            context.Response = responseMessage;

            base.OnException(context);
        }
    }

    [Obsolete("This attribute will be renamed to CloudCoreExceptionFilter in the future.")]
    public class SecurityExceptionFilter : CloudCoreExceptionFilter
    {

    }
}