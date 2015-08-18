using System;
using System.Collections.Generic;
using System.Linq;


namespace CloudCore.Web.Core.BaseModels
{
    public abstract class BaseSearchModel<T> : BaseModel
    {
        public string LookupInputId { get; set; }
        public string LookupInputIdValue { get; set; }

        protected BaseSearchModel()
        {
            SearchResults = Enumerable.Empty<T>();
        }

        public IEnumerable<T> SearchResults { get; set; }

        public abstract void Search();
    }
}
