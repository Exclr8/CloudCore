using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling.Integration;
using Microsoft.VisualStudio.Modeling;
//using Architect.ProcessOverview.CustomCode.Shapes;
using Microsoft.VisualStudio.Modeling.Immutability;
using EnvDTE;

namespace Architect.ProcessOverview
{
    public partial class SubProcessShape
    {
        public override void OnDoubleClick(Microsoft.VisualStudio.Modeling.Diagrams.DiagramPointEventArgs e)
        {
            base.OnDoubleClick(e);

            IModelBus modelBus = this.Store.GetService(typeof(SModelBus)) as IModelBus;
            ModelBusReference reference = ((SubProcessElement)this.ModelElement).SubProcessRef;
            ModelBusAdapter adapter = modelBus.CreateAdapter(reference);
            ModelBusView view = adapter.GetDefaultView();

            if (view != null)
            {
                view.Open();
                view.SetSelection(reference);
                view.Show();
            }

            adapter.Dispose();
        }

        public override void OnShapeInserted()
        {
            base.OnShapeInserted();

            this.ModelElement.SetLocks(Locks.Delete | Locks.Add | Locks.Move | Locks.Properties);
        }


    }
}