using CloudCore.Configuration.ConfigFile;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Frameworkone.ThirdParty.PostageApp
{
    public class PostageAppClient
    {

        public PostageAppClient()
        {

            Recipients = new List<EmailRecipient>();
            GlobalVariables = new List<KeyValuePair<string, string>>();
            Attachments = new List<PostageAttachment>();
        }

        public List<EmailRecipient> Recipients { get; set; }
        public string TemplateName { get; set; }
        public bool AllowDuplicates { get; set; }

        public List<PostageAttachment> Attachments { get; set; }

        public List<KeyValuePair<string, string>> GlobalVariables { get; set; }

        public Response Send()
        {
            var ApiKey = ReadConfig.CommonCloudCoreApplicationSettings.Services.Postage.ApiKey;

            if (Recipients.Count == 0)
                throw new Exception("Cannot send PostageApp e-mail. No recipients specified.");

            var postageAppSender = new PostagAppSender(ApiKey, "https://api.postageapp.com/v.1.0/send_message.json");

            if (Recipients.Any(r => r.MailVariables.Count > 0))
            {
                var newRecipientListWithVariables = Recipients.Distinct().Where(r => r.MailVariables.Count > 0).ToDictionary(r => r.RecipientEmail, r => r.MailVariables);
                postageAppSender.To(newRecipientListWithVariables);
            }
            else
            {
                var newRecipientListWithoutVariables = Recipients.Distinct().Where(r => r.MailVariables.Count == 0).Select(r => r.RecipientEmail).ToList();
                postageAppSender.To(newRecipientListWithoutVariables);
            }

            postageAppSender.Template(TemplateName);
            postageAppSender.Variables(GlobalVariables.Select(v => new { v.Key, v.Value }).ToDictionary(v => v.Key, v => v.Value));

            if (Attachments != null)
                foreach (var attachment in Attachments)
                    postageAppSender.Attach(attachment.FileName, attachment.File);

            if (AllowDuplicates)
            {
                postageAppSender.AllowDuplicate(true);
            }

            Response response = postageAppSender.Send();

            if (!response.ApiSuccessfullyCalled)
                throw new Exception(response.Message);

            return response;
        }

        public Response GetMessageResponse(string messageId)
        {
            var ApiKey = ReadConfig.CommonCloudCoreApplicationSettings.Services.Postage.ApiKey;

            var postageAppSender = new PostagAppSender(ApiKey, "https://api.postageapp.com/v.1.0/get_message_transmissions.json");
            postageAppSender.AllowDuplicate(false);
            Response response = postageAppSender.GetMessageResponse(messageId);

            return response;
        }

        public Response SendResetPasswordEmail(string recipient, string emailLinkUrlScheme, string emailLinkUrlAuthority, Guid referenceGuid)
        {
            var resetPasswordUrl = string.Format("{0}://{1}/CUI/Login/ResetPassword?Reference={2}", emailLinkUrlScheme, emailLinkUrlAuthority, referenceGuid);

            this.Recipients.Add(new EmailRecipient { RecipientEmail = recipient });
            this.GlobalVariables.Add(new KeyValuePair<string, string>("resetpasswordurl", resetPasswordUrl));
            this.TemplateName = "resetpassword";

            return this.Send();
        }
    }
}