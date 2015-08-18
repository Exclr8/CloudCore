using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Diagrams;
using Architect.CustomCode.Helpers;

namespace Architect
{
    public partial class CorticonShape
    {
        
        protected override void OnDeleting()
        {
            base.OnDeleting();

            if (ModelElement == null)
                return;

            var corticon = ModelElement as Corticon;
            var file = FileTypes.getFileType(FileType.CloudCorticonActivity);

            SubProcessFiles.DeleteClass(Store, corticon.SubProcess.VisioId, corticon.VisioId, file);
        }

        public override void OnDoubleClick(DiagramPointEventArgs e)
        {
            base.OnDoubleClick(e);

            var corticon = ModelElement as Corticon;
            var file = FileTypes.getFileType(FileType.CloudCorticonActivity);

            SubProcessFiles.OpenClass(Store, corticon.VisioId, corticon.SubProcess.VisioId, file);
        }
        
    }

    
}
