using Microsoft.VisualStudio.Modeling.Diagrams;
using Architect.CustomCode.Helpers;

namespace Architect
{
    public partial class CSharpBatchStartShape
    {
        protected override void OnDeleting()
        {
            base.OnDeleting();

            if (ModelElement == null)
                return;

            var btBatchCustomStart = ModelElement as CloudBatchStart;
            var file = FileTypes.getFileType(FileType.CloudBatchStartActivity);

            SubProcessFiles.DeleteClass(Store, btBatchCustomStart.SubProcess.VisioId, btBatchCustomStart.VisioId, file);
        }

        public override void OnDoubleClick(DiagramPointEventArgs e)
        {
            base.OnDoubleClick(e);

            var btBatchCustomStart = ModelElement as CloudBatchStart;
            var file = FileTypes.getFileType(FileType.CloudBatchStartActivity);

            SubProcessFiles.OpenClass(Store, btBatchCustomStart.VisioId, btBatchCustomStart.SubProcess.VisioId, file);
        }
    }
}
