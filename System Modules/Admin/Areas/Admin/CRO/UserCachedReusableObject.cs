using System.Web.Mvc;
using CloudCore.Domain;
using CloudCore.Web.Core.Caching.CachedReusableObjects;

using System;
using CloudCore.Data;
using System.Linq;

namespace CloudCore.Admin.Areas.Admin.CRO
{
    public class UserCachedReusableObject : BaseCachedReusableObject<UserCachedReusableObject>
    {
        public override string GetTitle()
        {
            return "User Details";
        }

        public override void AddContent(CROContent content, UrlHelper url)
        {
            content.AddHtmlContent("Login", this.Login);
            content.AddHtmlContent("Full Name", this.FullName);
            content.AddHtmlContent("Cell Number", this.CellNumber);
            content.AddEmailContent("Email", this.Email, this.Email);
            content.AddHtmlContent("Internal Access", (this.InternalAccess ? "Granted" : "None"));
            content.AddHtmlContent("External Access", (this.ExternalAccess ? "Granted" : "None"));
        }

        protected override void GetPropertyValues()
        {
            CloudCoreDB database = CloudCoreDB.Context;
            var result = (database.Cloudcore_User).Where(a => a.UserId == UserId).Select(a => a).SingleOrDefault();

            Login = result.Login;
            FirstName = result.Firstnames;
            FullName = result.Fullname;
            Surname = result.Surname;
            CellNumber = result.CellNo;
            Email = result.Email;
            Image = result.ThumbImage != null ? result.ThumbImage.ToArray() : new byte[] { 0 };
            Initials = result.Initials;
            InternalAccess = result.IntAccess;
            ExternalAccess = result.ExtAccess;
            IsAdministrator = result.IsAdministrator;
        }
        #region Properties

        public int UserId { get { return Convert.ToInt32(Key); } }
        public string CellNumber { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; private set; }
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