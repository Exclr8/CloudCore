using Microsoft.VisualStudio.Modeling.Diagrams;
using Architect.CustomCode.Helpers;

namespace Architect
{
    public partial class SQLCostingShape
    {
        protected override void OnDeleting()
        {
            base.OnDeleting();

            if (ModelElement == null)
                return;

            var btCostDB = ModelElement as DatabaseCosting;
            var file = FileTypes.getFileType(FileType.SqlCostingActivity);

            SubProcessFiles.DeleteSQL(Store, btCostDB.VisioId, btCostDB.SubProcess.VisioId, file);
        }

        public override void OnDoubleClick(DiagramPointEventArgs e)
        {
            base.OnDoubleClick(e);

            var btCostDB = ModelElement as DatabaseCosting;
            var file = FileTypes.getFileType(FileType.SqlCostingActivity);

            SubProcessFiles.OpenSql(Store, btCostDB.VisioId, btCostDB.SubProcess.VisioId, file);
        }
    }
}
