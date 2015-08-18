using System;
using System.Collections.Generic;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace CloudCore.VSExtension.Controls.Wizard
{
    public class WizardForm : System.Windows.Forms.Form
    {

        public WizardForm()
		{
            try
            {
                InitializeComponent();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
         
		}

        [Category("Wizard")]
        public event WizardPageEventHandler WizardFinish;

        private void OnWizardFormFinish(WizardPageEventArgs e)
        {
            _activePage.OnWizardFinish(e);
            if (WizardFinish != null)
            {
                
                WizardFinish(this, e);
            }
        }

        [Category("Wizard")]
        public event CancelEventHandler WizardCancel;

        private void OnWizardFormCancel(CancelEventArgs e)
        {
            _activePage.OnWizardCancel(e);
            if (WizardCancel != null)
            {
                
                WizardCancel(this, e);

            }
        }


		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.backButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.finishButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.pagePanel = new System.Windows.Forms.Panel();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.backButton.Location = new System.Drawing.Point(132, 8);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 0;
            this.backButton.Text = "< &Back";
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nextButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.nextButton.Location = new System.Drawing.Point(208, 8);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 23);
            this.nextButton.TabIndex = 1;
            this.nextButton.Text = "&Next >";
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // finishButton
            // 
            this.finishButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.finishButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.finishButton.Location = new System.Drawing.Point(208, 8);
            this.finishButton.Name = "finishButton";
            this.finishButton.Size = new System.Drawing.Size(75, 23);
            this.finishButton.TabIndex = 2;
            this.finishButton.Text = "&Finish";
            this.finishButton.Click += new System.EventHandler(this.finishButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cancelButton.Location = new System.Drawing.Point(296, 8);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.cancelButton);
            this.buttonPanel.Controls.Add(this.backButton);
            this.buttonPanel.Controls.Add(this.finishButton);
            this.buttonPanel.Controls.Add(this.nextButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 101);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(384, 40);
            this.buttonPanel.TabIndex = 4;
            this.buttonPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonPanel_Paint);
            // 
            // pagePanel
            // 
            this.pagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pagePanel.Location = new System.Drawing.Point(0, 0);
            this.pagePanel.Name = "pagePanel";
            this.pagePanel.Size = new System.Drawing.Size(700, 400);
            this.pagePanel.TabIndex = 5;
            // 
            // WizardForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(700, 450);
            this.Controls.Add(this.pagePanel);
            this.Controls.Add(this.buttonPanel);
            this.KeyPreview = true;
            this.Name = "WizardForm";
            this.Text = "WizardSheet";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.WizardSheet_Closing);
            this.Load += new System.EventHandler(this.WizardSheet_Load);
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private System.Windows.Forms.Button backButton;
		private System.Windows.Forms.Button nextButton;
		private System.Windows.Forms.Button finishButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Panel buttonPanel;
		private System.Windows.Forms.Panel pagePanel;

        private List<WizardPage> _pages = new List<WizardPage>();
		private WizardPage _activePage;

		private void WizardSheet_Load(object sender, System.EventArgs e)
		{
			if (_pages.Count != 0)
			{
				ResizeToFit();
				SetActivePage(0);
			}
			else
				SetWizardButtons(WizardButtons.None);
		}

		public void ResizeToFit()
		{
			Size maxPageSize = new Size(buttonPanel.Width, 0);

			foreach (WizardPage page in _pages)
			{
				if (page.Width > maxPageSize.Width)
					maxPageSize.Width = page.Width;
				if (page.Height > maxPageSize.Height)
					maxPageSize.Height = page.Height;
			}

			foreach (WizardPage page in _pages)
			{
				page.Size = maxPageSize;
			}

			Size extraSize = this.Size;
			extraSize -= pagePanel.Size;

			Size newSize = maxPageSize + extraSize;
			this.Size = newSize;
		}

        public List<WizardPage> Pages
		{
			get { return _pages; }
		}

		private int GetActiveIndex()
		{
            return _pages.IndexOf(_activePage);
		}

		private WizardPage GetActivePage()
		{
			return _activePage;
		}
		
		public void SetActivePage(int pageIndex)
		{
			if (pageIndex < 0 || pageIndex >= _pages.Count)
				throw new ArgumentOutOfRangeException("pageIndex");

            SetActivePage(_pages[pageIndex]);
		}

		private WizardPage FindPage(string pageName)
		{
			foreach (WizardPage page in _pages)
			{
				if (page.Name == pageName)
					return page;
			}

			return null;
		}

		private void SetActivePage(WizardPage newPage)
		{
			WizardPage oldActivePage = _activePage;

			// If this page isn't in the Controls collection, add it.
			// This is what causes the Load event, so we defer
			// it as late as possible.
			if (!pagePanel.Controls.Contains(newPage))
				pagePanel.Controls.Add(newPage);
			
			// Show this page.
			newPage.Visible = true;

			_activePage = newPage;
			CancelEventArgs e = new CancelEventArgs();
			newPage.OnSetActive(e);

			if (e.Cancel)
			{
				newPage.Visible = false;
				_activePage = oldActivePage;
			}

			// Hide all of the other pages.
			foreach (WizardPage page in _pages)
			{
				if (page != _activePage)
					page.Visible = false;
			}
		}

        internal bool NextButtonEnabled { get { return nextButton.Enabled; } set { nextButton.Enabled = value; } }

		internal void SetWizardButtons(WizardButtons buttons)
		{
			// The Back button is simple.
			backButton.Enabled = ((buttons & WizardButtons.Back) != 0);

			// The Next button is a bit more complicated. If we've got a Finish button, then it's disabled and hidden.
			if ((buttons & WizardButtons.Finish) != 0)
			{
				finishButton.Visible = true;
				finishButton.Enabled = true;

				nextButton.Visible = false;
				nextButton.Enabled = false;

				//this.AcceptButton = finishButton;
			}
			else
			{
				finishButton.Visible = false;
				finishButton.Enabled = false;

				nextButton.Visible = true;
				nextButton.Enabled = ((buttons & WizardButtons.Next) != 0);

				//this.AcceptButton = nextButton;
			}
		}

		private WizardPageEventArgs PreChangePage(int delta)
		{
			// Figure out which page is next.
			int activeIndex = GetActiveIndex();
			int nextIndex = activeIndex + delta;

            if (nextIndex < 0 || nextIndex >= _pages.Count)
            {
                nextIndex = activeIndex;
                MessageBox.Show("Cant move");
            }

			WizardPageEventArgs e = new WizardPageEventArgs();
            e.NewPage = _pages[nextIndex];
			e.Cancel = false;

			return e;
		}

		private void PostChangePage(WizardPageEventArgs e)
		{
			if (!e.Cancel)
				SetActivePage(e.NewPage);
		}

		private void nextButton_Click(object sender, System.EventArgs e)
		{
            _activePage.OnWizardPreNext();
            try
            {
                WizardPageEventArgs wpea = PreChangePage(+1);
                _activePage.OnWizardNext(wpea);
                PostChangePage(wpea);
            } catch (Exception Ex) {
                MessageBox.Show(Ex.Message);
            }
		}

		private void backButton_Click(object sender, System.EventArgs e)
		{
			WizardPageEventArgs wpea = PreChangePage(-1);
			_activePage.OnWizardBack(wpea);
			PostChangePage(wpea);
		}

		private void finishButton_Click(object sender, System.EventArgs e)
		{
			WizardPageEventArgs cea = new WizardPageEventArgs();
			OnWizardFormFinish(cea);
			if (cea.Cancel)
				return;

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		internal void PressButton(WizardButtons buttons)
		{
			if ((buttons & WizardButtons.Finish) == WizardButtons.Finish)
				finishButton.PerformClick();
			else if ((buttons & WizardButtons.Next) == WizardButtons.Next)
				nextButton.PerformClick();
			else if ((buttons & WizardButtons.Back) == WizardButtons.Back)
				backButton.PerformClick();
		}

		internal void EnableCancelButton(bool enableCancelButton)
		{
			cancelButton.Enabled = enableCancelButton;
		}

		private void cancelButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void WizardSheet_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (!cancelButton.Enabled)
				e.Cancel = true;
			else if (!finishButton.Enabled)
                OnWizardFormCancel(e);
		}

        private void buttonPanel_Paint(object sender, PaintEventArgs e)
        {
            Brush lightBrush = new SolidBrush(SystemColors.ControlLightLight);
            Brush darkBrush = new SolidBrush(SystemColors.ControlDarkDark);
			Pen lightPen = new Pen(lightBrush, 1);
			Pen darkPen = new Pen(darkBrush, 1);
			e.Graphics.DrawLine(darkPen, 0, 0, buttonPanel.Width, 0);
			e.Graphics.DrawLine(lightPen, 0, 1, buttonPanel.Width, 1);
        }
	}

	[Flags]
	public enum WizardButtons
	{
		None = 0x0000,
		Back = 0x0001,
		Next = 0x0002,
		Finish = 0x0004,
	}

}
