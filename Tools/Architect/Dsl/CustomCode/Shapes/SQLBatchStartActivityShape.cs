using Microsoft.VisualStudio.Modeling.Diagrams;
using Architect.CustomCode.Helpers;

namespace Architect
{
    public partial class SQLBatchStartShape
    {
        protected override void OnDeleting()
        {
            base.OnDeleting();

            if (ModelElement == null)
                return;

            var btBatchDBStart = ModelElement as DatabaseBatchStart;
            var file = FileTypes.getFileType(FileType.SqlBatchStartActivity);

            SubProcessFiles.DeleteSQL(Store, btBatchDBStart.VisioId, btBatchDBStart.SubProcess.VisioId, file);
        }

        public override void OnDoubleClick(DiagramPointEventArgs e)
        {
            base.OnDoubleClick(e);

            var btBatchDBStart = ModelElement as DatabaseBatchStart;
            var file = FileTypes.getFileType(FileType.SqlBatchStartActivity);

            SubProcessFiles.OpenSql(Store, btBatchDBStart.VisioId, btBatchDBStart.SubProcess.VisioId, file);
        }
    }
}
