using System;
using System.Configuration;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using CloudCore.VirtualWorker.WorkflowActivities;
using Frameworkone.UnitTestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.VirtualWorker.Tests.WorkFlowActivities
{
    [TestClass]
    public class CloudEmailActivityTests
    {
        private CloudEmailActivityTestClass cloudEmailActivityTestClass;

        [TestInitialize]
        public void Init()
        {
            cloudEmailActivityTestClass = new CloudEmailActivityTestClass();
            cloudEmailActivityTestClass.OnVirtualWork();
        }

        [TestMethod]
        public void CanCreateMailMessage()
        {
            var mailMessage = cloudEmailActivityTestClass.GetMailMessage();

            Assert.IsNotNull(mailMessage);
        }

        [TestMethod]
        public void MailAddressFromIsFromSmtpSection()
        {
            var mailMessage = cloudEmailActivityTestClass.GetMailMessage();

            Assert.AreEqual(new MailAddress("test@frameworkone.co.za"), mailMessage.From);
        }

        [TestMethod]
        public void GetsSmtpSectionCorrectly()
        {
            var smtpSection = cloudEmailActivityTestClass.GetSmtpSection();

            Assert.IsNotNull(smtpSection);
            Assert.AreEqual("password", smtpSection.Network.Password);
            Assert.AreEqual("username", smtpSection.Network.UserName);
            Assert.AreEqual("localhost", smtpSection.Network.Host);
            Assert.AreEqual(25, smtpSection.Network.Port);
            Assert.IsTrue(smtpSection.Network.EnableSsl);
            Assert.AreEqual(SmtpDeliveryFormat.SevenBit, smtpSection.DeliveryFormat);
            Assert.AreEqual("test@frameworkone.co.za", smtpSection.From);
        }

        [TestMethod]
        public void GetsSmtpClientCorrectly()
        {
            var smtpClient = cloudEmailActivityTestClass.GetSmtpClient();

            Assert.IsNotNull(smtpClient);
            Assert.IsTrue(smtpClient.EnableSsl);
            Assert.IsNotNull(smtpClient.Credentials);
        }

        [TestMethod]
        [ExpectedException(typeof(ConfigurationErrorsException))]
        public void HandlesSmtpSectionNullException()
        {
            cloudEmailActivityTestClass.DoSetSmtpSection();
        }
    }

    public class CloudEmailActivityTestClass : CloudEmailActivity
    {

        public override MailMessage Execute()
        {
            return new MailMessage("lyb@frameworkone.co.za", "jhr@frameworkone.co.za");
        }

        public MailMessage GetMailMessage()
        {
            return this.MailMessage;
        }

        public SmtpSection GetSmtpSection()
        {
            return this.SmtpSection;
        }

        public SmtpClient GetSmtpClient()
        {
            return this.SmtpClient;
        }

        public void DoSetSmtpSection()
        {
            this.GetSmtpSection("");
        }

        protected override void Send()
        {
        }
    }
}
