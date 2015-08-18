using System;

namespace CloudCore.Web.Core.Caching.CachedReusableObjects
{
    [Serializable()]
    public class HtmlContentItem
    {
        public HtmlContentItem(CroContentType contentType)
        {
            Type = contentType;
        }

        public CroContentType Type { get; protected set; }
        public string Title { get; set; }
        public string Value { get; set; }
    }
}
