using System;
using CloudCore.Api.Models;

namespace CloudCore.Api.Client
{
    public abstract class ApplicationApiClientBase : ApiClientBase
    {
        public ApiToken ApplicationToken { get; private set; }

        public abstract string GetApiKey();

        protected override void InitializeForApplicationCall()
        {
            base.InitializeForApplicationCall();
            if ((ApplicationToken == null) || (ApplicationToken.ExpiryLocal < DateTime.Now))
            {
                ApplicationToken = Authorize(new ApplicationAuthorization { ApplicationKey = GetApiKey() });
            }

            WebClient.Headers.Add(ApplicationToken.TokenKeyName, ApplicationToken.TokenKey);
        }

        public ApplicationDetails ApplicationDetails()
        {
            InitializeForApplicationCall();
            return DownloadFromWeb<ApplicationDetails>(ApiPaths.Application.Details);
        }       
    }
}
