using System;

namespace CloudCore.Web.Core.Caching.CachedReusableObjects
{
    [Serializable()]
    public class EmailContentItem : HtmlContentItem
    {
        public EmailContentItem()
            : base(CroContentType.Email)
        {
        }

        public string Email { get; set; }
    }
}
