using CloudCore.Data.Buildbase;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Claims;
using System.Web;

namespace CloudCore.Web.Core.Security.Authentication
{
        
    public class CustomClaim
    {
        public string this[string claimType]
        {
            get
            {
                return CloudCoreIdentity.CurrentUser.FindFirst(claimType).Value;
            }
            set
            {
                ((ClaimsIdentity)CloudCoreIdentity.CurrentUser.Identity).AddClaim(new Claim(claimType, value));
            }
        }
    }

    public static class CloudCoreIdentity
    {
        public const string IntAccessClaimType = "http://frameworkone.com/claims/intaccess";
        public const string ExtAccessClaimType = "http://frameworkone.com/claims/extaccess";
        public const string IsAdministratorClaimType = "http://frameworkone.com/claims/isadministrator";
        public const string LastLoginClaimType = "http://frameworkone.com/claims/lastlogin";

        public static ClaimsPrincipal CurrentUser
        {
            get { return (HttpContext.Current.User as ClaimsPrincipal); }

        }

        public static int UserId
        {
            get { return Convert.ToInt32(CurrentUser.FindFirst(ClaimTypes.NameIdentifier).Value); }
        }

        public static string LoginGuid
        {
            get { return CurrentUser.FindFirst(ClaimTypes.Sid).Value; }
        }

        public static string Fullname
        {
            get
            {
                return string.Format(@"{0} {1}", Firstname, Surname);
            }
        }

        public static string Firstname
        {
            get { return CurrentUser.FindFirst(ClaimTypes.GivenName).Value;  }

        }

        public static string Surname
        {
            get { return CurrentUser.FindFirst(ClaimTypes.Surname).Value; }

        }

        public static string Email
        {
            get
            {
                return CurrentUser.FindFirst(ClaimTypes.Email).Value;
            }
        }

        public static bool ExternalAccess
        {
            get
            {
                return bool.Parse(CurrentUser.FindFirst(ExtAccessClaimType).Value);
            }
        }
        
        public static bool InternalAccess
        {
            get
            {
                return bool.Parse(CurrentUser.FindFirst(IntAccessClaimType).Value);
            }
        }

        public static bool IsAdministrator
        {
            get
            {
                return bool.Parse(CurrentUser.FindFirst(IsAdministratorClaimType).Value);
            }
        }

        public static DateTime LastLogin
        {
            get
            {
                return DateTime.ParseExact(CurrentUser.FindFirst(LastLoginClaimType).Value, "o", CultureInfo.InvariantCulture, DateTimeStyles.None);
            }
        }


        private static CustomClaim _customClaim = new CustomClaim();
        public static CustomClaim CustomClaim
        {
            get { return _customClaim;  }
        }

        private static IEnumerable<Claim> LoadClaimsForUser(Cloudcore_User user)
        {
            
            var loginGuid = Guid.NewGuid();

            var claims = new[]
            {
                new Claim(ClaimTypes.GivenName, user.Firstnames),
                new Claim(ClaimTypes.Surname, user.Surname),
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Sid, loginGuid.ToString()),
                new Claim(LastLoginClaimType, user.LastLogin.ToString("o")),
                new Claim(IntAccessClaimType, user.IntAccess.ToString()),
                new Claim(ExtAccessClaimType, user.ExtAccess.ToString()),
                new Claim(IsAdministratorClaimType, user.IsAdministrator.ToString())
            };
            return claims;
        }

        internal static ClaimsPrincipal GetClaimsPrincipal(Cloudcore_User user)
        {
            IEnumerable<Claim> claims = LoadClaimsForUser(user);
            var id = new ClaimsIdentity(claims, "Forms"); // as per example it seems to have to be Forms?!?!
            return new ClaimsPrincipal(id);
        }
    }
}
