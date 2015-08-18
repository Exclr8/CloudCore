using System.Collections.Generic;

using CloudCore.Domain.Workflow;


namespace CloudCore.Web.Core.Workflow
{
    public interface ICampaignQuery 
    {
        int CampaignId { get; set; }

        IEnumerable<Campaign> Execute(string searchValue);

        void SetFilter(IList<string> listTypes);
    }
}