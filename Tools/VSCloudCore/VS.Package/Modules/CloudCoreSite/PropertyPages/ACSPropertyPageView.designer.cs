namespace CloudCore.VSExtension.SiteProperties
{
    partial class ACSPropertyPageView
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
            this.lblWebModule = new System.Windows.Forms.Label();
            this.cmbWebModules = new System.Windows.Forms.ComboBox();
            this.txtWebModuleWarning = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblWebModule
            // 
            this.lblWebModule.AutoSize = true;
            this.lblWebModule.Location = new System.Drawing.Point(15, 26);
            this.lblWebModule.Name = "lblWebModule";
            this.lblWebModule.Size = new System.Drawing.Size(68, 13);
            this.lblWebModule.TabIndex = 2;
            this.lblWebModule.Text = "Web Module";
            // 
            // cmbWebModules
            // 
            this.cmbWebModules.FormattingEnabled = true;
            this.cmbWebModules.Location = new System.Drawing.Point(93, 22);
            this.cmbWebModules.Name = "cmbWebModules";
            this.cmbWebModules.Size = new System.Drawing.Size(322, 21);
            this.cmbWebModules.TabIndex = 3;
            // 
            // txtWebModuleWarning
            // 
            this.txtWebModuleWarning.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtWebModuleWarning.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtWebModuleWarning.Enabled = false;
            this.txtWebModuleWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWebModuleWarning.Location = new System.Drawing.Point(93, 44);
            this.txtWebModuleWarning.Margin = new System.Windows.Forms.Padding(4);
            this.txtWebModuleWarning.Multiline = true;
            this.txtWebModuleWarning.Name = "txtWebModuleWarning";
            this.txtWebModuleWarning.Size = new System.Drawing.Size(337, 34);
            this.txtWebModuleWarning.TabIndex = 4;
            this.txtWebModuleWarning.Text = "If CloudCore Web Modules exist in your solution but are not displayed here please" +
    " close and re-open this properties window.";
            this.txtWebModuleWarning.Visible = false;
            // 
            // ACSPropertyPageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtWebModuleWarning);
            this.Controls.Add(this.cmbWebModules);
            this.Controls.Add(this.lblWebModule);
            this.Name = "ACSPropertyPageView";
            this.Size = new System.Drawing.Size(445, 232);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.Label lblWebModule;
        private System.Windows.Forms.ComboBox cmbWebModules;
        private System.Windows.Forms.TextBox txtWebModuleWarning;
	}
}