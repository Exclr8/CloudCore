using System;
using System.Linq;
using System.Web.Mvc;
using CloudCore.Domain;
using CloudCore.Web.Core.Caching.CachedReusableObjects;

using CloudCore.Data;
using System.Data.Linq;

namespace CloudCore.Admin.Classes.CachedReusableObjects
{
    public class UserCachedReusableObject : BaseCachedReusableObject<UserCachedReusableObject>
    {
        public override string GetTitle()
        {
            return "User Details";
        }

        public override void AddContent(CROContent content, UrlHelper urlHelper)
        {
            content.AddHtmlContent("Login", Login);
            content.AddHtmlContent("Full Name", FullName);
            content.AddHtmlContent("Cell Number", CellNumber);
            content.AddEmailContent("Email", Email, Email);
            content.AddHtmlContent("Internal Access", (InternalAccess ? "Granted" : "None"));
            content.AddHtmlContent("Public Access", (ExternalAccess ? "Granted" : "None"));
            content.AddHtmlContent("System Administrator", (IsAdministrator ? "Yes" : "No"));
        }

        protected override void GetPropertyValues()
        {
            var user = CloudCoreDB.Context.Cloudcore_User.Where(a => a.UserId == UserId).Select(a => a).SingleOrDefault();

            Login = user.Login;
            FirstName = user.Firstnames;
            FullName = user.Fullname;
            Surname = user.Surname;
            CellNumber = user.CellNo;
            Email = user.Email;
            Image = user.ThumbImage != null ? user.ThumbImage.ToArray() : new byte[] { 0 };
            Initials = user.Initials;
            InternalAccess = user.IntAccess;
            ExternalAccess = user.ExtAccess;
            IsAdministrator = user.IsAdministrator;
        }

        #region Properties

        public int UserId { get { return Convert.ToInt32(Key); } }
        public string CellNumber { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public byte[] Image { get; set; }
        public string Initials { get; set; }
        public bool InternalAccess { get; set; }
        public bool ExternalAccess { get; set; }
        public bool IsAdministrator { get; set; }
        public string Login { get; set; }
        public string Surname { get; set; }
        
        #endregion

    }
}