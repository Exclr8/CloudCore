using System.Collections.Generic;

namespace CloudCore.Web.Core.Workflow
{
    public class StartedCampaignQuery : BaseCampaignQuery
    {
        public override void SetFilter(IList<string> listTypes)
        {
            listTypes.Add("Started");
        }
    }    
}   