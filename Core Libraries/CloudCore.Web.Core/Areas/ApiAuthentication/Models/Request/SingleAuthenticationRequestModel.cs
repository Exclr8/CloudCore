using CloudCore.Api.Models;

namespace CloudCore.Web.Core.Areas.ApiAuthentication.Models.Request
{
    public class SingleAuthenticationRequestModel
    {
        public ApplicationAuthorization ApplicationData { get; set; }
        public UserAuthorization UserData { get; set; }
    }
}
