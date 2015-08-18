namespace CloudCore.VSExtension.Wizards
{
    partial class ClickatellSettingsSheet : ProjectClasses.WizardSheet
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
            this.txtClickatellUrl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClickatellAPIKey = new System.Windows.Forms.TextBox();
            this.chkUseService = new System.Windows.Forms.CheckBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Banner
            // 
            this.Banner.Size = new System.Drawing.Size(675, 64);
            this.Banner.Subtitle = "Please specify the settings for the Postage service if you would like to use it.";
            this.Banner.Title = "CloudCore Site Services [Clickatell]";
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
            // txtClickatellUrl
            // 
            this.txtClickatellUrl.Location = new System.Drawing.Point(113, 119);
            this.txtClickatellUrl.Name = "txtClickatellUrl";
            this.txtClickatellUrl.Size = new System.Drawing.Size(287, 20);
            this.txtClickatellUrl.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "API Key";
            // 
            // txtClickatellAPIKey
            // 
            this.txtClickatellAPIKey.Location = new System.Drawing.Point(113, 155);
            this.txtClickatellAPIKey.Name = "txtClickatellAPIKey";
            this.txtClickatellAPIKey.Size = new System.Drawing.Size(220, 20);
            this.txtClickatellAPIKey.TabIndex = 4;
            // 
            // chkUseService
            // 
            this.chkUseService.AutoSize = true;
            this.chkUseService.Checked = true;
            this.chkUseService.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseService.Location = new System.Drawing.Point(25, 80);
            this.chkUseService.Name = "chkUseService";
            this.chkUseService.Size = new System.Drawing.Size(147, 17);
            this.chkUseService.TabIndex = 6;
            this.chkUseService.Text = "Use the Clickatell Service";
            this.chkUseService.UseVisualStyleBackColor = true;
            this.chkUseService.CheckedChanged += new System.EventHandler(this.chkUseService_CheckStateChanged);
            this.chkUseService.CheckStateChanged += new System.EventHandler(this.chkUseService_CheckStateChanged);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(113, 192);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(165, 20);
            this.txtUsername.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Username";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(113, 228);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(165, 20);
            this.txtPassword.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Password";
            // 
            // ClickatellSettingsSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkUseService);
            this.Controls.Add(this.txtClickatellAPIKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtClickatellUrl);
            this.Controls.Add(this.label1);
            this.Name = "ClickatellSettingsSheet";
            this.Size = new System.Drawing.Size(675, 385);
            this.Controls.SetChildIndex(this.Banner, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtClickatellUrl, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtClickatellAPIKey, 0);
            this.Controls.SetChildIndex(this.chkUseService, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtUsername, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtPassword, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClickatellUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClickatellAPIKey;
        private System.Windows.Forms.CheckBox chkUseService;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label4;

    }
}