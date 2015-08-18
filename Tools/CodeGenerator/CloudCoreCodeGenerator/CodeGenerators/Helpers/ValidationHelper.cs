using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnvDTE;
using System.IO;
using Microsoft.VisualStudio.Shell;

namespace FrameworkOne.CloudCoreCodeGenerator.CodeGenerators.Helpers
{
    public class ValidationHelper
    {
        public static bool IsStringNotNullOrEmpty(string text, string message, string caption)
        {
            if (String.IsNullOrEmpty(text))
            {
                ShowErrorMessage(message, caption);

                return false;
            }

            return true;
        }

        public static bool DoesDirectoryExist(string directory, string message, string caption)
        {
            if (!Directory.Exists(directory))
            {
                ShowErrorMessage(message, caption);

                return false;
            }

            return true;
        }

        public static void ShowErrorMessage(string text, string caption)
        {
            MessageBox.Show(text,
                            caption,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }

        public static void ShowWarningMessage(string text, string caption)
        {
            MessageBox.Show(text,
                            caption,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
        }

        public static bool IsProjectAvailable()
        {
            var dte = (_DTE)Package.GetGlobalService(typeof(_DTE));

            return (dte.Solution.Projects.Count > 0);
        }
    }
}
