using System;
using AutoMapper;
using CloudCore.Core.DependencyResolution;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.Web.Tests.AutoMapper
{
    [TestClass]
    public class CuiMapperTest
    {
        [TestInitialize]
        public void Initialise()
        {
            IoC.Initialize();
        }

        [TestMethod]
        public void CanMapModelsToDomain()
        {
            CoreCuiModule.ConfigureModelMappings();

            Mapper.AssertConfigurationIsValid();
        }
    }
}
