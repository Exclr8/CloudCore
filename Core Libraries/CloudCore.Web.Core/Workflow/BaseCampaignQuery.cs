using System.Collections.Generic;

using CloudCore.Domain.Workflow;
using CloudCore.Web.Core.Security.Authentication;

using CloudCore.Data;
using System;
using CloudCore.Data.Buildbase;
using System.Linq;
using CloudCore.Core.Utilities;

namespace CloudCore.Web.Core.Workflow
{
    public class BaseCampaignQuery : ICampaignQuery
    {
        public virtual int CampaignId { get; set; }

        public IList<string> ListTypes { get; set; }

        public IEnumerable<Campaign> Execute(string searchValue)
        {

            SetFilter(this.ListTypes);

            var query = GetCampaigns(searchValue) ;
            return query;
        }

        public IEnumerable<Campaign> GetCampaigns(string searchValue)
        {
            var result = from x in CloudCoreDB.Context.Cloudcore_VwCampaign
                         where x.Activate < DateTime.Now
                         && x.CampaignID == this.CampaignId
                         && x.UserId == CloudCoreIdentity.UserId
                         select x;

            if (!string.IsNullOrEmpty(searchValue))
            {
                result = result.Where(r => r.KeyValue.ToString() == searchValue);
            }

            // wtf?  --------------v
            var predicate = PredicateBuilder.False<Cloudcore_VwCampaign>();

            foreach (var listType in this.ListTypes)
            {
                if (!string.IsNullOrEmpty(listType))
                {
                    predicate = predicate.Or(x => x.ListType == listType);
                }
            }

            result = result.Where(predicate);

            return result.OrderByDescending(px => px.Priority).ThenBy(ax => ax.Activate).Take(5).Select(r => new Campaign
            {
                InstanceId = r.InstanceId,
                Activate = r.Activate,
                KeyValue = r.KeyValue,
                Header = "Process:",
                SubHeader = r.SubProcessName,
                ActivityName = r.ActivityName,
                Priority = r.Priority
            });
        }

        public virtual void SetFilter(IList<string> listTypes)
        {
        }
    }
}