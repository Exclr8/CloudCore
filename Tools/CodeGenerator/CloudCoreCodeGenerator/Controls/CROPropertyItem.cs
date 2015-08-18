using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FrameworkOne.CloudCoreCodeGenerator.CodeGenerators.Data;

namespace FrameworkOne.CloudCoreCodeGenerator.Controls
{
    public partial class CROPropertyItem : UserControl, ICRO_DataColumn
    {
        public bool IsSelected 
        {
            get
            {
                return chkEnabled.Checked;
            }
            set
            {
                chkEnabled.Checked = value;
            }
        }

        public bool IsPrimary
        {
            get
            {
                return chkIsPrimary.Checked;
            }
            set
            {
                chkIsPrimary.Checked = value;
            }
        }

        public string ColumnName
        {
            get
            {
                return lblPropertyName.Text;
            }
            set
            {
                lblPropertyName.Text = value;
            }
        }

        public string VariableType
        {
            get
            {
                return dllDataType.Text;
            }
            set
            {
                var index = dllDataType.FindString(value);

                dllDataType.SelectedIndex = (index == -1) ? 0 : index;
            }
        }

        public string DisplayName
        {
            get
            {
                return txtDisplayName.Text;
            }
            set
            {
                txtDisplayName.Text = value;
            }
        }

        public CROPropertyItem()
        {
            InitializeComponent();
        }

        public CROPropertyItem(bool isSelected, bool isPrimary, string columnName, string variableType, string displayName)
        {
            InitializeComponent();

            this.lblPropertyName.Text = columnName;
            this.txtDisplayName.Text = displayName;
            this.chkIsPrimary.Checked = isPrimary;
            this.chkEnabled.Checked = isSelected;
            this.dllDataType.SelectedIndex = dllDataType.FindString(variableType) == -1 ? 0 : dllDataType.FindString(variableType);
        }

        private void chkIsPrimary_CheckedChanged(object sender, EventArgs e)
        {
            var checkBox = (sender as CheckBox);

            if(checkBox.Checked)
                SetPrimary(checkBox);

        }

        private void SetPrimary(CheckBox primary)
        {
            if (this.Parent != null)
                foreach (CROPropertyItem item in this.Parent.Controls.OfType<CROPropertyItem>())
                    if (item.DisplayName != ((CROPropertyItem)primary.Parent).DisplayName)
                        item.chkIsPrimary.Checked = false;
        }

        private void dllDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = sender as ComboBox;

            combo.ForeColor = combo.SelectedIndex == 0 ? System.Drawing.Color.Red : System.Drawing.Color.Black;
        }
    }
}
