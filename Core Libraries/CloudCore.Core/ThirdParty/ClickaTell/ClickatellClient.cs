using CloudCore.Configuration.ConfigFile;
using System;
using System.IO;
using System.Net;

namespace Frameworkone.ThirdParty.Clickatell
{
    public class ClickatellClient
    {
        private WebClient client;


        public void Send(string cellNumber, string message)
        {

            var apiKey = ReadConfig.CommonCloudCoreApplicationSettings.Services.Clickatell.APIKey;
            var username = ReadConfig.CommonCloudCoreApplicationSettings.Services.Clickatell.Username;
            var password = ReadConfig.CommonCloudCoreApplicationSettings.Services.Clickatell.Password;

            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ClickatellException("ApiKey does not have a value");

            if (string.IsNullOrWhiteSpace(username))
                throw new ClickatellException("Username does not have a value");

            if (string.IsNullOrWhiteSpace(password))
                throw new ClickatellException("Password does not have a value");

            if (string.IsNullOrWhiteSpace(cellNumber))
                throw new ClickatellException("Number does not have a value");

            if (string.IsNullOrWhiteSpace(message))
                throw new ClickatellException("Message does not have a value");

            CleanWebClient();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR1.0.3705;)");
            client.QueryString.Add("user", username);
            client.QueryString.Add("password", password);
            client.QueryString.Add("api_id", apiKey);
            client.QueryString.Add("to", cellNumber);
            client.QueryString.Add("text", message);
            SendMessage();
        }

        private void CleanWebClient()
        {
            if (client != null)
                client.Dispose();

            client = new WebClient();
        }


        private void SendMessage()
        {
            string result;
            try
            {
                var data = client.OpenRead(@"http://api.clickatell.com/http/sendmsg");
                var reader = new StreamReader(data);
                result = reader.ReadToEnd();
                data.Close();
                reader.Close();

            }
            catch (WebException ex)
            {
                throw new ClickatellException(string.Format("The Internet connection is broken: {0}", ex.Message));
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            ValidateResult(result);
        }

        public virtual void ValidateResult(string result)
        {
            if (result.ToLower().StartsWith("err:"))
            {
                throw new ClickatellException(string.Format("Could not send Clickatell message. Clickatell returned the following result: {0}", result));
            }
        }

    }
}
