namespace FrameworkOne.CloudCoreCodeGenerator.Forms.CRO
{
    partial class BasePropertiesPage<PropertyItemType, DataColumnItemType>
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(0, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(790, 482);
            this.panel1.TabIndex = 2;
            // 
            // BasePropertiesPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "BasePropertiesPage";
            this.Size = new System.Drawing.Size(790, 526);
            this.SetActive += new System.ComponentModel.CancelEventHandler(this.BasePropertiesPage_SetActive);
            this.WizardNext += new FrameworkOne.VS.Controls.Wizard.WizardPageEventHandler(this.BasePropertiesPage_WizardNext);
            this.WizardBack += new FrameworkOne.VS.Controls.Wizard.WizardPageEventHandler(this.BasePropertiesPage_WizardBack);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
    }
}