using System.Collections.Generic;

namespace Frameworkone.ThirdParty.PostageApp
{
    public class PostageAppMessage
    {
        public PostageAppMessage()
        {
            TemplateName = string.Empty;
            Recipients = new List<EmailRecipient>();
            GlobalVariables = new Dictionary<string, string>();
            Attachments = new List<PostageAttachment>();
        }

        public string TemplateName { get; set; }
        public List<EmailRecipient> Recipients { get; set; }
        public Dictionary<string, string> GlobalVariables { get; set; }
        public List<PostageAttachment> Attachments { get; set; }
    }
}