using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrameworkOne.CloudCoreCodeGenerator.Controls;
using FrameworkOne.VS.Controls.Wizard;
using FrameworkOne.CloudCoreCodeGenerator.CodeGenerators.Data;
using FrameworkOne.CloudCoreCodeGenerator.CodeGenerators.Helpers;

namespace FrameworkOne.CloudCoreCodeGenerator.Forms.CRO
{
    public partial class CROPropertiesPage : BasePropertiesPage<CROPropertyItem, ICRO_DataColumn>
    {
        protected override bool IsEachPropertyItemValid(CROPropertyItem item)
        {
            if(item.IsSelected)
            {
                if (!ValidationHelper.IsStringNotNullOrEmpty(item.DisplayName, string.Format(@"Please enter a display name for '{0}'.", item.ColumnName), "Display name empty"))
                {
                    item.Focus();
                    return false;
                }

                if (item.VariableType == "Please Select")
                {
                    ValidationHelper.ShowErrorMessage(string.Format(@"Please select the variable type for '{0}'.", item.ColumnName), "Variable type");
                    item.Focus();
                    return false;
                }
            }

            return true;
        }



        protected override bool IsGlobalControlsValid(List<CROPropertyItem> controls)
        {
            bool isSetToPrimary = false;

            foreach (var item in controls)
            {
                isSetToPrimary = item.IsPrimary;

                if (isSetToPrimary) break;
            }

            if(!isSetToPrimary)
                ValidationHelper.ShowErrorMessage("Please make sure to select a column as your primary item", "No Primary item found");

            return isSetToPrimary;
        }
    }
}
