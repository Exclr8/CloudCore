using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using ProcessViewer.Library;
using ProcessViewer.Library.Common;
using ProcessViewer.Library.Data;
using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;
using System.Data.Linq;
using System.Linq;

namespace ProcessViewer.Interface
{
    public partial class MsaglForm : Form
    {
        #region Fields

        private Palette _palette;
        private readonly DrawItem _result;

        #endregion

        #region Constructor

        public MsaglForm(DrawItem result)
        {
            InitializeComponent();
            _palette = new Palette(2, 20, 10);
            _result = result;
        }

        #endregion

        #region Method Overides

        private void MSAGLForm_Load(object sender, EventArgs e)
        {
            DrawDiagram();
        }

        #endregion

        #region Methods

        private void DrawDiagram()
        {
            base.Text = "ProcessViewer " + _result.Version + " -  " + _result.ViewLevel + " Flow";
            GraphViewer.Graph = MsaglGraph.GenerateGraph(_result, ref _palette);

            if (_result.ViewLevel == ViewLevel.Activity)
                lblHeader.Text = "SubProcesses";
            else if (_result.ViewLevel == ViewLevel.SubProcess)
                lblHeader.Text = "Processes";

            //Check if the colour property is set
            if (Options.Colour == (Options.Colour & _result.Options))
            {
                DrawLegend();
            } else
            {
                scMain.Panel1Collapsed = true;
            }
        }

        private void DrawLegend()
        {
            const int x = 5;
            const int w = 10;
            const int h = 10;
            var y = 40;

            var pcl = _palette.ColorList;

            foreach (var col in pcl)
            {
                var lblCol = new System.Windows.Forms.Label {Width = w, Height = h, BackColor = col.Color};
                Legend.Controls.Add(lblCol);
                lblCol.Location = new Point(x, y);

                var lblDescr = new System.Windows.Forms.Label {AutoSize = true, Text = col.Label};
                Legend.Controls.Add(lblDescr);
                lblDescr.Location = new Point((w + 5) + 5, (y - 2));
                lblDescr.Font = new Font("Microsoft Sans Serif", 7F, FontStyle.Regular, GraphicsUnit.Point, 0);
                y += (h + 8);
            }
        }

        #endregion
    }
}
