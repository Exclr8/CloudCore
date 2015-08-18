using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Diagrams;
using Architect.CustomCode.Helpers;

namespace Architect
{
    public partial class MobileShape 
    {
        protected override void OnDeleting()
        {
            base.OnDeleting();

            if (ModelElement == null)
                return;

            var btPage = ModelElement as MobileActivity;

            SubProcessFiles.DeletePage(Store, btPage.VisioId, btPage.SubProcess.VisioId);
        }

        public override void OnDoubleClick(DiagramPointEventArgs e)
        {
            base.OnDoubleClick(e);

            var btPage = ModelElement as MobileActivity;

            SubProcessFiles.OpenView(Store, btPage.VisioId, btPage.SubProcess.VisioId);
        }
        
    }

    
}
