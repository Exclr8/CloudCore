using Microsoft.VisualStudio.Modeling.Diagrams;
using Architect.CustomCode.Helpers;
using System.Linq;

namespace Architect
{
    public partial class SQLEventShape
    {
        protected override void OnDeleting()
        {
            base.OnDeleting();

            if (ModelElement == null)
                return;

            var btEvent = ModelElement as DatabaseEvent;
            var file = FileTypes.getFileType(FileType.SqlCustomActivity);

            SubProcessFiles.DeleteSQL(this.Store, btEvent.VisioId, btEvent.SubProcess.VisioId, file);
        }

        public override void OnDoubleClick(DiagramPointEventArgs e)
        {
            base.OnDoubleClick(e);

            var btEvent = ModelElement as DatabaseEvent;
            var file = FileTypes.getFileType(FileType.SqlCustomActivity);

            SubProcessFiles.OpenSql(Store, btEvent.VisioId, btEvent.SubProcess.VisioId, file);
        }
    }
}
