using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CloudCore.Domain;
using CloudCore.Web.Core.BaseModels;

using CloudCore.Data;
using System.Data.Linq.SqlClient;
using System.Linq;
using CloudCore.Data.Buildbase;

namespace CloudCore.Admin.Models
{
    public class SystemValueCategorySearchModel : BaseSearchModel<Cloudcore_SystemValueCategory>
    {
        public string FilterOptions { get; set; }

        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }


        public override void Search()
        {
            var results = (CloudCoreDB.Context.Cloudcore_SystemValueCategory).AsQueryable();

            if (!string.IsNullOrEmpty(CategoryName))
            {
                results = results.Where(r => SqlMethods.Like(r.CategoryName, string.Format(FilterOptions, CategoryName.ToString().Trim())));
            }

            this.SearchResults = results;
        }

    }

    
}