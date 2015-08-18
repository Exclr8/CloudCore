using System;
using System.Diagnostics;
using System.IO;

namespace Frameworkone.UnitTestUtilities.Azure
{
    public class AzureStorageTestBase
    {
        #region Setup

        private const string SdkDirectory = @"C:\Program Files\Microsoft SDKs\Windows Azure\Emulator\";
        private static Process storageEmulator;
        private static bool started;

        public static void StartAzureStorageEmulator()
        {
            if (!started)
            {
                var processStartInfo = new ProcessStartInfo()
                {
                    FileName = Path.Combine(SdkDirectory, "csrun.exe"),
                    Arguments = "/devstore"
                };

                storageEmulator = new Process();
                storageEmulator.StartInfo = processStartInfo;
                storageEmulator.Exited += new EventHandler(StorageEmulatorExited);
                storageEmulator.Start();
                started = true;
            }
        }

        #endregion

        #region Tear Down
        
        public static void CleanUp()
        {
            DisposeOfStorageEmulator();
        }

        private static void DisposeOfStorageEmulator()
        {
            if (storageEmulator == null)
                return;

            if (!storageEmulator.HasExited)
            {
                try
                {
                    storageEmulator.CloseMainWindow();
                    storageEmulator.Dispose();
                    storageEmulator = null;
                }
                catch
                {
                    // do nothing
                }
            }

        }

        private static void StorageEmulatorExited(object sender, System.EventArgs e)
        {
            storageEmulator.Dispose();
            storageEmulator = null;
        }
        #endregion
    }
}
