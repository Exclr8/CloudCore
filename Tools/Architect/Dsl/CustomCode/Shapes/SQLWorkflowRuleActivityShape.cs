using Microsoft.VisualStudio.Modeling.Diagrams;
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using Architect.CustomCode.Helpers;

namespace Architect
{
    public partial class WorkflowRuleShape
    {
        protected override void OnDeleting()
        {
            base.OnDeleting();

            if (ModelElement == null)
                return;

            var btRule = ModelElement as WorkflowRule;
            var file = FileTypes.getFileType(FileType.SqlWorkflowRuleActivity);

            SubProcessFiles.DeleteSQL(Store, btRule.VisioId, btRule.SubProcess.VisioId, file);
        }

        public override void OnDoubleClick(DiagramPointEventArgs e)
        {
            base.OnDoubleClick(e);

            var btRule = ModelElement as WorkflowRule;
            var file = FileTypes.getFileType(FileType.SqlWorkflowRuleActivity);

            SubProcessFiles.OpenSql(Store, btRule.VisioId, btRule.SubProcess.VisioId, file);
        }
    }
}
