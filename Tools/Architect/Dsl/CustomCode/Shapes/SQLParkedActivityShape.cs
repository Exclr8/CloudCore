using Microsoft.VisualStudio.Modeling.Diagrams;
using Architect.CustomCode.Helpers;

namespace Architect
{
    public partial class SQLParkShape
    {
        protected override void OnDeleting()
        {
            base.OnDeleting();

            if (ModelElement == null)
                return;

            var btParkDB = ModelElement as DatabasePark;
            var file = FileTypes.getFileType(FileType.SqlParkedActivity);

            SubProcessFiles.DeleteSQL(Store, btParkDB.VisioId, btParkDB.SubProcess.VisioId, file);
        }

        public override void OnDoubleClick(DiagramPointEventArgs e)
        {
            base.OnDoubleClick(e);

            var btParkDB = ModelElement as DatabasePark;
            var file = FileTypes.getFileType(FileType.SqlParkedActivity);

            SubProcessFiles.OpenSql(Store, btParkDB.VisioId, btParkDB.SubProcess.VisioId, file);
        }
    }
}
