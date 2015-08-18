using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Diagrams;

namespace Architect
{
    public partial class BaseActivityShape
    {
        public override void OnShapeInserted()
        {
            base.OnShapeInserted();

            double gridXCounter = CalculatePosition(this.GridSize, this.Bounds.Center.X);
            double gridYCounter = CalculatePosition(this.GridSize, this.Bounds.Center.Y);

            using (Transaction t = this.Store.TransactionManager.BeginTransaction("Reposition Shape"))
            {
                this.Location = new PointD(gridXCounter, gridYCounter);
                t.Commit();
            }
        }

        private double CalculatePosition(double gridSize, double shapeCenterPosition)
        {
            double gridCounter = 0;
            do
            {
                if (shapeCenterPosition < gridCounter)
                {
                    gridCounter -= gridSize;
                    break;
                }

                gridCounter += gridSize;
            } while (true);

            return gridCounter;
        }

        public override BoundsRules BoundsRules
        {
            get
            {
                return new BaseActivityShapeBoundsRules();
            }
        }

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
                return 1.5;
            }
            set
            {
                base.GridSize = value;
            }
        }         
    }

    public class BaseActivityShapeBoundsRules : BoundsRules
    {
        public double Left { get; set; }
        public double Top { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public override RectangleD GetCompliantBounds(ShapeElement shape, RectangleD proposedBounds)
        {
            if (shape.Store.InSerializationTransaction)
                return proposedBounds;

            double width = 0.83675;
            double height = 0.83675;

            if (shape is StartableShape || shape is BatchWaitShape || shape is DatabaseBatchWaitShape)
            {
                width = 1.243;
                height = 0.84025;
            }
            else if (shape is WorkflowRuleShape)
            {
                width = 1.2395;
                height = 0.84025;
            }


            var activityShape = shape as BaseActivityShape;

            if (activityShape == null) return proposedBounds;

            var approvedBounds = new RectangleD();

            approvedBounds.Location = proposedBounds.Location;
            // But the height and width are constrained:
            approvedBounds.Height = height;
            approvedBounds.Width = width;

            return approvedBounds;
        }
    }
}
