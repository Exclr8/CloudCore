using CloudCore.Admin.Classes.CachedReusableObjects;
using CloudCore.Web.Core.BaseModels;

namespace CloudCore.Admin.Classes.FormObjects
{
    public class SubProcessForm : BaseContextModel
    {
        public SubProcessCachedReusableObject ActiveSubProcessDetails = SubProcessCachedReusableObject.LoadFromCache();

        public int SubProcessId
        {
            get
            {
                return ActiveSubProcessDetails.SubProcessId;
            }
            set
            {
                Key = value;
            }
        }

        protected override void OnKeyChanged(long key)
        {
            AddKeyed(ActiveSubProcessDetails, key);
            base.OnKeyChanged(key);
        }
    }
}