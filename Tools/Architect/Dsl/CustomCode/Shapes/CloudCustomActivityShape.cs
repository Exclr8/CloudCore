using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Diagrams;
using Architect.CustomCode.Helpers;

namespace Architect
{
    public partial class CSharpEventShape
    {
        
        protected override void OnDeleting()
        {
            base.OnDeleting();

            if (ModelElement == null)
                return;

            var btPage = ModelElement as CloudCustom;
            var file = FileTypes.getFileType(FileType.CloudCustomActivity);

            SubProcessFiles.DeleteClass(Store, btPage.SubProcess.VisioId, btPage.VisioId, file);
        }

        public override void OnDoubleClick(DiagramPointEventArgs e)
        {
            base.OnDoubleClick(e);

            var btPage = ModelElement as CloudCustom;
            var file = FileTypes.getFileType(FileType.CloudCustomActivity);

            SubProcessFiles.OpenClass(Store, btPage.VisioId, btPage.SubProcess.VisioId, file);
        }
        
    }

    
}
