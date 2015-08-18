using AutoMapper;
using CloudCore.Core.DependencyResolution;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.Admin.Tests
{
    [TestClass]
    public class AdminMapperTest
    {
        [TestInitialize]
        public void Initialise()
        {
            IoC.Initialize();
        }

        [TestMethod]
        public void CanMapModelsToDomain()
        {
            CoreAdminModule.ConfigureModelMappings();

            Mapper.AssertConfigurationIsValid();
        }
    }
}
