namespace Frameworkone.ThirdParty.Clickatell
{
    public class ClickatellMessage
    {
        public string RecipientNumber { get; private set; }
        public string MessageContent { get; private set; }

        public ClickatellMessage(string recipientNumber, string messageContent)
        {
            RecipientNumber = recipientNumber;
            MessageContent = messageContent;
        }
    }
}
