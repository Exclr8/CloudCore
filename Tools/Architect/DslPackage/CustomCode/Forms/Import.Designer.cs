namespace Architect.CustomCode.Forms
{
    partial class Import
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.txtVisio = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lstProjects = new System.Windows.Forms.ListBox();
            this.pnlBackup = new System.Windows.Forms.Panel();
            this.btnFolder = new System.Windows.Forms.Button();
            this.txtBackupLocation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.lstDeleted = new System.Windows.Forms.ListBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlDeleted = new System.Windows.Forms.Panel();
            this.btnImport = new System.Windows.Forms.Button();
            this.pnlBackup.SuspendLayout();
            this.pnlDeleted.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Visio File";
            // 
            // txtVisio
            // 
            this.txtVisio.Location = new System.Drawing.Point(110, 9);
            this.txtVisio.Name = "txtVisio";
            this.txtVisio.Size = new System.Drawing.Size(142, 20);
            this.txtVisio.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(260, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(213, 184);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Select a Project";
            // 
            // lstProjects
            // 
            this.lstProjects.FormattingEnabled = true;
            this.lstProjects.Location = new System.Drawing.Point(110, 36);
            this.lstProjects.Name = "lstProjects";
            this.lstProjects.Size = new System.Drawing.Size(142, 82);
            this.lstProjects.TabIndex = 7;
            // 
            // pnlBackup
            // 
            this.pnlBackup.Controls.Add(this.btnFolder);
            this.pnlBackup.Controls.Add(this.txtBackupLocation);
            this.pnlBackup.Controls.Add(this.label3);
            this.pnlBackup.Location = new System.Drawing.Point(9, 138);
            this.pnlBackup.Name = "pnlBackup";
            this.pnlBackup.Size = new System.Drawing.Size(261, 32);
            this.pnlBackup.TabIndex = 15;
            // 
            // btnFolder
            // 
            this.btnFolder.Location = new System.Drawing.Point(230, 4);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(28, 23);
            this.btnFolder.TabIndex = 17;
            this.btnFolder.Text = "...";
            this.btnFolder.UseVisualStyleBackColor = true;
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // txtBackupLocation
            // 
            this.txtBackupLocation.Location = new System.Drawing.Point(103, 6);
            this.txtBackupLocation.Name = "txtBackupLocation";
            this.txtBackupLocation.Size = new System.Drawing.Size(124, 20);
            this.txtBackupLocation.TabIndex = 16;
            this.txtBackupLocation.Text = "c:\\test\\backup";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Backup Location";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(4, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(257, 44);
            this.label4.TabIndex = 0;
            this.label4.Text = "Please Note:  Process exists in selected project.\r\n\r\nItem code that will be delet" +
                "ed on import.";
            // 
            // lstDeleted
            // 
            this.lstDeleted.FormattingEnabled = true;
            this.lstDeleted.Location = new System.Drawing.Point(7, 50);
            this.lstDeleted.Name = "lstDeleted";
            this.lstDeleted.Size = new System.Drawing.Size(263, 82);
            this.lstDeleted.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(121, 176);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // pnlDeleted
            // 
            this.pnlDeleted.Controls.Add(this.btnImport);
            this.pnlDeleted.Controls.Add(this.pnlBackup);
            this.pnlDeleted.Controls.Add(this.btnCancel);
            this.pnlDeleted.Controls.Add(this.lstDeleted);
            this.pnlDeleted.Controls.Add(this.label4);
            this.pnlDeleted.Location = new System.Drawing.Point(12, 8);
            this.pnlDeleted.Name = "pnlDeleted";
            this.pnlDeleted.Size = new System.Drawing.Size(286, 211);
            this.pnlDeleted.TabIndex = 16;
            this.pnlDeleted.Visible = false;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(197, 176);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 6;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // Import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 226);
            this.Controls.Add(this.lstProjects);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtVisio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlDeleted);
            this.Name = "Import";
            this.Text = "Import";
            this.Load += new System.EventHandler(this.Import_Load);
            this.pnlBackup.ResumeLayout(false);
            this.pnlBackup.PerformLayout();
            this.pnlDeleted.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtVisio;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstProjects;
        private System.Windows.Forms.Panel pnlBackup;
        private System.Windows.Forms.TextBox txtBackupLocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstDeleted;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlDeleted;
        private System.Windows.Forms.Button btnImport;

    }
}