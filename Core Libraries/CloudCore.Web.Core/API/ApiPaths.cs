
// ReSharper disable once CheckNamespace
namespace CloudCore.Api
{
    public static class ApiPaths
    {
        public static readonly string SingleAuthenticate = "api/core/Authentication/SingleAuthenticate";

        public static class Application
        {
            public const string Authorize = "api/core/Authentication/Authorize";
            public const string Details = "api/core/Authentication/ApplicationDetails";
            public const string UserResetPassword = "api/core/Authentication/ResetPassword";
            public const string UserLogin = "api/core/Authentication/Login";

        }

        public static class User
        {
            public const string Details = "api/core/Authentication/UserDetails";
            public const string ChangePassword = "api/core/Authentication/ChangePassword";
        }
    }
}
