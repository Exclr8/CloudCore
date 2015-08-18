using System.Collections.Generic;
using System.Linq;
using CloudCore.VirtualWorker.WorkflowActivities;
using Frameworkone.ThirdParty.PostageApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.VirtualWorker.Tests.WorkFlowActivities
{
    [TestClass]
    public class CloudPostageActivityTests
    {
        private CloudPostageActivityTestClass cloudPostageActivityTestClass;

        [TestInitialize]
        public void Init()
        {
            cloudPostageActivityTestClass = new CloudPostageActivityTestClass();
            cloudPostageActivityTestClass.OnVirtualWork();
        }

        [TestMethod]
        public void CanCreateMailMessage()
        {
            Assert.IsNotNull(cloudPostageActivityTestClass.GetPostageAppMessage());
        }

        [TestMethod]
        public void HasRecipients()
        {
            var recipients = cloudPostageActivityTestClass.GetPostageAppMessage().Recipients;
            Assert.AreEqual(3, recipients.Count);
        }

        [TestMethod]
        public void HasRecipientsWithMailVariables()
        {
            var recipientsMailVariables = cloudPostageActivityTestClass.GetPostageAppMessage().Recipients.FirstOrDefault(r => r.RecipientEmail == "test1@test.com").MailVariables;
            Assert.AreEqual(3, recipientsMailVariables.Count);
        }

        [TestMethod]
        public void HasAttachments()
        {
            var attachments = cloudPostageActivityTestClass.GetPostageAppMessage().Attachments;
            Assert.AreEqual(2, attachments.Count);
        }

        [TestMethod]
        public void HasGlobalVariables()
        {
            var globalVariables = cloudPostageActivityTestClass.GetPostageAppMessage().GlobalVariables;
            Assert.AreEqual(3, globalVariables.Count);
        }

        [TestMethod]
        public void CanSend()
        {
            Assert.IsTrue(cloudPostageActivityTestClass.HasSent);
        }
    }

    public class CloudPostageActivityTestClass : CloudPostageActivity
    {
        public bool HasSent = false;
        public override PostageAppMessage Execute()
        {
            return new PostageAppMessage
            {
                TemplateName = "templateName",
                Recipients = new List<EmailRecipient>
                {
                    new EmailRecipient{ 
                        RecipientEmail = "test1@test.com",
                        MailVariables = new Dictionary<string, string>
                        {
                            {"variable1", "value1"},
                            {"variable2", "value2"},
                            {"variable3", "value3"} 
                        }
                    },
                    new EmailRecipient{ RecipientEmail = "test2@test.com" },
                    new EmailRecipient{ RecipientEmail = "test3@test.com" },
                },
                Attachments = new List<PostageAttachment>
                {
                    new PostageAttachment(null, "fileName1"),
                    new PostageAttachment(null, "fileName2")
                },
                GlobalVariables = new Dictionary<string, string>
                {
                    {"variable1", "value1"},
                    {"variable2", "value2"},
                    {"variable3", "value3"}
                }
            };
        }

        public PostageAppMessage GetPostageAppMessage()
        {
            return PostageAppMessage;
        }

        protected override void Send()
        {
            HasSent = true;
        }
    }
}
