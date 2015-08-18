using System;

namespace CloudCore.Web.Core.Caching
{
    [Serializable]
    public struct TaskQuery
    {
        public string Title { get; set; }
        public string ListId { get; set; }
    }
}