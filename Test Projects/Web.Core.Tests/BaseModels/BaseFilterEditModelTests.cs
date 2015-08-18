using System.Collections.Generic;
using System.Web.Mvc;
using CloudCore.Web.Core.BaseModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Web.Core.Tests.BaseModels
{
    [TestClass]
    public class BaseFilterEditModelTests
    {
        [TestMethod]
        public void CanGetFilterOptions()
        {
            var filterEditModel = new FilterEditModel();

            var expectedFilterOptions = new List<SelectListItem> 
                       {
                            new SelectListItem {Text = @"contains", Value = "%{0}%"},
                            new SelectListItem {Text = @"starts with", Value = "{0}%"},
                            new SelectListItem {Text = @"matches", Value = "{0}"},
                       };

            Assert.AreEqual(expectedFilterOptions.Count, filterEditModel.FilterOptions.Count);
            var b = 0;

            foreach (var expectedFilterOption in expectedFilterOptions)
            {
                Assert.AreEqual(expectedFilterOption.Text, filterEditModel.FilterOptions[b].Text);
                Assert.AreEqual(expectedFilterOption.Value, filterEditModel.FilterOptions[b].Value);
                b++;
            }
        }
    }
}
