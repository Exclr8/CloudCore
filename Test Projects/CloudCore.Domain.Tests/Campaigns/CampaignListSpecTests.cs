using System.Collections.Generic;
using CloudCore.Domain.Specifications.Workflow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.Domain.Tests.Campaigns
{
    [TestClass]
    public class CampaignListSpecTests
    {
        [TestMethod]
        public void CampaignListSpec_CanInstantiate()
        {
            var user = new User { Id = 0 };
            const int campaignId = 124;
            const string searchValue = "";
            var listTypes = new List<string>() { string.Empty };

            var spec = new CampaignListSpec(user, campaignId, searchValue, listTypes);

            Assert.AreEqual(user, spec.Entity);
            Assert.AreEqual(campaignId, spec.CampaignId);
            Assert.AreEqual(searchValue, spec.SearchValue);
            Assert.AreEqual(listTypes, spec.ListTypes);
        }
    }
}
