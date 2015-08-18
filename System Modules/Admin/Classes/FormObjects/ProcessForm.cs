using CloudCore.Admin.Classes.CachedReusableObjects;
using CloudCore.Web.Core.BaseModels;

namespace CloudCore.Admin.Classes.FormObjects
{
    public class ProcessForm : BaseContextModel
    {
        public ProcessCachedReusableObject ActiveProcessDetails = ProcessCachedReusableObject.LoadFromCache();

        public int ProcessRevisionId
        {
            get
            {
                return ActiveProcessDetails.ProcessRevisionId;
            }

            set
            {
                Key = value;
            }
        }

        protected override void OnKeyChanged(long key)
        {
            AddKeyed(ActiveProcessDetails, key);
            base.OnKeyChanged(key);
        }
    }
}