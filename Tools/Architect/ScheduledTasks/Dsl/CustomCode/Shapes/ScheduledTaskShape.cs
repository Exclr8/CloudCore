using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling.Diagrams;
using Architect.ScheduledTasks.Files;
using Architect.ScheduledTasks.VsEnvironment;
using System.Windows.Forms;

namespace Architect.ScheduledTasks
{
    public partial class ScheduledTaskShape
    {

        public override NodeSides ResizableSides
        {
            get
            {
                return NodeSides.None;
            }
        }

        public override double GridSize
        {
            get
            {
                return 1.7;
            }
            set
            {
                base.GridSize = value;
            }
        }

        public override BoundsRules BoundsRules
        {
            get { return new ScheduledTaskBoundsRules(); }
        }

        public override void OnShapeInserted()
        {
            base.OnShapeInserted();
        }

        public override void OnDoubleClick(Microsoft.VisualStudio.Modeling.Diagrams.DiagramPointEventArgs e)
        {
            OpenScheduledTaskFile();

            base.OnDoubleClick(e);
        }

        private void OpenScheduledTaskFile()
        {
            ScheduledTaskDte dte = new ScheduledTaskDte(ModelElement.Store);

            var scheduledTask = ModelElement as BaseScheduledTask;

            if (scheduledTask != null)
            {
                if (scheduledTask.Type == TaskType.CSharp)
                {
                    dte.DiagramContainerProject.OpenClass(scheduledTask.Id, this.ParentShape.ModelElement.Id);
                }
                else
                {
                    dte.DiagramContainerProject.OpenSql(scheduledTask.Id, this.ParentShape.ModelElement.Id);
                }
            }
        }

        protected override void OnDeleting()
        {
            base.OnDeleting();

            if (ModelElement == null) return;

            var scheduledTask = ModelElement as BaseScheduledTask;

            if (scheduledTask == null)
                return;

            ScheduledTaskDte dte = new ScheduledTaskDte(ModelElement.Store);

            if (scheduledTask.Type == TaskType.CSharp)
            {
                dte.DiagramContainerProject.RemoveClass(scheduledTask.Id, this.ParentShape.ModelElement.Id);
            }
            else
            {
                dte.DiagramContainerProject.RemoveSql(scheduledTask.Id, this.ParentShape.ModelElement.Id);
            }
        }
    }

    public class ScheduledTaskBoundsRules : BoundsRules
    {

        public double Left { get; set; }
        public double Top { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public override RectangleD GetCompliantBounds(ShapeElement shape, RectangleD proposedBounds)
        {
            if (shape.Store.InSerializationTransaction)
                return proposedBounds;

            var scheduledTask = shape as ScheduledTaskShape;

            if (scheduledTask == null) return proposedBounds;

            RectangleD approvedBounds = new RectangleD();
            
            approvedBounds.Location = proposedBounds.Location;
            // But the height and width are constrained:
            approvedBounds.Height = 1.4;
            approvedBounds.Width = 1.6;

            return approvedBounds;
        }
    }
}
