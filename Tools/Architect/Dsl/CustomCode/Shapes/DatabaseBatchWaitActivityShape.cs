using Microsoft.VisualStudio.Modeling.Diagrams;
using Architect.CustomCode.Helpers;
using System.Linq;
using System.Data.Linq;

namespace Architect
{
    public partial class DatabaseBatchWaitShape
    {
        protected override void OnDeleting()
        {
            base.OnDeleting();

            if (ModelElement == null)
                return;

            var btBatchWait = ModelElement as DatabaseBatchWait;
            var file = FileTypes.getFileType(FileType.SqlBatchWaitActivity);

            SubProcessFiles.DeleteSQL(Store, btBatchWait.VisioId, btBatchWait.SubProcess.VisioId, file);
        }

        public override void OnDoubleClick(DiagramPointEventArgs e)
        {
            base.OnDoubleClick(e);

            var btBatchWait = ModelElement as DatabaseBatchWait;
            var file = FileTypes.getFileType(FileType.SqlBatchWaitActivity);

            SubProcessFiles.OpenSql(Store, btBatchWait.VisioId, btBatchWait.SubProcess.VisioId, file);
        }
    }
}
