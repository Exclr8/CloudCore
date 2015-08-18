using System;
using System.IO;
using System.Net;
using CloudCore.Api.Models;
using Newtonsoft.Json;

namespace CloudCore.Api.Client
{
    public abstract class ApiClientBase
    {
        public abstract string GetApiUri();

        protected WebClient WebClient { get; private set; }

        public static void IgnoreSsl()
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        }

        protected virtual void InitializeForApplicationCall()
        {
            if (WebClient != null)
            {
                WebClient.Dispose();
            }

            WebClient = new WebClient { BaseAddress = GetApiUri() };
            WebClient.Headers.Add("Content-Type", "application/json; charset=utf-8");
        }

        protected ApiToken Authorize(ApplicationAuthorization authorizeData)
        {
            var authClient = new WebClient { BaseAddress = GetApiUri() };
            authClient.Headers.Add("Content-Type", "application/json; charset=utf-8");

            return Deserialize<ApiToken>(authClient.UploadString(ApiPaths.Application.Authorize, Serialize(authorizeData)));
        }

        protected ApiToken Authenticate(UserAuthorization authorizeData, string applicationTokenName, string applicationTokenKey)
        {
            var authClient = new WebClient { BaseAddress = GetApiUri() };
            authClient.Headers.Add("Content-Type", "application/json; charset=utf-8");
            authClient.Headers.Add(applicationTokenName, applicationTokenKey);

            return Deserialize<ApiToken>(authClient.UploadString(ApiPaths.Application.UserLogin, Serialize(authorizeData)));
        }

        private string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings());
        }

        private T Deserialize<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }

        protected T UploadToWeb<T>(string apiCall, object data)
        {
            try
            {
                var uploadReply = WebClient.UploadString(apiCall, Serialize(data));
                return Deserialize<T>(uploadReply);
            }
            catch (WebException ex)
            {
                HandleWebExceptionExtract(ex);
                return default(T);
            }
        }

        protected string UploadToWeb(string apiCall, object data)
        {
            try
            {
                return WebClient.UploadString(apiCall, Serialize(data));
            }
            catch (WebException ex)
            {
                HandleWebExceptionExtract(ex);
                return null;
            }
        }

        protected T UploadToWeb<T>(string apiCall, string method, object data)
        {
            try
            {
                var uploadReply = WebClient.UploadString(apiCall, method, Serialize(data));
                return Deserialize<T>(uploadReply);
            }
            catch (WebException ex)
            {
                HandleWebExceptionExtract(ex);
                return default(T);
            }
        }

        protected string UploadToWeb(string apiCall, string method, object data)
        {
            try
            {
                return WebClient.UploadString(apiCall, method, Serialize(data));
            }
            catch (WebException ex)
            {
                HandleWebExceptionExtract(ex);
                return null;
            }
        }

        protected T DownloadFromWeb<T>(string apiCall)
        {
            try
            {
                var downloadReply = WebClient.DownloadString(apiCall);
                return Deserialize<T>(downloadReply);
            }

            catch (WebException ex)
            {
                HandleWebExceptionExtract(ex);
                return default(T);
            }
        }

        protected virtual void HandleWebExceptionExtract(WebException ex)
        {
            if (ex.Status == WebExceptionStatus.UnknownError)
            {
                if (ex.Response != null)
                    using (var reader = new StreamReader(ex.Response.GetResponseStream()))
                    {
                        var responseText = reader.ReadToEnd();
                        var obj = Deserialize<dynamic>(responseText);
                        throw new ApiException((obj["Message"]).Value);
                    }
            }
            else throw ex;
        }

    }
}
