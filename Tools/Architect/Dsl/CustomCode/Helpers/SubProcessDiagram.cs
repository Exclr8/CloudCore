using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvDTE;
using Architect.CustomCode.Helpers;
using Microsoft.VisualStudio.Modeling;
using Architect;

namespace Architect
{

    public partial class SubProcessDiagram
    {
        public override bool ShouldAutoPlaceChildShapes
        {
            get
            {
                return false;
            }
        }

        protected override Microsoft.VisualStudio.Modeling.Diagrams.ShapeElement CreateChildShape(ModelElement element)
        {
            var btProcess = (SubProcess)ModelElement;

            if (btProcess.VisioId == string.Empty)
                using (Transaction trans = this.Store.TransactionManager.BeginTransaction("create process visio id"))
                {
                    btProcess.VisioId = btProcess.Id.ToString().ToLower();

                    trans.Commit();
                }

            var elementClass = element.GetDomainClass();
            using (Transaction trans = Store.TransactionManager.BeginTransaction("create activity code id"))
            {
                
                if (element is FlowMinimal)
                {
                    if (string.IsNullOrEmpty(((FlowMinimal)element).VisioId))
                        ((FlowMinimal)element).VisioId = element.Id.ToString().ToLower();
                }
                else if (element is Activity)
                {
                    if (string.IsNullOrEmpty(((Activity)element).VisioId))
                        ((Activity)element).VisioId = element.Id.ToString().ToLower();
                }

                trans.Commit();
            }

            switch (elementClass.Name)
            {
                case "CloudcoreUser":
                    SubProcessFiles.AddPage(Store, ((Activity)element).VisioId, btProcess.VisioId);
                    break;
                case "MobileActivity":
                    SubProcessFiles.AddPage(Store, ((Activity)element).VisioId, btProcess.VisioId);
                    break;
                case "HybridActivity":
                    SubProcessFiles.AddPage(Store, ((Activity)element).VisioId, btProcess.VisioId);
                    break;
                case "WorkflowRule":
                    SubProcessFiles.AddSql(Store, ((Activity)element).VisioId, btProcess.VisioId, FileTypes.getFileType(FileType.SqlWorkflowRuleActivity));
                    break;
                case "DatabaseEvent":
                    SubProcessFiles.AddSql(Store, ((Activity)element).VisioId, btProcess.VisioId, FileTypes.getFileType(FileType.SqlCustomActivity));
                    break;
                case "DatabasePark":
                    SubProcessFiles.AddSql(Store, ((Activity)element).VisioId, btProcess.VisioId, FileTypes.getFileType(FileType.SqlParkedActivity));
                    break;
                case "CloudPark":
                    SubProcessFiles.AddClass(Store, ((Activity)element).VisioId, btProcess.VisioId, FileTypes.getFileType(FileType.CloudParkedActivity));
                    break;
                case "CloudCustom":
                    SubProcessFiles.AddClass(Store, ((Activity)element).VisioId, btProcess.VisioId, FileTypes.getFileType(FileType.CloudCustomActivity));
                    break;
                case "PostageApp":
                    SubProcessFiles.AddClass(Store, ((Activity)element).VisioId, btProcess.VisioId, FileTypes.getFileType(FileType.CloudPostageActivity));
                    break;
                case "Email":
                    SubProcessFiles.AddClass(Store, ((Activity)element).VisioId, btProcess.VisioId, FileTypes.getFileType(FileType.Email));
                    break;
                case "Clickatell":
                    SubProcessFiles.AddClass(Store, ((Activity)element).VisioId, btProcess.VisioId, FileTypes.getFileType(FileType.CloudClickatellActivity));
                    break;
                case "DatabaseCosting":
                    SubProcessFiles.AddSql(Store, ((Activity)element).VisioId, btProcess.VisioId, FileTypes.getFileType(FileType.SqlCostingActivity));
                    break;
                case "CloudCosting":
                    SubProcessFiles.AddClass(Store, ((Activity)element).VisioId, btProcess.VisioId, FileTypes.getFileType(FileType.CloudCostingActivity));
                    break;
                case "DatabaseBatchStart":
                    SubProcessFiles.AddSql(Store, ((Activity)element).VisioId, btProcess.VisioId, FileTypes.getFileType(FileType.SqlBatchStartActivity));
                    break;
                case "CloudBatchStart":
                    SubProcessFiles.AddClass(Store, ((Activity)element).VisioId, btProcess.VisioId, FileTypes.getFileType(FileType.CloudBatchStartActivity));
                    break;
                case "BatchWait":
                    SubProcessFiles.AddClass(Store, ((Activity)element).VisioId, btProcess.VisioId, FileTypes.getFileType(FileType.CloudBatchWaitActivity));
                    break;
                case "DatabaseBatchWait":
                    SubProcessFiles.AddSql(Store, ((Activity)element).VisioId, btProcess.VisioId, FileTypes.getFileType(FileType.SqlBatchWaitActivity));
                    break;
                case "Corticon":
                    SubProcessFiles.AddClass(Store, ((Activity)element).VisioId, btProcess.VisioId, FileTypes.getFileType(FileType.CloudCorticonActivity));
                    break;
            }

            return base.CreateChildShape(element);

        }
    }
}
