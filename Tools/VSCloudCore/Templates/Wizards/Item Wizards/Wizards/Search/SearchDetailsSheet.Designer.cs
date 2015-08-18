namespace CloudCore.VSExtension.Wizards
{
    partial class SearchDetailsSheet : CloudCore.VSExtension.Controls.Wizard.IntWizardPage
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
            this.txtContextName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtContextTitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbKeyField = new System.Windows.Forms.ComboBox();
            this.txtPageTitle = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbKeyDisplay = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Banner
            // 
            this.Banner.Size = new System.Drawing.Size(675, 64);
            this.Banner.Subtitle = "Please enter the details of your search view.";
            this.Banner.Title = "Details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Context Name";
            // 
            // txtContextName
            // 
            this.txtContextName.Location = new System.Drawing.Point(166, 127);
            this.txtContextName.Name = "txtContextName";
            this.txtContextName.Size = new System.Drawing.Size(196, 20);
            this.txtContextName.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Result Grid Title";
            // 
            // txtContextTitle
            // 
            this.txtContextTitle.Location = new System.Drawing.Point(166, 179);
            this.txtContextTitle.Name = "txtContextTitle";
            this.txtContextTitle.Size = new System.Drawing.Size(294, 20);
            this.txtContextTitle.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.CausesValidation = false;
            this.label3.Location = new System.Drawing.Point(24, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(412, 39);
            this.label3.TabIndex = 10;
            this.label3.Text = "The context name is used to give the search view class a name.  Typical names inc" +
    "lude Customer, Client, Account, Order, etc.";
            // 
            // label5
            // 
            this.label5.CausesValidation = false;
            this.label5.Location = new System.Drawing.Point(24, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(412, 19);
            this.label5.TabIndex = 14;
            this.label5.Text = "The primary identifier for the result data.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(110, 285);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Key Field";
            // 
            // cmbKeyField
            // 
            this.cmbKeyField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKeyField.FormattingEnabled = true;
            this.cmbKeyField.Location = new System.Drawing.Point(166, 277);
            this.cmbKeyField.Name = "cmbKeyField";
            this.cmbKeyField.Size = new System.Drawing.Size(239, 21);
            this.cmbKeyField.TabIndex = 15;
            // 
            // txtPageTitle
            // 
            this.txtPageTitle.Location = new System.Drawing.Point(166, 153);
            this.txtPageTitle.Name = "txtPageTitle";
            this.txtPageTitle.Size = new System.Drawing.Size(294, 20);
            this.txtPageTitle.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(105, 160);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Page Title";
            // 
            // cmbKeyDisplay
            // 
            this.cmbKeyDisplay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKeyDisplay.FormattingEnabled = true;
            this.cmbKeyDisplay.Location = new System.Drawing.Point(166, 304);
            this.cmbKeyDisplay.Name = "cmbKeyDisplay";
            this.cmbKeyDisplay.Size = new System.Drawing.Size(239, 21);
            this.cmbKeyDisplay.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(73, 312);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Key Display Field";
            // 
            // SearchDetailsSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbKeyDisplay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPageTitle);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbKeyField);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtContextTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtContextName);
            this.Controls.Add(this.label1);
            this.Name = "SearchDetailsSheet";
            this.Size = new System.Drawing.Size(675, 385);
            this.Controls.SetChildIndex(this.Banner, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtContextName, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtContextTitle, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.cmbKeyField, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtPageTitle, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cmbKeyDisplay, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContextName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtContextTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbKeyField;
        private System.Windows.Forms.TextBox txtPageTitle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbKeyDisplay;
        private System.Windows.Forms.Label label4;
    }
}