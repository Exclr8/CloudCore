namespace FrameworkOne.CloudCoreCodeGenerator.Forms.General
{
    partial class DbContextPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        private System.Windows.Forms.ComboBox cmbContexts;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gridTestResults;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.TextBox txtDLL;
        private System.Windows.Forms.Label label1;


        private void InitializeComponent()
        {
            this.cmbContexts = new System.Windows.Forms.ComboBox();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridTestResults = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.txtDLL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.opnDll = new System.Windows.Forms.OpenFileDialog();
            this.lblError = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTestResults)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbContexts
            // 
            this.cmbContexts.FormattingEnabled = true;
            this.cmbContexts.Location = new System.Drawing.Point(173, 44);
            this.cmbContexts.Name = "cmbContexts";
            this.cmbContexts.Size = new System.Drawing.Size(554, 21);
            this.cmbContexts.TabIndex = 3;
            this.cmbContexts.SelectedIndexChanged += new System.EventHandler(this.cmbContexts_SelectedIndexChanged);
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(173, 71);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(554, 20);
            this.txtConnectionString.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Database Connection String";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Context Full Name";
            // 
            // btnTest
            // 
            this.btnTest.Enabled = false;
            this.btnTest.Location = new System.Drawing.Point(689, 257);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 6;
            this.btnTest.Text = "Test Query";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gridTestResults);
            this.groupBox2.Location = new System.Drawing.Point(8, 295);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(756, 184);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Test Results";
            // 
            // gridTestResults
            // 
            this.gridTestResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTestResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTestResults.Location = new System.Drawing.Point(3, 16);
            this.gridTestResults.Name = "gridTestResults";
            this.gridTestResults.Size = new System.Drawing.Size(750, 165);
            this.gridTestResults.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCommand);
            this.groupBox1.Location = new System.Drawing.Point(5, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(756, 138);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input LINQ Query to retreive data";
            // 
            // txtCommand
            // 
            this.txtCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCommand.Location = new System.Drawing.Point(3, 16);
            this.txtCommand.Multiline = true;
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(750, 119);
            this.txtCommand.TabIndex = 5;
            this.txtCommand.TextChanged += new System.EventHandler(this.txtCommand_TextChanged);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(736, 16);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(28, 23);
            this.btnOpenFile.TabIndex = 2;
            this.btnOpenFile.Text = "...";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // txtDLL
            // 
            this.txtDLL.Location = new System.Drawing.Point(173, 18);
            this.txtDLL.Name = "txtDLL";
            this.txtDLL.Size = new System.Drawing.Size(554, 20);
            this.txtDLL.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Select Data Context DLL";
            // 
            // opnDll
            // 
            this.opnDll.Filter = "Dll Files (*.dll)|*.dll";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(14, 256);
            this.lblError.MaximumSize = new System.Drawing.Size(600, 26);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 26;
            // 
            // DbContextPage
            // 
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.cmbContexts);
            this.Controls.Add(this.txtConnectionString);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.txtDLL);
            this.Controls.Add(this.label1);
            this.Name = "DbContextPage";
            this.Size = new System.Drawing.Size(786, 479);
            this.SetActive += new System.ComponentModel.CancelEventHandler(this.dbContextPage_SetActive);
            this.WizardNext += new FrameworkOne.VS.Controls.Wizard.WizardPageEventHandler(this.dbContextPage_WizardNext);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTestResults)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.OpenFileDialog opnDll;
        private System.Windows.Forms.Label lblError;

    }
}