using CloudCore.Api.Models;

namespace CloudCore.Web.Core.Areas.ApiAuthentication.Models.Response
{
    public class SingleAuthenticationResponseModel
    {
        public ApiToken ApplicationToken { get; set; }
        public ApiToken UserToken { get; set; }
    }
}
