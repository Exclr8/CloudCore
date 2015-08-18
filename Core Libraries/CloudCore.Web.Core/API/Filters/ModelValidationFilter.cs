using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;

namespace CloudCore.Web.Core.Api.Filters
{
    public class ModelValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                // Return the validation errors in the response body.
                var errors = new Dictionary<string, IEnumerable<string>>();
                //string key;
                foreach (KeyValuePair<string, ModelState> keyValue in actionContext.ModelState)
                {
                    //key = keyValue.Key.Substring(keyValue.Key.IndexOf('.') + 1);
                    errors[keyValue.Key] = keyValue.Value.Errors.Select(e => e.ErrorMessage);
                }
                //var errors = actionContext.ModelState
                //    .Where(e => e.Value.Errors.Count > 0)
                //    .Select(e => new Error
                //    {
                //        Name = e.Key,
                //        Message = e.Value.Errors.First().ErrorMessage
                //    }).ToArray();

                actionContext.Response =
                    actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }
    }
}