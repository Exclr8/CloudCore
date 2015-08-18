namespace CloudCore.VSExtension.Wizards
{
    partial class BaseContextDetailsSheet : CloudCore.VSExtension.Controls.Wizard.IntWizardPage
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbKeyField = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Banner
            // 
            this.Banner.Size = new System.Drawing.Size(675, 64);
            this.Banner.Subtitle = "Please enter the details of your Cached Reusable Object";
            this.Banner.Title = "Details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Context Name";
            // 
            // txtContextName
            // 
            this.txtContextName.Location = new System.Drawing.Point(166, 137);
            this.txtContextName.Name = "txtContextName";
            this.txtContextName.Size = new System.Drawing.Size(196, 20);
            this.txtContextName.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "CRO Title";
            // 
            // txtContextTitle
            // 
            this.txtContextTitle.Location = new System.Drawing.Point(166, 212);
            this.txtContextTitle.Name = "txtContextTitle";
            this.txtContextTitle.Size = new System.Drawing.Size(294, 20);
            this.txtContextTitle.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.CausesValidation = false;
            this.label3.Location = new System.Drawing.Point(24, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(412, 39);
            this.label3.TabIndex = 10;
            this.label3.Text = "The context name is used to give this \"Cached Reusable Object\" class a name.  Typ" +
    "ical names include Customer, Client, Account, Order, etc.";
            // 
            // label4
            // 
            this.label4.CausesValidation = false;
            this.label4.Location = new System.Drawing.Point(24, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(412, 19);
            this.label4.TabIndex = 11;
            this.label4.Text = "The CRO Title is the title displayed on the page in runtime.";
            // 
            // label5
            // 
            this.label5.CausesValidation = false;
            this.label5.Location = new System.Drawing.Point(24, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(412, 19);
            this.label5.TabIndex = 14;
            this.label5.Text = "The key field is the primary identifier for this CRO.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(86, 281);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Key Field";
            // 
            // cmbKeyField
            // 
            this.cmbKeyField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKeyField.FormattingEnabled = true;
            this.cmbKeyField.Location = new System.Drawing.Point(166, 275);
            this.cmbKeyField.Name = "cmbKeyField";
            this.cmbKeyField.Size = new System.Drawing.Size(239, 21);
            this.cmbKeyField.TabIndex = 15;
            // 
            // CRODetailsSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbKeyField);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtContextTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtContextName);
            this.Controls.Add(this.label1);
            this.Name = "CRODetailsSheet";
            this.Size = new System.Drawing.Size(675, 385);
            this.Controls.SetChildIndex(this.Banner, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtContextName, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtContextTitle, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.cmbKeyField, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContextName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtContextTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbKeyField;
    }
}