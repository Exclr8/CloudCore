using Microsoft.VisualStudio.Modeling.Diagrams;
using Architect.CustomCode.Helpers;

namespace Architect
{
    public partial class ClickatellShape
    {
        protected override void OnDeleting()
        {
            base.OnDeleting();

            if (ModelElement == null)
                return;

            var btEvent = ModelElement as Clickatell;
            var file = FileTypes.getFileType(FileType.CloudClickatellActivity);

            SubProcessFiles.DeleteClass(Store, btEvent.SubProcess.VisioId, btEvent.VisioId, file);
        }

        public override void OnDoubleClick(DiagramPointEventArgs e)
        {
            base.OnDoubleClick(e);

            var btEvent = ModelElement as Clickatell;
            var file = FileTypes.getFileType(FileType.CloudClickatellActivity);

            SubProcessFiles.OpenClass(Store, btEvent.VisioId, btEvent.SubProcess.VisioId, file);
        }
    }
}
