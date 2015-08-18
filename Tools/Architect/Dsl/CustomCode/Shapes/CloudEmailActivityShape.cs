using Microsoft.VisualStudio.Modeling.Diagrams;
using Architect.CustomCode.Helpers;

namespace Architect
{
    public partial class EmailShape
    {
        protected override void OnDeleting()
        {
            base.OnDeleting();

            if (ModelElement == null)
                return;

            var btEvent = ModelElement as Email;
            var file = FileTypes.getFileType(FileType.CloudPostageActivity);

            SubProcessFiles.DeleteClass(Store, btEvent.SubProcess.VisioId, btEvent.VisioId, file);
        }

        public override void OnDoubleClick(DiagramPointEventArgs e)
        {
            base.OnDoubleClick(e);

            var btEvent = ModelElement as Email;
            var file = FileTypes.getFileType(FileType.CloudPostageActivity);

            SubProcessFiles.OpenClass(Store, btEvent.VisioId, btEvent.SubProcess.VisioId, file);
        }
    }
}
