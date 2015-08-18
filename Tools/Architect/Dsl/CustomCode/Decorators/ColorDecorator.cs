using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslDesign = global::Microsoft.VisualStudio.Modeling.Design;
using DslDiagrams = global::Microsoft.VisualStudio.Modeling.Diagrams;
using System.Drawing.Drawing2D;

namespace Architect.CustomCode.Decorators
{
    class ColorDecorator : DslDiagrams.LinkDecorator
    {
        protected override GraphicsPath GetPath(DslDiagrams.RectangleD bounds)
        {
            var path = DecoratorPath;
            //Fill the circle
            this.FillDecorator = true;
            
            //Draw an ellipse, moving the top left to compensate for line width

            //TODO: Figure out how to retrieve the line width programmatically. DslDefinition.Connector.Thickness

            //path.AddEllipse((float)(bounds.X + .01), (float)(bounds.Y + .01), (float)(bounds.Width * .8), (float)(bounds.Height * .8));
            //path.AddLines()
            return path;
        }

        public override void DoPaintShape(DslDiagrams.RectangleD bounds, DslDiagrams.IGeometryHost shape, DslDiagrams.DiagramPaintEventArgs e)
        {
            base.DoPaintShape(bounds, shape, e);
            //e.Graphics.
        }
    }
}
