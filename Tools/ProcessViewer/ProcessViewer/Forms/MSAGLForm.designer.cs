namespace ProcessViewer.Interface
{
    partial class MsaglForm
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
            this.Legend = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.GraphViewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.Legend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // Legend
            // 
            this.Legend.AutoScroll = true;
            this.Legend.Controls.Add(this.lblHeader);
            this.Legend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Legend.Location = new System.Drawing.Point(0, 0);
            this.Legend.Name = "Legend";
            this.Legend.Size = new System.Drawing.Size(192, 351);
            this.Legend.TabIndex = 10;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(64, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(49, 16);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Roles";
            // 
            // GraphViewer
            // 
            this.GraphViewer.AsyncLayout = false;
            this.GraphViewer.AutoScroll = true;
            this.GraphViewer.BackwardEnabled = false;
            this.GraphViewer.BuildHitTree = true;
            this.GraphViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GraphViewer.ForwardEnabled = false;
            this.GraphViewer.Graph = null;
            this.GraphViewer.Location = new System.Drawing.Point(0, 0);
            this.GraphViewer.MouseHitDistance = 0.05D;
            this.GraphViewer.Name = "GraphViewer";
            this.GraphViewer.NavigationVisible = true;
            this.GraphViewer.NeedToCalculateLayout = true;
            this.GraphViewer.PanButtonPressed = false;
            this.GraphViewer.SaveButtonVisible = true;
            this.GraphViewer.Size = new System.Drawing.Size(537, 351);
            this.GraphViewer.TabIndex = 9;
            this.GraphViewer.UseLayeredMethod = true;
            this.GraphViewer.ZoomF = 1D;
            this.GraphViewer.ZoomFraction = 0.5D;
            this.GraphViewer.ZoomWindowThreshold = 0.05D;
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(0, 0);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.Legend);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.GraphViewer);
            this.scMain.Size = new System.Drawing.Size(733, 351);
            this.scMain.SplitterDistance = 192;
            this.scMain.TabIndex = 0;
            // 
            // MsaglForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 351);
            this.Controls.Add(this.scMain);
            this.Name = "MsaglForm";
            this.Text = "MSAGLForm";
            this.Load += new System.EventHandler(this.MSAGLForm_Load);
            this.Legend.ResumeLayout(false);
            this.Legend.PerformLayout();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Msagl.GraphViewerGdi.GViewer GraphViewer;
        private System.Windows.Forms.Panel Legend;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.SplitContainer scMain;
    }
}