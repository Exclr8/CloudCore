using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Tests.Base
{
    [TestClass]
    public class GlobalStorageBase
    {
        public static Process _storageEmulator;

        private static readonly string _sdkDirectory = @"C:\Program Files\Microsoft SDKs\Windows Azure\Emulator\"; // TODO: Make this dynamic

        [AssemblyInitialize]
        public static void Initialize(TestContext context)
        {
            PrepareAzureRoleEnvironment();
        }

        private static void PrepareAzureRoleEnvironment()
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo()
            {
                FileName = Path.Combine(_sdkDirectory, "csrun.exe"),
                Arguments = "/devstore"
            };

            _storageEmulator = new Process();
            _storageEmulator.StartInfo = processStartInfo;
            _storageEmulator.Exited += new EventHandler(StorageEmulatorExited);
            _storageEmulator.Start();
        }

        private static void DisposeOfStorageEmulator()
        {
            if (_storageEmulator == null)
                return;

            if (!_storageEmulator.HasExited)
            {
                try
                {
                    _storageEmulator.CloseMainWindow();
                    _storageEmulator.Dispose();
                    _storageEmulator = null;
                }
                catch { }
            }

        }

        private static void StorageEmulatorExited(object sender, System.EventArgs e)
        {
            _storageEmulator.Dispose();
            _storageEmulator = null;
        }

        [AssemblyCleanup]
        public static void CleanUp()
        {
            DisposeOfStorageEmulator();
        }
    }
}
