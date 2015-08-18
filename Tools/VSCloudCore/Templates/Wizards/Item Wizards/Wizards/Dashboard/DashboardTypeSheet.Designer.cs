namespace CloudCore.VSExtension.Wizards
{
    partial class DashboardTypeSheet : CloudCore.VSExtension.Controls.Wizard.IntWizardPage
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTypeText = new System.Windows.Forms.Label();
            this.cmbDashboardType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtSubTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Banner
            // 
            this.Banner.Size = new System.Drawing.Size(675, 64);
            this.Banner.Subtitle = "Please select dashboard type";
            this.Banner.Title = "Dashboard";
            // 
            // lblTypeText
            // 
            this.lblTypeText.AutoSize = true;
            this.lblTypeText.Location = new System.Drawing.Point(142, 176);
            this.lblTypeText.Name = "lblTypeText";
            this.lblTypeText.Size = new System.Drawing.Size(86, 13);
            this.lblTypeText.TabIndex = 12;
            this.lblTypeText.Text = "Dashboard Type";
            // 
            // cmbDashboardType
            // 
            this.cmbDashboardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDashboardType.FormattingEnabled = true;
            this.cmbDashboardType.Location = new System.Drawing.Point(293, 173);
            this.cmbDashboardType.Name = "cmbDashboardType";
            this.cmbDashboardType.Size = new System.Drawing.Size(239, 21);
            this.cmbDashboardType.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(142, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Dashboard Title";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(293, 96);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(239, 20);
            this.txtTitle.TabIndex = 17;
            // 
            // txtSubTitle
            // 
            this.txtSubTitle.Location = new System.Drawing.Point(293, 133);
            this.txtSubTitle.Name = "txtSubTitle";
            this.txtSubTitle.Size = new System.Drawing.Size(239, 20);
            this.txtSubTitle.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(142, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Dashboard Sub Title";
            // 
            // DashboardTypeSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtSubTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbDashboardType);
            this.Controls.Add(this.lblTypeText);
            this.Name = "DashboardTypeSheet";
            this.Size = new System.Drawing.Size(675, 385);
            this.Controls.SetChildIndex(this.Banner, 0);
            this.Controls.SetChildIndex(this.lblTypeText, 0);
            this.Controls.SetChildIndex(this.cmbDashboardType, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtTitle, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtSubTitle, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTypeText;
        private System.Windows.Forms.ComboBox cmbDashboardType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtSubTitle;
        private System.Windows.Forms.Label label2;
    }
}