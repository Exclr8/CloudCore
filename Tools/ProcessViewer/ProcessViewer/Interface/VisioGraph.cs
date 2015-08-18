using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ProcessViewer.Forms;
using ProcessViewer.Library;
using ProcessViewer.Library.Common;
using ProcessViewer.Library.Shapes;
using Microsoft.Office.Interop.Visio;
using Visio = Microsoft.Office.Interop.Visio;

namespace ProcessViewer.Interface
{
    public class VisioGraph
    {

        private readonly BackgroundWorker _bgWorker;
        private readonly Visio.InvisibleApp _vapp;
        private readonly Visio.Document _stencil;
        private readonly Visio.Document _vdoc;
        private readonly ProgressWindow _progressWindow;
        private readonly ProcessViewerDialog _parent;

        public VisioGraph(ProgressWindow progressWindow, ProcessViewerDialog parent)
        {
            try
            {
                var drawItem = parent.Result;
                _vapp = new Visio.InvisibleApp();

                if (!IsCorrectVisioVersion(_vapp))
                    return;

                _progressWindow = progressWindow;

                _vdoc = _vapp.Documents.Add("");

                if (!File.Exists(_vapp.Path + @"1033\Concept.vss"))
                {
                    File.Delete(_vapp.Path + @"1033\Concept.vss");
                    File.WriteAllBytes(_vapp.Path + @"1033\Concept.vss", Properties.Resources.Concept);
                }

                _stencil = _vapp.Documents.OpenEx(_vapp.Path + @"1033\Concept.vss", (short)Visio.VisOpenSaveArgs.visOpenDocked | (short)Visio.VisOpenSaveArgs.visOpenRO | (short)Visio.VisOpenSaveArgs.visAddStencil);

                _vdoc.Pages[1].Name = "Overview Page";

                _parent = parent;

                _bgWorker = new BackgroundWorker { WorkerReportsProgress = true, WorkerSupportsCancellation = true };
                _bgWorker.DoWork += DoWork;
                _bgWorker.RunWorkerCompleted += RunWorkerCompleted;
                _bgWorker.ProgressChanged += ProgressChanged;

                _progressWindow.pbarTotal.Minimum = 0;

                int totalOperations = 0;
                foreach (var process in drawItem.Process)
                {
                    process.GenerateContent(drawItem.ConnectionString);
                    totalOperations += process.SubProcesses.Count();
                    totalOperations += process.Connectors.Count();
                }

                int stepSize = totalOperations / 20;

                _progressWindow.pbarTotal.Maximum = (totalOperations) + stepSize;

                var args = new WorkerArgs
                               {
                                   DrawItem = drawItem,
                                   StepSize = stepSize,
                               };

                _bgWorker.RunWorkerAsync(args);
            }
            catch (Exception)
            {
                MessageBox.Show(@"Unable to load Visio. Please make sure Visio 2010 has been installed on your system.");
            }
        }

        private static bool IsCorrectVisioVersion(Visio.InvisibleApp vapp)
        {
            try
            {
                var majorVersion = (int)Convert.ToDouble(vapp.Version, CultureInfo.InvariantCulture);
                if (0 == majorVersion || majorVersion < 14)
                {
                    Console.WriteLine(@"Your current version of Visio is not supported. Please install Visio 2010.");
                    vapp.Quit();
                    Utilities.NullAndRelease(vapp);
                    return false;
                }
                return true;
            } catch
            {
                return false;
            }
        }

        #region Public Diagram Methods

        public static void GenerateGraph(DrawItem drawItem, ref Palette palette, string savePath = null)
        {
            var msg = String.Empty;
            GenerateGraph(drawItem, ref palette, ref msg, savePath);
        }

        public static void GenerateGraph(DrawItem drawItem, ref Palette palette, ref string message, string savePath = null)
        {
            try
            {
                if (savePath == null)
                    return;

                var vapp = new Visio.InvisibleApp();

                var vdoc = vapp.Documents.Add("");

  
                try
                {

                    var snopes = new List<Snope>();



                    SetPageLayoutAndRouting(vapp.ActivePage);

                    vapp.ActiveDocument.SaveAs(savePath);
                    vdoc.Saved = true;


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                vapp.Quit();
                Utilities.NullAndRelease(vdoc);
                Utilities.NullAndRelease(vapp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

      
        #endregion

        #region Private Diagram Methods

        private static void DropTaskLinked(Visio.IVDocument stencil, Visio.InvisibleApp vapp, SubProcess task)
        {
            try
            {
                Visio.Selection selection = vapp.ActiveWindow.Selection;


                var taskShape = vapp.ActivePage.Drop(stencil.Masters[task.TemplateShapeName], 0, 0);
                var taskPage = taskShape.CreateSubProcess();
                var taskShapeLink = taskPage.Drop(stencil.Masters[task.TemplateShapeName], 0, 0);
                
                taskPage.Name = task.Title;

                var link = taskShapeLink.Hyperlinks.Add();
                link.Name = "Process";
                link.SubAddress = "Overview Page";

                foreach (var activity in task.Activities)
                {
                    var actShape = taskPage.Drop(stencil.Masters[activity.TemplateShapeName], 0, 0);

                    selection.Select(actShape, (short)Visio.VisSelectionTypes.visSelTypeSingle);
                    actShape.Text = activity.Title;
                    
                    taskShapeLink.ContainerProperties.AddMember(actShape, Visio.VisMemberAddOptions.visMemberAddExpandContainer);

                    if (activity.HasProperty(ActivityProperties.Startable))
                    {
                        var startShape = taskPage.Drop(stencil.Masters["Start"], 0, 0);

                        var vCell1 = startShape.CellsSRC[7, 0, 0];
                        var vCell2 = actShape.CellsSRC[7, 1, 0];

                        vCell1.GlueTo(vCell2);
                    }

                    if (activity.HasProperty(ActivityProperties.Batching))
                    {
                        var batchingShape = taskPage.Drop(stencil.Masters["Batching"], 0, 0);

                        var vCell1 = batchingShape.CellsSRC[7, 0, 0];
                        var vCell2 = actShape.CellsSRC[7, 3, 0];

                        vCell1.GlueTo(vCell2);
                    }

                    if (activity.HasProperty(ActivityProperties.Parked))
                    {
                        var parkedShape = taskPage.Drop(stencil.Masters["Parked"], 0, 0);

                        var vCell1 = parkedShape.CellsSRC[7, 0, 0];
                        var vCell2 = actShape.CellsSRC[7, 5, 0];

                        vCell1.GlueTo(vCell2);
                    }

                    activity.Shape = actShape;
                }

                taskShape.Text = task.Title;
                task.Shape = taskShapeLink;
                SetPageLayoutAndRouting(taskPage);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Unable to draw Task: " + ex.Message);
            }
        }


        private static void DropTask(Visio.IVDocument stencil, Visio.InvisibleApp vapp, SubProcess task)
        {
            try
            {
                Visio.Selection selection = vapp.ActiveWindow.Selection;

                //vapp.ActivePage.PageSheet.CellsSRC[1, 10, 0].FormulaU = "11 in";
                //vapp.ActivePage.PageSheet.CellsSRC[1, 10, 1].FormulaU = "8.5 in";
                //vapp.ActivePage.PageSheet.CellsSRC[1, 25, 16].FormulaForceU = "2";
                
                var taskShape = vapp.ActivePage.Drop(stencil.Masters[task.TemplateShapeName], 0, 0);
                foreach (var activity in task.Activities)
                {
                    var actShape = vapp.ActivePage.Drop(stencil.Masters[activity.TemplateShapeName], 0, 0);
                    if (activity.TemplateShapeName != "Flow Rule")
                    {
                        actShape.Text = activity.Title;
                    }
                    taskShape.ContainerProperties.AddMember(actShape, Visio.VisMemberAddOptions.visMemberAddExpandContainer);

                    if (activity.HasProperty(ActivityProperties.Startable))
                    {
                        var startShape = vapp.ActivePage.Drop(stencil.Masters["Process Start"], 0, 0);
                        taskShape.ContainerProperties.AddMember(startShape, Visio.VisMemberAddOptions.visMemberAddExpandContainer);
                        var vCell1 = startShape.CellsSRC[7, 0, 0];
                        //var vCell2 = (activity.TemplateShapeName == "Flow Rule") ? actShape.CellsSRC[7, 1, 0]  : actShape.CellsSRC[7, 4, 0];
                        var vCell2 = actShape.CellsSRC[7, 4, 0];

                        try
                        {
                            vCell1.GlueTo(vCell2);
                        }
                        catch (Exception ex)
                        {
                            var vCell3 = actShape.CellsSRC[7, 1, 0];
                            vCell1.GlueTo(vCell3);
                        }
                    }

                    //if (activity.HasProperty(ActivityProperties.Batching))
                    //{
                    //    var batchingShape = vapp.ActivePage.Drop(stencil.Masters["Batching"], 0, 0);

                    //    var vCell1 = batchingShape.CellsSRC[7, 0, 0];
                    //    var vCell2 = actShape.CellsSRC[7, 3, 0];

                    //    vCell1.GlueTo(vCell2);
                    //}

                    //if (activity.HasProperty(ActivityProperties.Parked))
                    //{
                    //    var parkedShape = vapp.ActivePage.Drop(stencil.Masters["Parked"], 0, 0);

                    //    var vCell1 = parkedShape.CellsSRC[7, 0, 0];
                    //    var vCell2 = actShape.CellsSRC[7, 5, 0];

                    //    vCell1.GlueTo(vCell2);
                    //}

                    activity.Shape = actShape;
                }

                taskShape.Text = task.Title;
                task.Shape = taskShape;

            } catch (Exception ex)
            {
                throw new ArgumentException("Unable to draw Task: " + ex.Message);
            }

        }


        private static void DropTaskUnGrouped(Visio.IVDocument stencil, Visio.InvisibleApp vapp, SubProcess task)
        {
            try
            {
                Visio.Selection selection = vapp.ActiveWindow.Selection;


                //var taskShape = vapp.ActivePage.Drop(stencil.Masters[subProcess.TemplateShapeName], 0, 0);
                foreach (var activity in task.Activities)
                {
                    var actShape = vapp.ActivePage.Drop(stencil.Masters[activity.TemplateShapeName], 0, 0);
                    actShape.Text = activity.Title;
                    //taskShape.ContainerProperties.AddMember(actShape, Visio.VisMemberAddOptions.visMemberAddExpandContainer);

                    if (activity.HasProperty(ActivityProperties.Startable))
                    {
                        var startShape = vapp.ActivePage.Drop(stencil.Masters["Start"], 0, 0);

                        var vCell1 = startShape.CellsSRC[7, 0, 0];
                        var vCell2 = actShape.CellsSRC[7, 1, 0];

                        vCell1.GlueTo(vCell2);
                    }

                    if (activity.HasProperty(ActivityProperties.Batching))
                    {
                        var batchingShape = vapp.ActivePage.Drop(stencil.Masters["Batching"], 0, 0);

                        var vCell1 = batchingShape.CellsSRC[7, 0, 0];
                        var vCell2 = actShape.CellsSRC[7, 3, 0];

                        vCell1.GlueTo(vCell2);
                    }

                    if (activity.HasProperty(ActivityProperties.Parked))
                    {
                        var parkedShape = vapp.ActivePage.Drop(stencil.Masters["Parked"], 0, 0);

                        var vCell1 = parkedShape.CellsSRC[7, 0, 0];
                        var vCell2 = actShape.CellsSRC[7, 5, 0];

                        vCell1.GlueTo(vCell2);
                    }

                    activity.Shape = actShape;
                }

                //taskShape.Text = subProcess.Title;
                //subProcess.Shape = taskShape;

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Unable to draw Task: " + ex.Message);
            }

        }

        private static void ConnectNodePair(IActivity fromActivity, IActivity toActivity, Visio.InvisibleApp vapp, Visio.IVDocument stencil, Library.Shapes.Connector connector)
        {
            try
            {

                if (fromActivity.Shape == null || toActivity.Shape == null)
                    return;

                Shape fromShape;
                Shape toShape;

                if (fromActivity.Shape.ContainingPage != toActivity.Shape.ContainingPage)
                {
                    fromShape = fromActivity.Parent.Shape;
                    toShape = toActivity.Parent.Shape;
                } else
                {
                    
                    fromShape = fromActivity.Shape;
                    toShape = toActivity.Shape;
                }

                if (fromShape == null || toShape == null)
                    return;

                var connectorShape = fromShape.ContainingPage.Drop(stencil.Masters[connector.TemplateShapeName], 2.50, 2.50);
                connectorShape.Text = connector.Title;

                if (connector.HasProperty(ConnectorProperties.Negative))
                {
                    connectorShape.CellsSRC[(short) Visio.VisSectionIndices.visSectionObject, (short) Visio.VisRowIndices.visRowLine, (short) Visio.VisCellIndices.visLineColor].FormulaU = "THEMEGUARD(RGB(255,0,0))";
                }
                if (connector.HasProperty(ConnectorProperties.Optimal))
                {
                    connectorShape.CellsSRC[(short) Visio.VisSectionIndices.visSectionObject, (short) Visio.VisRowIndices.visRowLine, (short) Visio.VisCellIndices.visLineColor].FormulaU = "THEMEGUARD(RGB(0,255,0))";
                }

                if (connector.HasProperty(ConnectorProperties.Trigger))
                {
                    var triggerShape = fromShape.ContainingPage.Drop(stencil.Masters["Trigger"], 0, 0);

                    var vCell1 = triggerShape.CellsSRC[7, 0, 0];
                    var vCell2 = connectorShape.CellsSRC[7, 0, 0];

                    vCell1.GlueTo(vCell2);
                }

                // get the cell from the source side of the connector
                var beginXCell = connectorShape.CellsSRC[(short) Visio.VisSectionIndices.visSectionObject, (short) Visio.VisRowIndices.visRowXForm1D, (short) Visio.VisCellIndices.vis1DBeginX];

                // glue the source side of the connector to the first shape
                beginXCell.GlueTo(fromShape.CellsSRC[(short) Visio.VisSectionIndices.visSectionObject, (short) Visio.VisRowIndices.visRowXFormOut, (short) Visio.VisCellIndices.visXFormPinX]);
                
                // get the cell from the destination side of the connector
                var endXCell = connectorShape.CellsSRC[(short) Visio.VisSectionIndices.visSectionObject, (short) Visio.VisRowIndices.visRowXForm1D, (short) Visio.VisCellIndices.vis1DEndX];

                // glue the destination side of the connector to the second shape
                endXCell.GlueTo(toShape.CellsSRC[(short) Visio.VisSectionIndices.visSectionObject, (short) Visio.VisRowIndices.visRowXFormOut, (short) Visio.VisCellIndices.visXFormPinX]);

                var arrowCell = connectorShape.CellsSRC[(short) Visio.VisSectionIndices.visSectionObject, (short) Visio.VisRowIndices.visRowLine, (short) Visio.VisCellIndices.visLineEndArrow];
                arrowCell.FormulaU = "5";
            
            } catch (Exception ex)
            {
                throw new ArgumentException("Unable to draw Connector: " + ex.Message);
            }
        }

        private static void SetPageLayoutAndRouting(IVPage page)
        {
            //Top To Buttom
            page.PageSheet.CellsSRC[(short)Visio.VisSectionIndices.visSectionObject, (short)Visio.VisRowIndices.visRowPageLayout, (short)Visio.VisCellIndices.visPLOPlaceStyle].ResultIU = 1;
            page.PageSheet.CellsSRC[(short)Visio.VisSectionIndices.visSectionObject, (short)Visio.VisRowIndices.visRowPageLayout, (short)Visio.VisCellIndices.visPLORouteStyle].ResultIU = 5;

            //Left To Right
            //page.PageSheet.CellsSRC[(short)Visio.VisSectionIndices.visSectionObject, (short)Visio.VisRowIndices.visRowPageLayout, (short)Visio.VisCellIndices.visPLOPlaceStyle].ResultIU = 2;
            //page.PageSheet.CellsSRC[(short)Visio.VisSectionIndices.visSectionObject, (short)Visio.VisRowIndices.visRowPageLayout, (short)Visio.VisCellIndices.visPLORouteStyle].ResultIU = 6;

            page.PageSheet.CellsSRC[(short)Visio.VisSectionIndices.visSectionObject, (short)Visio.VisRowIndices.visRowPageLayout, (short)Visio.VisCellIndices.visPLOLineRouteExt].ResultIU = 2;
            page.PageSheet.CellsSRC[(short)Visio.VisSectionIndices.visSectionObject, (short)Visio.VisRowIndices.visRowPageLayout, (short)Visio.VisCellIndices.visPLOAvenueSizeX].FormulaForceU = "10 mm";
            page.PageSheet.CellsSRC[(short)Visio.VisSectionIndices.visSectionObject, (short)Visio.VisRowIndices.visRowPageLayout, (short)Visio.VisCellIndices.visPLOAvenueSizeY].FormulaForceU = "10 mm";

            page.Layout();
            page.ResizeToFitContents();
        }

        #endregion

        

        void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            _progressWindow.pbarTotal.Value = e.ProgressPercentage;
        }

        void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Result.GetType() == typeof(bool))
            {
                if (!(bool)e.Result)
                {
                    //_vapp.ActiveDocument.Saved = true;
                    //_vapp.Quit();
                }
            }
            else
            {
                _vapp.ActiveDocument.Saved = true;
                _vapp.Quit();
            }
            _progressWindow.Close();
            _parent.Close();
            ReleaseVisio();
        }

        void DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var workerArgs = e.Argument as WorkerArgs;
                var worker = sender as BackgroundWorker;
                if (worker == null || workerArgs == null)
                    return;

                var progress = workerArgs.StepSize;
                e.Result = false;

                worker.ReportProgress(progress);

                foreach (var process in workerArgs.DrawItem.Process)
                {
                    foreach (var task in process.SubProcesses.Where(t => t.Id != 0))
                    {
                        if (worker.CancellationPending)
                        {
                            e.Cancel = true;
                            return;
                        }

                        DropTask(_stencil, _vapp, task);
                        worker.ReportProgress(++progress);
                    }

                    var allActivities = (from t in process.SubProcesses
                                         select t.Activities).SelectMany(x => x);

                    foreach (var connector in process.Connectors)
                    {
                        if (worker.CancellationPending)
                        {
                            e.Cancel = true;
                            return;
                        }

                        worker.ReportProgress(++progress);

                        var fromActivity = allActivities.Single(a => a.Id == connector.FromActivityId);

                        if (connector.ToActivityId == 0)
                        {
                            var stopActivity = new StopActivity()
                                                   {
                                                       Id = 0,
                                                       Parent = fromActivity.Parent,
                                                   };
                            stopActivity.Shape = fromActivity.Shape.ContainingPage.Drop(_stencil.Masters[stopActivity.TemplateShapeName], 0, 0);

                            if (fromActivity.Parent.Shape != null)
                                fromActivity.Parent.Shape.ContainerProperties.AddMember(stopActivity.Shape, Visio.VisMemberAddOptions.visMemberAddExpandContainer);

                            ConnectNodePair(fromActivity, stopActivity, _vapp, _stencil, connector);

                        }
                        else
                        {
                            var fromAct = allActivities.SingleOrDefault(a => a.Id == connector.FromActivityId);
                            var ToAct = allActivities.SingleOrDefault(a => a.Id == connector.ToActivityId);

                            if (fromAct == null || ToAct == null)
                                continue;

                            ConnectNodePair(fromAct, ToAct, _vapp, _stencil, connector);
                        }
                    }
                }

                SetPageLayoutAndRouting(_vapp.ActivePage);

                _vapp.Visible = true;
                e.Result = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ReleaseVisio();
            }
        }

        public void CancelWorker()
        {
            _progressWindow.IsEnabled = false;
            _bgWorker.CancelAsync();

        }

        private void ReleaseVisio()
        {
            Utilities.NullAndRelease(_stencil);
            Utilities.NullAndRelease(_vdoc);
            Utilities.NullAndRelease(_vapp);
        }

    }

    class WorkerArgs
    {
        public DrawItem DrawItem { get; set; }
        public int StepSize { get; set; }
    }
}
