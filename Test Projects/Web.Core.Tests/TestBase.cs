using CloudCore.Web.Core.BaseControllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Web.Core.Tests
{
    public abstract class BaseControllerTest<T> where T : CoreController
    {
        protected T Controller;

        [TestInitialize]
        public void Init()
        {
            Controller = MockHelper.MockController<T>();
            Controller.TempData = MockHelper.MockControllerTempData();
        }
    }

    public abstract class BaseMailManControllerTest<T> where T : CoreController
    {
        protected T Controller;

        [TestInitialize]
        public void Init()
        {
            Controller = MockHelper.MockControllerWithMailMan<T>();
            Controller.TempData = MockHelper.MockControllerTempData();
        }
    }
}
