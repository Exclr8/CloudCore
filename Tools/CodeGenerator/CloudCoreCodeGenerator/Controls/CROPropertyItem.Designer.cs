namespace FrameworkOne.CloudCoreCodeGenerator.Controls
{
    partial class CROPropertyItem
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.lblPropertyName = new System.Windows.Forms.Label();
            this.chkIsPrimary = new System.Windows.Forms.CheckBox();
            this.dllDataType = new System.Windows.Forms.ComboBox();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Location = new System.Drawing.Point(544, 6);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(169, 20);
            this.txtDisplayName.TabIndex = 4;
            // 
            // lblPropertyName
            // 
            this.lblPropertyName.AutoSize = true;
            this.lblPropertyName.Location = new System.Drawing.Point(126, 9);
            this.lblPropertyName.Margin = new System.Windows.Forms.Padding(5, 6, 25, 0);
            this.lblPropertyName.Name = "lblPropertyName";
            this.lblPropertyName.Size = new System.Drawing.Size(131, 13);
            this.lblPropertyName.TabIndex = 13;
            this.lblPropertyName.Text = "Enter Property Name Here";
            // 
            // chkIsPrimary
            // 
            this.chkIsPrimary.AutoSize = true;
            this.chkIsPrimary.Location = new System.Drawing.Point(47, 8);
            this.chkIsPrimary.Name = "chkIsPrimary";
            this.chkIsPrimary.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.chkIsPrimary.Size = new System.Drawing.Size(15, 17);
            this.chkIsPrimary.TabIndex = 2;
            this.chkIsPrimary.UseVisualStyleBackColor = true;
            this.chkIsPrimary.CheckedChanged += new System.EventHandler(this.chkIsPrimary_CheckedChanged);
            // 
            // dllDataType
            // 
            this.dllDataType.FormattingEnabled = true;
            this.dllDataType.Items.AddRange(new object[] {
            "Please Select",
            "String",
            "Guid",
            "Int32",
            "Decimal",
            "Boolean",
            "DateTime",
            "Binary"});
            this.dllDataType.Location = new System.Drawing.Point(366, 6);
            this.dllDataType.Name = "dllDataType";
            this.dllDataType.Size = new System.Drawing.Size(138, 21);
            this.dllDataType.TabIndex = 3;
            this.dllDataType.SelectedIndexChanged += new System.EventHandler(this.dllDataType_SelectedIndexChanged);
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(8, 8);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.chkEnabled.Size = new System.Drawing.Size(15, 17);
            this.chkEnabled.TabIndex = 1;
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // CROPropertyItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtDisplayName);
            this.Controls.Add(this.lblPropertyName);
            this.Controls.Add(this.chkIsPrimary);
            this.Controls.Add(this.dllDataType);
            this.Controls.Add(this.chkEnabled);
            this.Name = "CROPropertyItem";
            this.Size = new System.Drawing.Size(722, 32);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.Label lblPropertyName;
        private System.Windows.Forms.CheckBox chkIsPrimary;
        private System.Windows.Forms.ComboBox dllDataType;
        private System.Windows.Forms.CheckBox chkEnabled;
    }
}
