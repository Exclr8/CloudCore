using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Visio;

namespace Architect.Helpers
{
    public class VisioPage
    {
        private Page _page;

        public VisioPage(Page page)
        {
            _page = page;
        }


        public List<ProcessVisioShape> ReadDocument()
        {
            var a = new List<ProcessVisioShape>();

            //a.AddRange(from Shape shape in _page.Shapes
            //           where shape.RootShape != null
            //           select new ProcessVisioShape(shape));

            return a;
        }
 
        public string ProcessName
        {
            get
            {
                return "ProcessName"; //_page.PageSheet.Cells["Prop.ProcessName"].Formula.Replace("\"", string.Empty);
            }
        }

        public string VisioId 
        { 
            get 
            {
                return null; // _page.PageSheet.Cells["User.UniqueVisioID"].Formula.Replace("\"", string.Empty).Replace("{", string.Empty).Replace("}", string.Empty); 
            } 
        }
    }
    public class ProcessVisioReader
    {
        private IVInvisibleApp _app = new InvisibleApp();
        private Document _doc;
        private IList<VisioPage> _pages = new List<VisioPage>();

        public ProcessVisioReader(string filePath)
        {
            OpenVisioDocument(filePath);
        }

        private void OpenVisioDocument(string filePath)
        {
            _doc = _app.Documents.Add(filePath);

            foreach (Page p in _doc.Pages)
            {
                _pages.Add(new VisioPage(p));
            }
        }

        public IList<VisioPage> Pages
        {
            get
            {
                return _pages;
            }
        }

        //public List<BTProcessVisioShape> ReadDocument()
        //{
        //    var a = new List<BTProcessVisioShape>();

        //    a.AddRange(from Shape shape in _page.Shapes
        //               where shape.RootShape != null
        //               select new BTProcessVisioShape(shape));

        //    return a;
        //}

        public void CloseVisio()
        {
            try
            {
                _doc.Saved = true;
                _app.Quit();
                NullAndRelease(_doc);
                NullAndRelease(_app);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        ///  Releases Comm objects
        /// </summary>
        /// <param name="runtimeObject">Object to release</param>
        private void NullAndRelease(object runtimeObject)
        {
            try
            {
                if (runtimeObject != null && System.Runtime.InteropServices.Marshal.IsComObject(runtimeObject))
                {
                    // The RCW's reference count gets incremented each time the
                    // COM pointer is passed from unmanaged to managed code.
                    // Call ReleaseComObject in a loop until it returns 0 to be
                    // sure that the underlying COM object gets released.
                    var referenceCount = System.Runtime.InteropServices.Marshal.ReleaseComObject(runtimeObject);

                    while (0 < referenceCount)
                    {
                        referenceCount = System.Runtime.InteropServices.Marshal.ReleaseComObject(runtimeObject);
                    }
                }
            }
            finally
            {
                runtimeObject = null;
            }
        }

    }

    public class ProcessVisioShape
    {
        #region Constructors

        public ProcessVisioShape(Shape shape)
        {
            if (shape.RootShape == null)
                return;

            dynamic parent = (dynamic)shape.Parent;

            VisShape = shape;
            DetermineType();
            DetermineShapeCategory();
            DetermineDescriptiveText();
            DetermineActivityIsMenuItem();
            DetermineFlowCharacteristics();
            DetermineVisioId();
            //DetermineAllCoordinates();
        }

        #endregion

        #region Private Members

        private readonly List<ProcessVisioShape> _connectors = new List<ProcessVisioShape>();

        #endregion

        #region Properties

        public string DescriptiveText { get; private set; }
        public Shape VisShape { get; set; }
        public ShapeTypes Type { get; private set; }
        public XYCoordinate Coordinates { get; private set; }
        public XYCoordinate TopLeft { get; private set; }
        public double Height { get; private set; }
        public double Width { get; private set; }
        public ProcessVisioShape AttachedTo { get; private set; }
        public List<ProcessVisioShape> Sources { get; private set; }
        public List<ProcessVisioShape> Targets { get; private set; }
        public List<ProcessVisioShape> Connectors { get { return _connectors; } }
        public ShapeTypeCategory ShapeCategory { get; private set; }
        public string Outcome { get; private set; }
        public string StoryLine { get; private set; }
        public string FlowType { get; private set; }
        public bool IsMenuItem { get; private set; }
        public string VisioId { get; private set; }
        public double PageHeight { get; private set; }

        #endregion

        #region Methods

        public void Initialise(List<ProcessVisioShape> shapeList)
        {
            SetAttachedTo(shapeList.FindAll(p => p.ShapeCategory == ShapeTypeCategory.Activity));
            DetermineAllCoordinates();
            LoadSourcesAndTargets(shapeList);
            LoadAllConnectors();
        }

        private void DetermineAllCoordinates()
        {
            Coordinates = new XYCoordinate
            {
                X = VisShape.Cells["PinX"].Result["inches"],
                Y = VisShape.Cells["PinY"].Result["inches"],
            };

            Height = VisShape.Cells["Height"].Result["inches"];
            Width = VisShape.Cells["Width"].Result["inches"];
            PageHeight = VisShape.ContainingPage.Document.PaperHeight["inches"];
          
            if ((ShapeCategory != ShapeTypeCategory.Connector))
            {
                double extra = (ShapeCategory == ShapeTypeCategory.Activity) ? -1 : 0;
                
                double activityVisY = PageHeight - (Coordinates.Y + (Height / 2));

                double activityVisX = (Coordinates.X - (Width/2));
                              
                TopLeft = new XYCoordinate {
                                               X = activityVisX,
                                               Y = activityVisY
                                           };
            }
        }

        private void DetermineVisioId()
        {
            VisioId = VisShape.Cells["User.UniqueVisioID"].Formula.Replace("\"", string.Empty).Replace("{", string.Empty).Replace("}", string.Empty).ToLower();
        }

        private void DetermineActivityIsMenuItem()
        {
            if (Type != ShapeTypes.PageActivity)
            {
                IsMenuItem = false;
                return;
            }
            //Prop.IsMenuItem
            IsMenuItem = VisShape.Cells["Prop.IsMenuItem.Value"].ResultStr[0].Replace("\"", string.Empty) == "Yes";
        }

        private void DetermineFlowCharacteristics()
        {
            if (ShapeCategory != ShapeTypeCategory.Connector)
            {
                Outcome = string.Empty;
                StoryLine = string.Empty;
                FlowType = string.Empty;
                return;
            }

            Outcome = VisShape.Cells["Prop.Row_2.Value"].Formula.Replace("\"", string.Empty);
            StoryLine = VisShape.Cells["Prop.Storyline.Value"].Formula.Replace("\"", string.Empty);

            string fType = VisShape.Cells["Prop.FlowType.Value"].ResultStr[0].Replace("\"", string.Empty);

            FlowType = (fType == "0.0000") ? string.Empty : fType;
        }

        private void DetermineType()
        {
            var tStr = VisShape.RootShape.Name.Replace(" ", string.Empty);
            var pos = tStr.IndexOf(".");

            if (pos != -1)
                tStr = tStr.Substring(0, pos);

            Type = (ShapeTypes)Enum.Parse(typeof(ShapeTypes), tStr);
        }

        private void DetermineDescriptiveText()
        {
            DescriptiveText = (Type == ShapeTypes.FlowConnector || VisShape.RootShape.Text == string.Empty) ? this.VisShape.Name : VisShape.RootShape.Text;
        }

        private void DetermineShapeCategory()
        {
            if (Type == ShapeTypes.Start || Type == ShapeTypes.Delay || Type == ShapeTypes.DocumentWait || Type == ShapeTypes.Email || Type == ShapeTypes.Batching || Type == ShapeTypes.Branching || Type == ShapeTypes.Recurring || Type == ShapeTypes.Terminate)
            {
                ShapeCategory = ShapeTypeCategory.Attachment;
            }
            else
            {
                ShapeCategory = (Type == ShapeTypes.FlowConnector ? ShapeTypeCategory.Connector : ShapeTypeCategory.Activity);
            }
        }

        private void SetAttachedTo(IEnumerable<ProcessVisioShape> shapeList)
        {
            if (ShapeCategory == ShapeTypeCategory.Attachment)
                foreach (ProcessVisioShape shape in shapeList)
                {
                    var x = VisShape.SpatialRelation[shape.VisShape, 0, (short)VisSpatialRelationFlags.visSpatialBackToFront];

                    AttachedTo = (x > 0) ? shape : null;

                    if (x > 0)
                        return;

                }
        }

        private void LoadSourcesAndTargets(IEnumerable<ProcessVisioShape> shapeList)
        {
            if (ShapeCategory != ShapeTypeCategory.Activity) return;

            Sources = (from int a in VisShape.ConnectedShapes(VisConnectedShapesFlags.visConnectedShapesIncomingNodes, "")
                        select shapeList.FirstOrDefault(s => s.VisShape.ID == Convert.ToInt16(a))).ToList().FindAll(p => (p != null) && (p.ShapeCategory == ShapeTypeCategory.Activity));

            Targets = (from int a in VisShape.ConnectedShapes(VisConnectedShapesFlags.visConnectedShapesOutgoingNodes, "")
                        select shapeList.FirstOrDefault(s => s.VisShape.ID == Convert.ToInt16(a))).ToList().FindAll(p => (p != null) &&  (p.ShapeCategory == ShapeTypeCategory.Activity));
        }

        public List<ProcessVisioShape> GetConnectors(ProcessVisioShape OtherShape)
        {
            return OtherShape.Connectors.Select(n => Connectors.FirstOrDefault(p => p.VisShape.ID == n.VisShape.ID)).ToList();
        }

        private void LoadAllConnectors()
        {
            Connects connectsSources = VisShape.FromConnects;

            foreach (Connect c in connectsSources)
            {
                if (c.FromSheet == null) continue;

                var x = new ProcessVisioShape(c.FromSheet)
                        {
                            VisioId = c.FromSheet.Cells["User.UniqueVisioID"].Formula.Replace("\"", string.Empty).Replace("{", string.Empty).Replace("}", string.Empty)
                        };

                if (x.ShapeCategory == ShapeTypeCategory.Connector)
                    _connectors.Add(x);
            }
        }

        #endregion
    }

    public class XYCoordinate
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    public enum ShapeTypeCategory
    {
        Activity,
        Attachment,
        Connector,
    }

    public enum ShapeTypes
    {
        PageActivity,
        FlowConnector,
        DatabaseActivity,
        BusinessRule,
        Start,
        Completed,
        Parked,
        Email,
        Delay,
        Batching,
        Branching,
        DocumentWait,
        Recurring,
        Terminate,
        SubProcess,
        WebWorker
    }
}
