using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloudCore.VSExtension.Wizards.ProjectClasses
{
    [Serializable]
    public class CloudCoreSystemSettings
    {
        public CloudCoreSystemSettings()
        {
            this.ProductName = "Product";
           
            var company = (string)Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows NT\CurrentVersion", "RegisteredOrganization", "");
            if (string.IsNullOrEmpty(company))
            {
                this.CompanyName = "Company Name";
            }
            else this.CompanyName = company;

            this.ProductVersion = "0.1.0.0";
            this.EncryptionKey = "4566783456788904";
            this.ApplicationKey = Guid.NewGuid().ToString();
            this.ConfigIsEncrypted = false;
            this.PostageUrl = "https://api.postageapp.com/v.1.0/send_message.json";
            this.ClickatellUrl = "http://api.clickatell.com/http/sendmsg";
            this.ConnectionString = "Persist Security Info=False;Integrated Security=SSPI;database=cloudcoredb;server=localhost;Connect Timeout=30";
            this.PostageEnabled = true;
            this.SmtpEnabled = true;
            this.SmtpPort = "587";
            this.SmtpHost = "pod51011.outlook.com";
            this.SmtpUser = "cloudcore@frameworkone.co.za";
            this.SmtpSSLEnabled = true;
            this.ClickatellEnabled = true;
        }

        public string ConnectionString { get; set; }
        public string DatabaseName 
        {
            get 
            {
                string connectionStringLowerCase = this.ConnectionString.ToLower();
                var searchString = "database=";
                int posA = connectionStringLowerCase.IndexOf(searchString);

                if (posA == -1)
                {
                    searchString = "initial catalogue=";
                    posA = connectionStringLowerCase.IndexOf(searchString);
                }

                var searchStringLength = searchString.Length;
                int posB = connectionStringLowerCase.IndexOf(";", posA) - 1;
                int startPos = posA + searchStringLength;
                int length = (posB - posA - searchStringLength) + 1;
                string databaseName = this.ConnectionString.Substring(startPos, length);

                return databaseName;
            }
        }

        
        public string EncryptionKey { get; set; } 
        public bool ConfigIsEncrypted { get; set; }

        public bool PostageEnabled { get; set; }
        public string PostageUrl { get; set; }
        public string PostageAPIKey { get; set; }

        public string PostageSettings()
        {
            return PostageEnabled ? string.Format(@"<postage url=""{0}"" apiKey=""{1}"" />", PostageUrl, PostageAPIKey) : "";
        }

        public string Services()
        {
            return (ClickatellEnabled || PostageEnabled) ? string.Format(@"<services>{0}{1}</services>", ClickatellSettings(), PostageSettings()) :"";
        }

        public bool ClickatellEnabled { get; set; }
        public string ClickatellUrl { get; set; }
        public string ClickatellAPIKey { get; set; }
        public string ClickatellUser { get; set; }
        public string ClickatellPass { get; set; }
        
        public string ClickatellSettings()
        {
            return ClickatellEnabled? string.Format(@"<clickatell url=""{0}"" apiKey=""{1}"" username=""{2}"" password=""{3}"" />", ClickatellUrl, ClickatellAPIKey, ClickatellUser, ClickatellPass) : "";
        }

        public bool SmtpEnabled { get; set; }
        public string SmtpFrom { get; set; }
        public string SmtpHost { get; set; }
        public string SmtpUser { get; set; }
        public string SmtpPass { get; set; }
        public string SmtpPort { get; set; }
        public bool SmtpSSLEnabled { get; set; }
        
        public string SmptSettings()
        {
            return SmtpEnabled? string.Format(@"<mailSettings><smtp from=""{0}""><network host=""{1}"" port=""{2}"" userName=""{3}"" password=""{4}"" enableSsl=""{5}"" defaultCredentials=""true"" /></smtp></mailSettings>",
                SmtpFrom, SmtpHost, SmtpPort, SmtpUser, SmtpPass, SmtpSSLEnabled.ToString()) : "";
        }

        public string ProductName { get; set; }
        public string CompanyName { get; set; }
        public string GeneratedYear { get { return DateTime.Now.ToString("yyyy"); } }
        public string GeneratedFileVersion { get { return DateTime.Now.ToString("yyyy.MM.dd.hhmm"); } }
        public string ProductVersion { get; set; }
        public string ApplicationKey { get; set; }


        internal string GetProductDBName()
        {
            return ProductName.Replace(" ", "_") + "DB";
        }
    }

   

}
