using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Architect.ScheduledTasks.VsEnvironment;
using EnvDTE;
using EnvDTE80;

namespace Architect.ScheduledTasks
{
    public partial class ScheduledTasksDiagram
    {
        public override Microsoft.VisualStudio.Modeling.Diagrams.SizeD NestedShapesMargin
        {
            get
            {
                return new Microsoft.VisualStudio.Modeling.Diagrams.SizeD(0.05, 0.05);
            }
        }

        protected override Microsoft.VisualStudio.Modeling.Diagrams.ShapeElement CreateChildShape(Microsoft.VisualStudio.Modeling.ModelElement element)
        {
            CreateScheduledTaskFile(element);
            return base.CreateChildShape(element);
        }

        public void CreateScheduledTaskFile(Microsoft.VisualStudio.Modeling.ModelElement scheduledTaskElement)
        {

            ScheduledTaskDte dte = new ScheduledTaskDte(scheduledTaskElement.Store);

            var scheduledTask = scheduledTaskElement as BaseScheduledTask;

            if (scheduledTask != null)
            {
                if (scheduledTask.Type == TaskType.CSharp)
                {
                    dte.DiagramContainerProject.AddClass(scheduledTask.Id, this.ModelElement.Id);
                }
                else
                {
                    dte.DiagramContainerProject.AddSql(scheduledTask.Id, this.ModelElement.Id);
                }
            }
        }
    }
}
