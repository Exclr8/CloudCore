namespace CloudCore.VSExtension.Wizards
{
    partial class CROPropertyColumnsSheet : CloudCore.VSExtension.Controls.Wizard.IntWizardPage
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
            this.lboxAvailable = new System.Windows.Forms.ListBox();
            this.lboxAsProperty = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Banner
            // 
            this.Banner.Size = new System.Drawing.Size(675, 64);
            this.Banner.Subtitle = "Please select the fields you would like to add to the CRO as properties.";
            this.Banner.Title = "Properties";
            // 
            // lboxAvailable
            // 
            this.lboxAvailable.FormattingEnabled = true;
            this.lboxAvailable.Location = new System.Drawing.Point(14, 94);
            this.lboxAvailable.Name = "lboxAvailable";
            this.lboxAvailable.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lboxAvailable.Size = new System.Drawing.Size(249, 264);
            this.lboxAvailable.TabIndex = 1;
            this.lboxAvailable.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lboxAvailable_MouseDoubleClick);
            // 
            // lboxForDisplay
            // 
            this.lboxAsProperty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lboxAsProperty.FormattingEnabled = true;
            this.lboxAsProperty.Location = new System.Drawing.Point(412, 94);
            this.lboxAsProperty.Name = "lboxForDisplay";
            this.lboxAsProperty.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lboxAsProperty.Size = new System.Drawing.Size(249, 264);
            this.lboxAsProperty.TabIndex = 2;
            this.lboxAsProperty.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lboxForDisplay_MouseDoubleClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(299, 94);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add >>";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(299, 123);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "<< Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Available Fields";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(412, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Implement As Properties";
            // 
            // CROModelColumnsSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lboxAsProperty);
            this.Controls.Add(this.lboxAvailable);
            this.Name = "CROModelColumnsSheet";
            this.Size = new System.Drawing.Size(675, 385);
            this.Controls.SetChildIndex(this.Banner, 0);
            this.Controls.SetChildIndex(this.lboxAvailable, 0);
            this.Controls.SetChildIndex(this.lboxAsProperty, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.btnRemove, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lboxAvailable;
        private System.Windows.Forms.ListBox lboxAsProperty;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

    }
}