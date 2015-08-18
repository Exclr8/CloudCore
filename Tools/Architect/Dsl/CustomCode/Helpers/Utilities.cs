using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;
using System.Diagnostics.Contracts;
using Microsoft.VisualStudio.Modeling.Diagrams;
using Microsoft.VisualStudio.Modeling.Shell;
using Microsoft.VisualStudio.Modeling.Integration;

namespace Architect
{
    public static class Utilities
    {
        public static string GetFileNameForStore(Store store)
        {
            Contract.Requires(store != null);

            foreach (Diagram diagram in store.ElementDirectory.FindElements<Diagram>(true))
            {
                VSDiagramView view = diagram.ActiveDiagramView as VSDiagramView;
                if (view != null)
                {
                    // Get the corresponding file
                    string filename = view.DocData.FileName.Substring(view.DocData.FileName.LastIndexOf('\\') + 1);
                    return filename;
                }
            }
            return string.Empty;
        }

        public static T GetExternalActivityUsingModelBus<T>(ModelBusReference reference, IModelBus modelBus)
        {
            T ret;

            using (var adapter = modelBus.CreateAdapter(reference))
                ret = (T)adapter.ResolveElementReference(reference);

            return ret;
        }
    }


}
