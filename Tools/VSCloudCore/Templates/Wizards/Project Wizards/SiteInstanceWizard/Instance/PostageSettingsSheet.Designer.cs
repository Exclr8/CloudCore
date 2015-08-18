namespace CloudCore.VSExtension.Wizards
{
    partial class PostageSettingsSheet : ProjectClasses.WizardSheet
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtPostageUrl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPostageAPIKey = new System.Windows.Forms.TextBox();
            this.chkUseService = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Banner
            // 
            this.Banner.Size = new System.Drawing.Size(675, 64);
            this.Banner.Subtitle = "Please specify the settings for the Postage service if you would like to use it.";
            this.Banner.Title = "CloudCore Site Services [Postage]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Url";
            // 
            // txtPostageUrl
            // 
            this.txtPostageUrl.Location = new System.Drawing.Point(113, 119);
            this.txtPostageUrl.Name = "txtPostageUrl";
            this.txtPostageUrl.Size = new System.Drawing.Size(287, 20);
            this.txtPostageUrl.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "API Key";
            // 
            // txtPostageAPIKey
            // 
            this.txtPostageAPIKey.Location = new System.Drawing.Point(113, 163);
            this.txtPostageAPIKey.Name = "txtPostageAPIKey";
            this.txtPostageAPIKey.Size = new System.Drawing.Size(220, 20);
            this.txtPostageAPIKey.TabIndex = 4;
            this.txtPostageAPIKey.Text = "1.0";
            // 
            // chkUseService
            // 
            this.chkUseService.AutoSize = true;
            this.chkUseService.Checked = true;
            this.chkUseService.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseService.Location = new System.Drawing.Point(25, 80);
            this.chkUseService.Name = "chkUseService";
            this.chkUseService.Size = new System.Drawing.Size(144, 17);
            this.chkUseService.TabIndex = 6;
            this.chkUseService.Text = "Use the Postage Service";
            this.chkUseService.UseVisualStyleBackColor = true;
            this.chkUseService.CheckStateChanged += new System.EventHandler(this.chkUseService_CheckStateChanged);
            // 
            // PostageSettingsSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkUseService);
            this.Controls.Add(this.txtPostageAPIKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPostageUrl);
            this.Controls.Add(this.label1);
            this.Name = "PostageSettingsSheet";
            this.Size = new System.Drawing.Size(675, 385);
            this.Controls.SetChildIndex(this.Banner, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtPostageUrl, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtPostageAPIKey, 0);
            this.Controls.SetChildIndex(this.chkUseService, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPostageUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPostageAPIKey;
        private System.Windows.Forms.CheckBox chkUseService;

    }
}