using System.ComponentModel.DataAnnotations;
using CloudCore.Domain;
using CloudCore.Web.Core.BaseModels;

using CloudCore.Data;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using CloudCore.Data.Buildbase;

namespace CloudCore.Admin.Models
{
    public class SystemApplicationSearchModel : BaseSearchModel<Cloudcore_SystemApplication>
    {
        [Display(Name = "Application Name")]
        public string ApplicationName { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }

        public string FilterOptionsApplicationName { get; set; }
        public string FilterOptionsCompanyName { get; set; }
        public string FilterOptionsContactPerson { get; set; }

        public override void Search()
        {
  
            var database = CloudCoreDB.Context;

            var results = database.Cloudcore_SystemApplication.AsQueryable();

            if (!string.IsNullOrEmpty(ApplicationName))
            {
                results = results.Where(r => SqlMethods.Like(r.ApplicationName, string.Format(FilterOptionsApplicationName, ApplicationName)));
            }
            if (!string.IsNullOrEmpty(CompanyName))
            {
                results = results.Where(r => SqlMethods.Like(r.CompanyName, string.Format(FilterOptionsCompanyName, CompanyName)));
            }
            if (!string.IsNullOrEmpty(ContactPerson))
            {
                results = results.Where(r => SqlMethods.Like(r.ContactPerson, string.Format(FilterOptionsContactPerson, ContactPerson)));
            }

            this.SearchResults = results;
        }
    }
}