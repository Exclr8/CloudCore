using System.Configuration;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;

namespace CloudCore.VirtualWorker.WorkflowActivities
{
    public abstract class CloudEmailActivity : BaseActivity
    {
        public abstract MailMessage Execute();

        protected SmtpSection SmtpSection { get; private set; }
        protected MailMessage MailMessage { get; private set; }
        protected SmtpClient SmtpClient { get; private set; }

        public override sealed void OnVirtualWork()
        {
            const string configSectionName = "system.net/mailSettings/smtp";

            MailMessage = Execute();

            GetSmtpSection(configSectionName);

            MailMessage.From = new MailAddress(string.IsNullOrEmpty(SmtpSection.From) ? MailMessage.From.Address : SmtpSection.From);

            SmtpClient = new SmtpClient(SmtpSection.Network.Host, SmtpSection.Network.Port)
            {
                EnableSsl = SmtpSection.Network.EnableSsl,
                Credentials = new NetworkCredential(SmtpSection.Network.UserName, SmtpSection.Network.Password)
            };

            Send();
        }

        protected void GetSmtpSection(string configSectionName)
        {
            SmtpSection = ConfigurationManager.GetSection(configSectionName) as SmtpSection;

            if (SmtpSection == null)
                throw new ConfigurationErrorsException(string.Format(@"Could not send email using Type {0}, " +
                                                                     @"because the ""{1}"" section " +
                                                                     "is missing in the virtual worker's app.config file.",
                                                        this, configSectionName));
        }

        protected virtual void Send()
        {
            SmtpClient.Send(MailMessage);
        }
    }
}
