using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnvDTE80;
//using Microsoft.VSSDK.Tools.VsIdeTesting;

namespace ScheduledTaskTests
{
    [TestClass]
    public class ScheduledTaskTests
    {
        private const string _TestSolutionFilePath = @"..\ScheduledTasks\Debugging\Debugging.sln";
        private const string _TestModelingProjectName = "Debugging";

        public static Solution2 _ModelSolution = null;
        public static EnvDTE80.DTE2 _Dte2;

        [AssemblyInitialize]
        public static void InitializeTestingAssembly(TestContext testContext)
        {
            // _Dte2 = (EnvDTE80.DTE2)System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.8.0");
        }

        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {

        }
        
        [TestMethod]
        public void DoNothing()
        {

        }

        [ClassCleanup]
        public static void TearDown()
        {

        }

        [AssemblyCleanup]
        public static void CleanupTestingAssembly()
        {

        }
    }
}
