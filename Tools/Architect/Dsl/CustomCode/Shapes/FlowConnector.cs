using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Diagrams;
using Architect.CustomCode.Helpers;

namespace Architect
{
    public partial class FlowConnector
    {
        public override void OnShapeInserted()
        {
            base.OnShapeInserted();

            var flow = ModelElement as Flow;
            using (Transaction trans = this.Store.TransactionManager.BeginTransaction("create connector visioid"))
            {
                if (string.IsNullOrEmpty(flow.VisioId))
                    flow.VisioId = ModelElement.Id.ToString().ToLower();

                trans.Commit();
            }
        }

        protected override void OnBeforePaint()
        {
            base.OnBeforePaint();

            var flw = (Flow)ModelElement;
            System.Drawing.Color currentColour;
            switch (flw.Type)
            {
                case FlowType.Optimal:
                    currentColour = System.Drawing.Color.Green;
                    break;
                case FlowType.Negative:
                    currentColour = System.Drawing.Color.Red;
                    break;
                default:
                    currentColour = System.Drawing.Color.Blue;
                    break;
            }

            if (Color == currentColour)
                return;

            using (var transaction = Store.TransactionManager.BeginTransaction("Changing line colour"))
            {
                Color = currentColour;
                transaction.Commit();
            }
        }

    }

    
}
