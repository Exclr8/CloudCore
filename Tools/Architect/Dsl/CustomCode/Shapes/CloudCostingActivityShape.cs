using Microsoft.VisualStudio.Modeling.Diagrams;
using Architect.CustomCode.Helpers;

namespace Architect
{
    public partial class CSharpCostingShape
    {
        protected override void OnDeleting()
        {
            base.OnDeleting();

            if (ModelElement == null)
                return;

            var btCostClass = ModelElement as CloudCosting;
            var file = FileTypes.getFileType(FileType.CloudCostingActivity);

            SubProcessFiles.DeleteClass(Store, btCostClass.SubProcess.VisioId, btCostClass.VisioId, file);
        }

        public override void OnDoubleClick(DiagramPointEventArgs e)
        {
            base.OnDoubleClick(e);

            var btCostClass = ModelElement as CloudCosting;
            var file = FileTypes.getFileType(FileType.CloudCostingActivity);

            SubProcessFiles.OpenClass(Store, btCostClass.VisioId, btCostClass.SubProcess.VisioId, file);
        }
    }
}
