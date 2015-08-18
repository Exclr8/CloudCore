using System;

namespace CloudCore.Web.Core.Caching.CachedReusableObjects
{
    [Serializable()]
    public class LinkContentItem : HtmlContentItem
    {
        public LinkContentItem()
            : base(CroContentType.Link)
        {
        }
        public string Url { get; set; }
    }
}
