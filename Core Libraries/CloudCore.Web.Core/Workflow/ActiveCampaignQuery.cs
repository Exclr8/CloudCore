using CloudCore.Domain.Specifications;

using System.Collections.Generic;

namespace CloudCore.Web.Core.Workflow
{
    public class ActiveCampaignQuery : BaseCampaignQuery
    {
        public override void SetFilter(IList<string> listTypes)
        {
            listTypes.Add("Offered");
            listTypes.Add("Allocated");
        }
    }
}