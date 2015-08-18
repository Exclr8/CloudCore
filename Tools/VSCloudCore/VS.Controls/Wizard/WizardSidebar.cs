using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CloudCore.VSExtension.Controls.Wizard
{
    /// <summary>
    /// Summary description for WizardSidebar.
    /// </summary>
    public class WizardSidebar : System.Windows.Forms.UserControl
    {
        public WizardSidebar()
        {
            this.Dock = DockStyle.Left;

            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
            // Set a default image.
            this.BackgroundImage = new Bitmap(this.GetType(), "Bitmap.WizardImage.bmp"); ;
            // Avoid getting the focus.
            this.SetStyle(ControlStyles.Selectable, false);

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // WizardSidebar
            // 
            this.Name = "WizardSidebar";
            this.Size = new System.Drawing.Size(240, 400);
            this.ResumeLayout(false);

        }
    }
}
