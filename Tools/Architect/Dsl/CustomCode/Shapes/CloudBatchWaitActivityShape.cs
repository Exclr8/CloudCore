﻿using Microsoft.VisualStudio.Modeling.Diagrams;
using Architect.CustomCode.Helpers;
using System.Linq;
using System.Data.Linq;

namespace Architect
{
    public partial class BatchWaitShape
    {
        protected override void OnDeleting()
        {
            base.OnDeleting();

            if (ModelElement == null)
                return;

            var btBatchWait = ModelElement as CloudBatchWait;
            var file = FileTypes.getFileType(FileType.CloudBatchWaitActivity);

            SubProcessFiles.DeleteClass(Store, btBatchWait.VisioId, btBatchWait.SubProcess.VisioId, file);
        }

        public override void OnDoubleClick(DiagramPointEventArgs e)
        {
            base.OnDoubleClick(e);

            var btBatchWait = ModelElement as CloudBatchWait;
            var file = FileTypes.getFileType(FileType.CloudBatchWaitActivity);

            SubProcessFiles.OpenClass(Store, btBatchWait.VisioId, btBatchWait.SubProcess.VisioId, file);
        }
    }
}
