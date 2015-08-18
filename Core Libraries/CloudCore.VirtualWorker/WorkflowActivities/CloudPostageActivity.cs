using CloudCore.Configuration.ConfigFile;
using Frameworkone.ThirdParty.PostageApp;

namespace CloudCore.VirtualWorker.WorkflowActivities
{
    public abstract class CloudPostageActivity : BaseActivity
    {
        protected PostageAppClient PostageAppClient { get; private set; }
        protected PostageAppMessage PostageAppMessage { get; private set; }
        protected Response Response { get; private set; }
        public abstract PostageAppMessage Execute();     

        public override sealed void OnVirtualWork()
        {
            PostageAppMessage = Execute();

            PostageAppClient = new PostageAppClient()
            {
                TemplateName = PostageAppMessage.TemplateName
            };

            if (PostageAppMessage.GlobalVariables != null)
            {
                if (PostageAppMessage.GlobalVariables.Count > 0)
                    PostageAppClient.GlobalVariables.AddRange(PostageAppMessage.GlobalVariables);
            }

            if (PostageAppMessage.Attachments != null)
            {
                if (PostageAppMessage.Attachments.Count > 0)
                    PostageAppClient.Attachments.AddRange(PostageAppMessage.Attachments);
            }

            PostageAppClient.Recipients.AddRange(PostageAppMessage.Recipients);
            Response = Send();

            OnMessageSent();
        }

        public virtual void OnMessageSent() { }

        protected virtual Response Send()
        {
            return PostageAppClient.Send();
        }
    }
}
