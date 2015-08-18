namespace CloudCore.VSExtension.Wizards
{
    partial class DataContextSheet : CloudCore.VSExtension.Controls.Wizard.IntWizardPage
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
            this.DataContextListbox = new System.Windows.Forms.ListBox();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Banner
            // 
            this.Banner.Size = new System.Drawing.Size(675, 64);
            this.Banner.Subtitle = "Please select the DataContext for your LINQ query";
            this.Banner.Title = "Data Context";
            // 
            // DataContextListbox
            // 
            this.DataContextListbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataContextListbox.FormattingEnabled = true;
            this.DataContextListbox.Location = new System.Drawing.Point(17, 83);
            this.DataContextListbox.Name = "DataContextListbox";
            this.DataContextListbox.Size = new System.Drawing.Size(636, 212);
            this.DataContextListbox.TabIndex = 7;
            this.DataContextListbox.SelectedIndexChanged += new System.EventHandler(this.DataContextListbox_SelectedIndexChanged);
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(17, 329);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(555, 20);
            this.txtConnectionString.TabIndex = 8;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(578, 328);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 9;
            this.btnTest.Text = "button1";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 310);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Connection String";
            // 
            // DataContextSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.txtConnectionString);
            this.Controls.Add(this.DataContextListbox);
            this.Name = "DataContextSheet";
            this.Size = new System.Drawing.Size(675, 385);
            this.Controls.SetChildIndex(this.Banner, 0);
            this.Controls.SetChildIndex(this.DataContextListbox, 0);
            this.Controls.SetChildIndex(this.txtConnectionString, 0);
            this.Controls.SetChildIndex(this.btnTest, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox DataContextListbox;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label label1;

    }
}