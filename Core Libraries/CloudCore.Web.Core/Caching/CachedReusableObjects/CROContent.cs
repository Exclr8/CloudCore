using System;
using System.Collections.Generic;

namespace CloudCore.Web.Core.Caching.CachedReusableObjects
{
    public enum CroContentType { Link, Email, Html }

    [Serializable]
    public class CROContent
    {
        

        public CROContent()
        {
            this.Items = new List<HtmlContentItem>();
        }

        public string CROTitle { get; set; }

        public void AddHtmlContent(string title, string value)
        {
            Items.Add(new HtmlContentItem(CroContentType.Html) { Title = title, Value = value });
        }

        public void AddEmailContent(string title, string value, string email)
        {
            Items.Add(new EmailContentItem() { Title = title, Value = value, Email = email });
        }

        public void AddUrlContent(string title, string value, string url)
        {
            Items.Add(new LinkContentItem() { Title = title, Value = value, Url = url });
        }


        public List<HtmlContentItem> Items { get; set; }
    }


}
