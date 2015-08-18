using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using CloudCore.Core.Dashboard;
using Microsoft.WindowsAzure.ServiceRuntime;
using System.Security;
using System.Text.RegularExpressions;

namespace CloudCore.VirtualWorker.DashboardKpi
{
    public abstract class HighChartImgKpiScheduledTask : KpiScheduledTask
    {
        private string Host = RoleEnvironment.CurrentRoleInstance.InstanceEndpoints["highchartInternal"].IPEndpoint.Address.ToString(); 
        private string Port = RoleEnvironment.CurrentRoleInstance.InstanceEndpoints["highchartInternal"].IPEndpoint.Port.ToString(); 
        private Process process;

        protected override void OnPreSave(IEnumerable<KpiTableEntity> kpiBatchData)
        {
            try
            {
                StartPhantomJs();

                try
                {
                    RenderHighChartImage(kpiBatchData);
                }
                catch (Exception ex)
                {
                    try
                    {
                        TryStopPhantomJs();
                        ex.Data.Add(Guid.NewGuid().ToString(), String.Format(@"""{0}""", Path.Combine(Environment.GetEnvironmentVariable("RoleRoot") + "\\", "approot", "phantomjs", "phantomjs.exe")));
                        ex.Data.Add(Guid.NewGuid().ToString(), String.Format(@"""{0}""", Path.Combine(Environment.GetEnvironmentVariable("RoleRoot") + "\\", "approot", "phantomjs", "highcharts-convert.js")));
                    }
                    catch { throw; }
                    
                    throw;
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add(Guid.NewGuid().ToString(), "Failed on OnPreSave.");
                throw;
            }
        }

        private void StartPhantomJs()
        {
            try
            {
                var phantomjsProcess = Process.GetProcessesByName("phantomjs");

                if (phantomjsProcess.Length == 0)
                {
                    var phantomJsPath = String.Format(@"""{0}""", Path.Combine(Environment.GetEnvironmentVariable("RoleRoot") + "\\", "approot", "phantomjs", "phantomjs.exe"));
                    var phantomJsConvert = String.Format(@"""{0}""", Path.Combine(Environment.GetEnvironmentVariable("RoleRoot") + "\\", "approot", "phantomjs", "highcharts-convert.js"));
                    string arguments =
                        string.Format(
                            @"{0} -host {1} -port {2}", phantomJsConvert, Host, Port);

                    RunCommand(phantomJsPath, arguments);
                    Thread.Sleep(15000);
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add(Guid.NewGuid().ToString(), "Attempted to start command prompt for phantomjs server.");
                throw;
            }
        }

        private void TryStopPhantomJs()
        {
            try
            {
                process.CloseMainWindow();
            }
            catch
            {
                //The process might not have initialised in the first place. 
                //This exception should not be thrown as it does not contribute to the actual reason of failure.
                //Eg: Path, Port, Host: Are already handled and would most likely be the cause of failure. "Not process.CloseMainWindow"
            }
        }

        private void RenderHighChartImage(IEnumerable<KpiTableEntity> kpiBatchData)
        {
            foreach (var data in kpiBatchData)
            {
                var dashboardData = DashboardData(data.UserId);
                var phantomJsReadyDashboardData = RemoveStringEscapeSequences(dashboardData);
                var dashboardImage = DoPost(TransformOptionsToPhantomJsString(phantomJsReadyDashboardData));

                data.ResultData = phantomJsReadyDashboardData;
                data.Image = dashboardImage;
            }
        }

        private string TransformOptionsToPhantomJsString(string jsonOptions)
        {
            return string.Format(@"{{""infile"":""{{{0}}}"",""constr"":""Chart""}}", jsonOptions);
        }

        private byte[] DoPost(string jsonOptions)
        {
            try
            {
                var postUrl = string.Format("http://{0}:{1}", Host, Port);

                var postData = jsonOptions;
                var byteArray = Encoding.UTF8.GetBytes(postData);

                var request = WebRequest.CreateHttp(postUrl);
                request.Method = "http";
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = byteArray.Length;

                var dataStream = request.GetRequestStream();

                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                var response = request.GetResponse();

                dataStream = response.GetResponseStream();
                var reader = new StreamReader(dataStream);
                var responseFromServer = reader.ReadToEnd();

                var image = Convert.FromBase64String(responseFromServer);

                dataStream.Close();
                response.Close();

                return image;
            }
            catch (Exception ex)
            {
                ex.Data.Add(Guid.NewGuid().ToString(), "Trying to post to PhantomJs Server.");
                ex.Data.Add(Guid.NewGuid().ToString(), Host);
                ex.Data.Add(Guid.NewGuid().ToString(), Port);
                throw;
            }
        }

        private void RunCommand(string command, string arguments)
        {
            process = new Process
            {
                StartInfo =
                {
                    UseShellExecute = true,
                    RedirectStandardOutput = false,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = command,
                    Arguments = arguments,
                    Verb = "runas"
                }
            };
            try
            {
                process.Start();
            }
            catch (Exception ex)
            {
                ex.Data.Add(Guid.NewGuid().ToString(), "Attempting to start highcharts process.");
                throw;
            }
        }

        private string RemoveStringEscapeSequences(string value)
        {
            return value.Replace("\n", "")
                        .Replace("\r", "")
                        .Replace("\t", "");
        }
    }
}
