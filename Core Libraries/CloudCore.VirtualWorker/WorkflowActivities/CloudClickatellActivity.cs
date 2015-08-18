using System;
using CloudCore.Configuration.ConfigFile;
using Frameworkone.ThirdParty.Clickatell;

namespace CloudCore.VirtualWorker.WorkflowActivities
{
    public abstract class CloudClickatellActivity : BaseActivity
    {
        public virtual void HandleException(Exception ex) { throw new ActivityException(string.Format("Activity Exception Unhadled : {0}", ex.Message), ex); }
        public abstract ClickatellMessage Execute();

        public override sealed void OnVirtualWork()
        {
            try
            {
                var message = Execute();

                if (message != null)
                {
                    var smsService = new ClickatellClient();
                    smsService.Send(message.RecipientNumber, message.MessageContent);
                }
                else throw new ClickatellException(string.Format("The return result for the execution of {0} of type {1} can not be null.", this, typeof(CloudClickatellActivity)));
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
    }
}
