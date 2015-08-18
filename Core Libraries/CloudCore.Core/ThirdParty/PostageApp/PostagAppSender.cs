using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;

namespace Frameworkone.ThirdParty.PostageApp
{
    /**
    * PostageApp Class
    *
    * Permits email to be sent via PostageApp service
    *
    * @package PostageApp
    * @author David Jackson, Link Digital (http://www.linkdigital.ca)
    * @Contributors, Exclr8 (http://www.exclr8.co.za) 
    * @link http://postageapp.com, http://help.postageapp.com/kb/api/, https://github.com/linkdigital/CSharp_PostageApp
    */
    internal class PostagAppSender
    {
        public string ApiKey;
        public bool Secure;
        public string Host = "api.postageapp.com";
        public string Version = "1.0.0";
        //public string RecipientOverride;
        private readonly Dictionary<string, object> arguments = new Dictionary<string, object>();
        private bool isDuplicateAllowed = true;

        /**
        * Constructor - Sets PostageApp Preferences
        *
        * The constructor can be passed an array of config values
        */
        internal PostagAppSender(string apiKey, bool secure = true)
        {
            ApiKey = apiKey;
            Secure = secure;
        }

        internal PostagAppSender(string apiKey, string baseUrl)
        {
            ApiKey = apiKey;
            string serviceUrl = baseUrl;
            Secure = serviceUrl.StartsWith("https", StringComparison.CurrentCultureIgnoreCase);
            if (serviceUrl.StartsWith("http", StringComparison.CurrentCultureIgnoreCase))
            {
                int lastHostStringIndex = serviceUrl.LastIndexOf("/", StringComparison.Ordinal);
                int subStringLength;

                if (lastHostStringIndex <= 7)
                    subStringLength = serviceUrl.Length - (Secure ? 8 : 7);
                else
                    subStringLength = serviceUrl.IndexOf("/", 9, StringComparison.Ordinal) - (Secure ? 8 : 7);

                Host = serviceUrl.Substring(Secure ? 8 : 7, subStringLength);
            }
        }

        /**
        * Setting arbitrary message headers. You may set from, subject, etc here
        *
        * @access  public
        * @return  void
        */
        internal void Headers(Dictionary<string, string> headers)
        {
            arguments.Add("headers", headers);
        }

        /**
        * Setting Subject Header
        *
        * @access  public
        * @return  void
        */
        internal void Subject(string subject)
        {
            if (arguments.ContainsKey("headers"))
            {
                var headers = (Dictionary<string, string>)arguments["headers"];
                if (headers.ContainsKey("subject"))
                {
                    headers["subject"] = subject;
                }
                else
                {
                    headers.Add("subject", subject);
                }
                arguments["headers"] = headers;
            }
            else
            {
                var headers = new Dictionary<string, string> {{"subject", subject}};
                arguments.Add("headers", headers);
            }
        }

        /**
        * Setting From header
        *
        * @access  public
        * @return  void
        */
        internal void From(string from)
        {
            if (arguments.ContainsKey("headers"))
            {
                var headers = (Dictionary<string, string>)arguments["headers"];
                if (headers.ContainsKey("from"))
                {
                    headers["from"] = from;
                }
                else
                {
                    headers.Add("from", from);
                }
                arguments["headers"] = headers;
            }
            else
            {
                var headers = new Dictionary<string, string> {{"from", @from}};
                arguments.Add("headers", headers);
            }
        }

        /**
        * Setting Recipients. Accepted formats for $to are (see API docs):
        *   a single recipient -> 'recipient@example.com'
        *   a single recipient -> 'John Doe <recipient@example.com>'
        *   multiple recipients who can see each others email addresses -> 'recipient1@example.com, recipient2@example.com'
        * @access  public
        * @return  void
        */
        internal void To(string to)
        {
            arguments.Add("recipients", to);
        }

        /**
        * Setting Recipients. Accepted formats for $to are (see API docs):
        *  multiple recipients who can't see each other email addresses
        *     List<string> recipients = new List<string>();
        *     recipients.Add("recipient1@example.com");
        *     recipients.Add("recipient2@example.com");
        * @access  public
        * @return  void
        */
        internal void To(List<string> to)
        {
            arguments.Add("recipients", to);
        }

        /// <summary>
        /// /*
        ///  * Setting Recipients. Accepted formats for $to are (see API docs):
        ///  *  multiple recipients who can't see each other email addresses with variables
        ///  *     Dictionary<string, Dictionary<string, string>> recipients = new Dictionary<string, Dictionary<string, string>>();
        ///  *     recipients.Add("recipient1@example.com", new Dictionary<string, string>(){{"variable_1", "value"},{"variable_2", "value"} });
        ///  *     recipients.Add("recipient2@example.com", new Dictionary<string, string>() { { "variable_1", "value" }, { "variable_2", "value" } });
        ///  * @access  public
        ///  * @return  void
        ///  */
        /// </summary>
        internal void To(Dictionary<string, Dictionary<string, string>> to)
        {
            arguments.Add("recipients", to);
        }

        /**
        * Setting message body. One or both text and html content can be set using:
        *   Dictionary<string, string>() {
        *    'text/html'   => 'HTML Content,
        *    'text/plain'  => 'Plain Text Content
        *   };
        *
        * @access  public
        * @return  void
        */
        internal void Message(Dictionary<string, string> message)
        {
            if (arguments.ContainsKey("content"))
            {
                arguments["content"] = message;
            }
            else
            {
                arguments.Add("content", message);
            }
        }

        internal void Attach(string filename, byte[] fileContent)
        {
            Dictionary<string, Dictionary<string, string>> attachments;

            if (arguments.ContainsKey("attachments"))
            {
                attachments = arguments["attachments"] as Dictionary<string, Dictionary<string, string>>;
            }
            else
            {
                attachments = new Dictionary<string, Dictionary<string, string>>();
            }

            var fileValues = new Dictionary<string, string>
            {
                {"content_type", "application/octet-stream"},
                {"content", Convert.ToBase64String(fileContent)}
            };

            if (attachments != null)
            {
                attachments.Add(filename, fileValues);

                if (arguments.ContainsKey("attachments"))
                {
                    arguments["attachments"] = attachments;
                }
                else
                {
                    arguments.Add("attachments", attachments);
                }
            }
        }

        /**
        * Setting PostageApp project template
        *
        * @access  public
        * @return  void
        */
        internal void Template(string template)
        {
            if (arguments.ContainsKey("template"))
            {
                arguments["template"] = template;
            }
            else
            {
                arguments.Add("template", template);
            }
        }

        /**
        * Setting  message variables
        *
        * @access  public
        * @return  void
        */
        internal void Variables(Dictionary<string, string> variables)
        {
            if (arguments.ContainsKey("variables"))
            {
                arguments["variables"] = variables;
            }
            else
            {
                arguments.Add("variables", variables);
            }
        }

        /**
        * Content that gets sent in the API call
        *
        * @access  public
        * @return  array
        */
        internal Dictionary<string, object> Payload(string uid = null)
        {
            if (uid == null && isDuplicateAllowed)
            {
                uid = GenerateUid(DateTime.Now);
            }
            
            var payload = new Dictionary<string, object>
            {
                {"api_key", ApiKey},
                {"uid", uid},
                {"arguments", arguments}
            };
            //if (!string.IsNullOrEmpty(RecipientOverride))
            //{
            //    payload.Add("recipient_override", RecipientOverride);
            //}
            return payload;
        }

        /**
        * Send Email message via PostageApp
        *
        * @url: http://help.postageapp.com/kb/api/send_message
        * @access:  public
        * @return  Response object
        */
        internal Response Send()
        {

            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(Payload());
            return Request("send_message.json", json);
        }

        /**
        * Get Account Info
        * @desc: Provides information about the account.
        * @url: http://help.postageapp.com/kb/api/get_account_info
        * @access:  public
        * @return:  Response object
        */
        internal Response GetAccountInfo()
        {
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(Payload());

            return Request("get_account_info.json", json);
        }

        /**
        * Get Message Receipt
        * @desc: Confirm that message with a particular UID exists
        * @params:  _uid - unique email identifier of the message
        * @url: http://help.postageapp.com/kb/api/get_message_receipt
        * @access:  public
        * @return:  Response object
        */
        internal Response GetMessageReceipt(string uid)
        {
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(Payload(uid));

            return Request("get_message_receipt.json", json);
        }

        /**
        * Get Message Transmissions
        * @desc: To get data on individual recipients' delivery and open status, 
        * 		you can pass a particular message UID and receive a JSON encoded
        * 		set of data for each recipient within that message.
        * @params:  _uid - unique email identifier of the message
        * @url: http://help.postageapp.com/kb/api/get_message_transmissions
        * @access:  public
        * @return:  Response object
        */
        internal Response GetMessageResponse(string messageId)
        {
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(Payload(messageId));

            return Request("get_message_transmissions.json", json);
        }

        /**
        * Get Messages
        * @desc: Gets a list of all message UIDs within your project, for subsequent
        * use in collection statistics or open rates.
        * @url: http://help.postageapp.com/kb/api/get_messages
        * @access:  public
        * @return:  Response object
        */
        internal Response GetMessages()
        {
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(Payload());

            return Request("get_messages.json", json);
        }

        /**
        * Get Method List
        * @desc: Get a list of all available api methods.
        * @url: http://help.postageapp.com/kb/api/get_method_list
        * @access:  public
        * @return:  Response object
        */
        internal Response GetMethodList()
        {
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(Payload());

            return Request("get_method_list.json", json);
        }

        /**
        * Get Metrics
        * @desc: Gets data on aggregate delivery and open status for a project,
        * 		broken down by current hour, current day, current week, current 
        * 		month with the previous of each as a comparable.
        * @url: http://help.postageapp.com/kb/api/get_metrics
        * @access:  public
        * @return:  Response object
        */
        internal Response GetMetrics()
        {
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(Payload());

            return Request("get_metrics.json", json);
        }

        /**
        * Get Project Info
        * @desc: Provides information about the project. e.g. urls, transmissions, users.
        * @url: http://help.postageapp.com/kb/api/get_project_info
        * @access:  public
        * @return:  Response object
        */
        internal Response GetProjectInfo()
        {
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(Payload());

            return Request("get_project_info.json", json);
        }

        /**
        * Returns the raw JSON request
        *
        * @access  public
        * @return  json string
        */
        internal string ShowRequest()
        {
            string protocol = Secure ? "https" : "http";
            string uri = protocol + "://" + Host + "/v.1.0/";

            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(Payload());
            return uri + " " + json;
        }

        private Response Request(string apiMethod, string content)
        {
            string protocol = Secure ? "https" : "http";
            string uri = protocol + "://" + Host + "/v.1.0/" + apiMethod;

            StreamWriter paStream = null;

            var paRequest = (HttpWebRequest)WebRequest.Create(uri);
            paRequest.ContentLength = Encoding.UTF8.GetByteCount(content);
            paRequest.ContentType = "application/json";
            paRequest.UserAgent = "POSTAGEAPP-C# " + Version;
            paRequest.Method = "POST";

            try
            {
                paStream = new StreamWriter(paRequest.GetRequestStream());
                paStream.Write(content);
            }
            catch (Exception paEx)
            {
                return new Response(paEx);
            }
            finally
            {
                if (paStream != null) paStream.Close();
            }

            try
            {
                var paResponse = (HttpWebResponse)paRequest.GetResponse();
                using (var sr = new StreamReader(paResponse.GetResponseStream()))
                {
                    string result = sr.ReadToEnd();
                    sr.Close();

                    return new Response(result);
                }

            }
            catch (Exception paEx)
            {
                return new Response(paEx);
            }
        }

        private static string GenerateUid(DateTime dateTime)
        {
            var date = (dateTime - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds;

            byte[] data = Encoding.UTF8.GetBytes(date.ToString(CultureInfo.InvariantCulture));
            var cryptoTransformSha1 = new SHA1CryptoServiceProvider();
            return BitConverter.ToString(cryptoTransformSha1.ComputeHash(data)).Replace("-", "");
        }


        internal void AllowDuplicate(bool isAllowed)
        {
            isDuplicateAllowed = isAllowed;
        }
    }

    public class Response
    {
        public string Uid { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string Json { get; set; }
        public Dictionary<string, object> Data { get; set; }

        public Response(string json)
        {
            Json = json;
            Dictionary<string, object> fullResponse = Deserialize(Json);

            var response = (Dictionary<string, object>)fullResponse["response"];
            if (response.ContainsKey("uid"))
            {
                Uid = (string)response["uid"];
            }
            if (response.ContainsKey("status"))
            {
                Status = (string)response["status"];
            }
            else
            {
                Status = string.Empty;
            }

            Data = (Dictionary<string, object>)fullResponse["data"];
        }

        public Response(Exception json)
        {
            Message = json.ToString();
        }

        public Dictionary<string, object> Deserialize(string json)
        {
            var jsonDeserializer = new JavaScriptSerializer();
            return jsonDeserializer.Deserialize<Dictionary<string, object>>(json);
        }

        public bool ApiSuccessfullyCalled
        {
            get
            {
                return String.IsNullOrEmpty(this.Status) ? false : this.Status.Equals("ok", StringComparison.CurrentCultureIgnoreCase);
            }
        }
    }

}