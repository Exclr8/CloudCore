using Microsoft.VisualStudio.Modeling.Diagrams;
using Architect.CustomCode.Helpers;

namespace Architect
{
    public partial class CSharpParkShape
    {
        protected override void OnDeleting()
        {
            base.OnDeleting();

            if (ModelElement == null)
                return;

            var btParkCustom = ModelElement as CloudPark;
            var file = FileTypes.getFileType(FileType.CloudParkedActivity);

            SubProcessFiles.DeleteClass(Store, btParkCustom.SubProcess.VisioId, btParkCustom.VisioId, file);
        }

        public override void OnDoubleClick(DiagramPointEventArgs e)
        {
            base.OnDoubleClick(e);

            var btParkCustom = ModelElement as CloudPark;
            var file = FileTypes.getFileType(FileType.CloudParkedActivity);

            SubProcessFiles.OpenClass(Store, btParkCustom.VisioId, btParkCustom.SubProcess.VisioId, file);
        }
    }
}
