using System;
using System.Data.SqlClient;
using Microsoft.Win32;

namespace ProcessViewer.Library.Common
{
    public class RegLibrary
    {

        #region Fields

        private const string Regconfigbase = @"SOFTWARE";
        private const string Regconfigfolder = @"FrameworkOne\ProcessViewer";

        #endregion

        #region Properties

        private SqlConnection Connection { get; set; }

        public string Server { get; set; }
        public string Database { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Integrated { get; set; }

        /// <summary>
        ///Compiles and returns the connection string based on the property values. Ensure all the properties other properties are set.
        /// </summary>
        public string ConnectionString
        {
            get
            {
                if (Integrated)
                    return string.Format(@"Data Source={0};Initial Catalog={1};Integrated Security=True", Server, Database);
                else
                    return string.Format(@"Server={0};Database={1};User Id={2};password={3};", Server, Database, UserName, Password);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Load Property Values from the ProcessViewer registry 
        /// </summary>
        public void LoadValues()
        {
            RegistryKey pRegKey;
            try
            {
                pRegKey = Registry.CurrentUser.OpenSubKey(Regconfigbase + @"\" + Regconfigfolder);
                Server = pRegKey.GetValue("Server").ToString();
                Database = pRegKey.GetValue("Database").ToString();
                Integrated = (pRegKey.GetValue("Integrated").ToString() == "True");
                UserName = pRegKey.GetValue("Username").ToString();
                Password = pRegKey.GetValue("Password").ToString();
                pRegKey.Close();
            }
            catch
            {
                Server = "localhost";
                Database = "CloudCore";
                Integrated = true;
                UserName = "";
                Password = "";

                //create registry entry if none exists
                try
                {
                    using (RegistryKey rootKey = Registry.CurrentUser.OpenSubKey(Regconfigbase, true))
                    {
                        try
                        {
                            rootKey.CreateSubKey(Regconfigfolder);
                            rootKey.Flush();
                            rootKey.Close();
                        }
                        catch (Exception)
                        {
                            // nothing happens
                        }
                    }
                }
                catch (Exception)
                {
                    //nothing happens
                }
            }
        }

        /// <summary>
        /// Check if a Microsoft Visio installation exists on the local machine
        /// </summary>
        /// <param name="version">The version of Viso that must exist on the machine</param>
        /// <returns>true if the specified version is installed, false otherwise</returns>
        public static Boolean CheckForVisio(int version)
        {
            try
            {
                var localMachine = Registry.LocalMachine;
                var regWord = localMachine.OpenSubKey(@"SOFTWARE\Microsoft\Office\14.0\Visio\");
                if (regWord != null)
                {
                    //Checking version of application
                    var value = Convert.ToInt32(regWord.GetValue("InstalledVersion").ToString().Substring(0, 2));

                    if (value >= version)
                        return true;
                }
                regWord.Flush();
                regWord.Close();
                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Saves the current property values into the local machines's registry, then test if the connection is valid
        /// </summary>
        /// <returns>true if the connection is valid, false otherwise</returns>
        public Boolean SaveAndTestValues()
        {
            try
            {
                using (var pRegKey = Registry.CurrentUser.OpenSubKey(Regconfigbase + @"\" + Regconfigfolder, true))
                {
                    if (pRegKey == null)
                    {
                        return false;
                    }

                    pRegKey.SetValue("Server", Server, RegistryValueKind.String);
                    pRegKey.SetValue("Database", Database, RegistryValueKind.String);
                    pRegKey.SetValue("Integrated", Integrated.ToString(), RegistryValueKind.String);
                    pRegKey.SetValue("Username", UserName, RegistryValueKind.String);
                    pRegKey.SetValue("Password", Password, RegistryValueKind.String);

                    pRegKey.Flush();
                    pRegKey.Close();

                }

            }
            catch
            {
                return false;
            }
           
            try
            {
                Connection = new SqlConnection(ConnectionString);
                Connection.Open();
                Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Saves the current property values into the local machines's registry.
        /// </summary>
        public Boolean SaveValues()
        {
            try
            {
                using (var pRegKey = Registry.CurrentUser.OpenSubKey(Regconfigbase + @"\" + Regconfigfolder, true))
                {
                    if (pRegKey == null)
                    {
                        return false;
                    }
                    pRegKey.SetValue("Server", Server, RegistryValueKind.String);
                    pRegKey.SetValue("Database", Database, RegistryValueKind.String);
                    pRegKey.SetValue("Integrated", Integrated == true ? "True" : "False", RegistryValueKind.Binary);
                    pRegKey.SetValue("Username", UserName, RegistryValueKind.String);
                    pRegKey.SetValue("Password", Password, RegistryValueKind.String);

                    pRegKey.Flush();
                    pRegKey.Close();
                    return true;
                }

            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}
