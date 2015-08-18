using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CloudCore.VSExtension.Controls.Wizard
{
    /// <summary>
    /// Summary description for WizardBanner.
    /// </summary>
    public class WizardBanner : System.Windows.Forms.UserControl
    {
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subtitleLabel;
        
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public WizardBanner()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            // Avoid getting the focus.
            this.SetStyle(ControlStyles.Selectable, false);
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.titleLabel = new System.Windows.Forms.Label();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(16, 8);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(432, 16);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Title";
            // 
            // subtitleLabel
            // 
            this.subtitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.subtitleLabel.Location = new System.Drawing.Point(40, 24);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(408, 32);
            this.subtitleLabel.TabIndex = 1;
            this.subtitleLabel.Text = "Subtitle";
            // 
            // WizardBanner
            // 
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.subtitleLabel);
            this.Controls.Add(this.titleLabel);
            this.Name = "WizardBanner";
            this.Size = new System.Drawing.Size(456, 64);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.WizardBanner_Paint);
            this.ResumeLayout(false);

        }
        #endregion

        [Category("Appearance")]
        public string Title
        {
            get { return titleLabel.Text; }
            set { titleLabel.Text = value; }
        }

        [Category("Appearance")]
        public string Subtitle
        {
            get { return subtitleLabel.Text; }
            set { subtitleLabel.Text = value; }
        }

        private void WizardBanner_Paint(object sender, PaintEventArgs e)
        {
            Brush lightBrush = new SolidBrush(SystemColors.ControlLightLight);
            Brush darkBrush = new SolidBrush(SystemColors.ControlDarkDark);
            Pen lightPen = new Pen(lightBrush, 1);
            Pen darkPen = new Pen(darkBrush, 1);
            e.Graphics.DrawLine(darkPen, 0, this.Height - 2, this.Width, this.Height-2);
            e.Graphics.DrawLine(lightPen, 0, this.Height-1, this.Width, this.Height-1);
        }
    }
}
