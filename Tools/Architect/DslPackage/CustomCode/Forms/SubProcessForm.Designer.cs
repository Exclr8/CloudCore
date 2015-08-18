namespace Architect.CustomCode.Forms
{
    partial class SubProcessForm
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
            this.groupSubProcess = new System.Windows.Forms.GroupBox();
            this.lblSubProcessName = new System.Windows.Forms.Label();
            this.txtSubProcessName = new System.Windows.Forms.TextBox();
            this.groupProcess = new System.Windows.Forms.GroupBox();
            this.lblProcess = new System.Windows.Forms.Label();
            this.btnFindProcess = new System.Windows.Forms.Button();
            this.txtProcess = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupSubProcess.SuspendLayout();
            this.groupProcess.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupSubProcess
            // 
            this.groupSubProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupSubProcess.Controls.Add(this.lblSubProcessName);
            this.groupSubProcess.Controls.Add(this.txtSubProcessName);
            this.groupSubProcess.Location = new System.Drawing.Point(12, 81);
            this.groupSubProcess.Name = "groupSubProcess";
            this.groupSubProcess.Size = new System.Drawing.Size(446, 59);
            this.groupSubProcess.TabIndex = 7;
            this.groupSubProcess.TabStop = false;
            this.groupSubProcess.Text = "New Sub-Process";
            // 
            // lblSubProcessName
            // 
            this.lblSubProcessName.AutoSize = true;
            this.lblSubProcessName.Location = new System.Drawing.Point(6, 26);
            this.lblSubProcessName.Name = "lblSubProcessName";
            this.lblSubProcessName.Size = new System.Drawing.Size(35, 13);
            this.lblSubProcessName.TabIndex = 2;
            this.lblSubProcessName.Text = "Name";
            // 
            // txtSubProcessName
            // 
            this.txtSubProcessName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubProcessName.Location = new System.Drawing.Point(57, 23);
            this.txtSubProcessName.Name = "txtSubProcessName";
            this.txtSubProcessName.Size = new System.Drawing.Size(379, 20);
            this.txtSubProcessName.TabIndex = 0;
            // 
            // groupProcess
            // 
            this.groupProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupProcess.Controls.Add(this.lblProcess);
            this.groupProcess.Controls.Add(this.btnFindProcess);
            this.groupProcess.Controls.Add(this.txtProcess);
            this.groupProcess.Location = new System.Drawing.Point(12, 12);
            this.groupProcess.Name = "groupProcess";
            this.groupProcess.Size = new System.Drawing.Size(446, 57);
            this.groupProcess.TabIndex = 6;
            this.groupProcess.TabStop = false;
            this.groupProcess.Text = "Process Overview";
            // 
            // lblProcess
            // 
            this.lblProcess.AutoSize = true;
            this.lblProcess.Location = new System.Drawing.Point(6, 26);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(45, 13);
            this.lblProcess.TabIndex = 2;
            this.lblProcess.Text = "Process";
            // 
            // btnFindProcess
            // 
            this.btnFindProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFindProcess.Location = new System.Drawing.Point(408, 21);
            this.btnFindProcess.Name = "btnFindProcess";
            this.btnFindProcess.Size = new System.Drawing.Size(28, 23);
            this.btnFindProcess.TabIndex = 1;
            this.btnFindProcess.Text = "...";
            this.btnFindProcess.UseVisualStyleBackColor = true;
            this.btnFindProcess.Click += new System.EventHandler(this.btnFindProcess_Click);
            // 
            // txtProcess
            // 
            this.txtProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProcess.Location = new System.Drawing.Point(57, 23);
            this.txtProcess.Name = "txtProcess";
            this.txtProcess.Size = new System.Drawing.Size(349, 20);
            this.txtProcess.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAdd.Location = new System.Drawing.Point(302, 155);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(383, 155);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "*.process";
            this.openFileDialog1.Filter = "Process Files|*.process";
            this.openFileDialog1.InitialDirectory = ".";
            // 
            // SubProcessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 187);
            this.Controls.Add(this.groupSubProcess);
            this.Controls.Add(this.groupProcess);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCancel);
            this.Name = "SubProcessForm";
            this.Text = "Add New Process";
            this.groupSubProcess.ResumeLayout(false);
            this.groupSubProcess.PerformLayout();
            this.groupProcess.ResumeLayout(false);
            this.groupProcess.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupSubProcess;
        private System.Windows.Forms.Label lblSubProcessName;
        private System.Windows.Forms.TextBox txtSubProcessName;
        private System.Windows.Forms.GroupBox groupProcess;
        private System.Windows.Forms.Label lblProcess;
        private System.Windows.Forms.Button btnFindProcess;
        private System.Windows.Forms.TextBox txtProcess;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;

    }
}