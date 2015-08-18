using System.Web.Mvc;
using CloudCore.Web.Core.BaseControllers;
using CloudCore.WebModuleTest.Models;
using Frameworkone.Domain;

namespace CloudCore.Activities.Controllers
{
    // ReSharper disable once InconsistentNaming
    public partial class _7c293d3f_bad7_445d_8935_ea78a94421cdController : ProcessBaseController
    {
        //Load action for View
        public _7c293d3f_bad7_445d_8935_ea78a94421cdController(IRepository repository) : base(repository) { }

        public ActionResult _c9e8e0c2_06ef_4dc1_b51c_9ca6ad1c6d46(long instanceId, long keyValue)
        {
            var model = new _c9e8e0c2_06ef_4dc1_b51c_9ca6ad1c6d46Model();
            model.InstanceId = instanceId;

            return View(model);
        }

        //Submit action for View
        [HttpPost]
        public ActionResult _c9e8e0c2_06ef_4dc1_b51c_9ca6ad1c6d46(long instanceId, long keyValue, _c9e8e0c2_06ef_4dc1_b51c_9ca6ad1c6d46Model model)
        {
            // Your Code to save data here

            return FlowNavigate();
        }
    }
}