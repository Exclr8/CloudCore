using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProcessViewer.Library.Shapes
{
    public abstract class BaseShape
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Microsoft.Office.Interop.Visio.Shape Shape { get; set; }

        public abstract string TemplateShapeName { get; }
        public abstract bool HasTitle { get; }
        public abstract bool IsDrawable { get; }

    }
}
