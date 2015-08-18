using System.Collections.Generic;

namespace Frameworkone.ThirdParty.PostageApp
{
    public class EmailRecipient
    {
        public EmailRecipient()
        {
            MailVariables = new Dictionary<string, string>();
        }

        public string RecipientEmail { get; set; }
        public Dictionary<string, string> MailVariables { get; set; }
    }
}