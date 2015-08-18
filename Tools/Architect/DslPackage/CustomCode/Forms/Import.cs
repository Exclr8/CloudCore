using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EnvDTE;
using Architect.CustomCode.Helpers;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Diagrams;
using Microsoft.VisualStudio.Shell;
using Visio = Microsoft.Office.Interop.Visio;
using Architect.Helpers;
using Microsoft.VisualStudio.Modeling.Integration;
using Architect.ModelBusAdapters;


namespace Architect.CustomCode.Forms
{
    public partial class Import : Form
    {
        private List<ProjectListInfo> _l;
        private _DTE _dte;
        private IList<SubProcess> _btProcessList = new List<SubProcess>();
        private SubProcessDiagram _bDiagram;
        private string _backupFolderPath = string.Empty;
        private string _folderPath;
        private string _filePath;
        private List<DeletedInfo> deletedCode = new List<DeletedInfo>();
        private List<Activity> activityList = new List<Activity>();
        private string _projectFolderPath = string.Empty;

        public Import()
        {
            InitializeComponent();
        }

        private void Import_Load(object sender, EventArgs e)
        {
            _dte = (_DTE)Package.GetGlobalService(typeof(_DTE));

            LoadProjects();
        }

        private void LoadProjects()
        {

            _l = new List<ProjectListInfo>();

            foreach (Project project in _dte.Solution.Projects)
            {
                _l.Add(new ProjectListInfo
                                      {
                                          ProjectName = project.Name,
                                          ProjectPath = project.FullName,
                                          ProjectObject = project
                                      });
            }
            lstProjects.DataSource = _l;
            lstProjects.DisplayMember = "ProjectName";
            lstProjects.ValueMember = "ProjectPath";

        }


        private void BuildProcessFileVisioToSubProcess(string visioFilePath)
        {
            var store = new Store(typeof(CloudCoreArchitectSubProcessDomainModel));
            var partition = new Partition(store);
            btnNext.Enabled = false;
            IList<SubProcess> subProcessList = new List<SubProcess>();

            var vReader = new ProcessVisioReader(visioFilePath);

            foreach (VisioPage btVisioPage in vReader.Pages)
            {
                using (Transaction transaction = store.TransactionManager.BeginTransaction("create new model"))
                {
                    SubProcess btProcess = new SubProcess(store);

                    try
                    {
                        _projectFolderPath = lstProjects.SelectedValue.ToString().Substring(0, lstProjects.SelectedValue.ToString().LastIndexOf(@"\"));

                        _folderPath = string.Format(@"{0}\processes\", _projectFolderPath);

                        btProcess = ImportHelper.ProcessExists(btVisioPage.VisioId, _folderPath);

                        _filePath = string.Format("{0}{1}.subprocess", _folderPath, btVisioPage.ProcessName.Replace(" ", "_"));

                        //Read From Visio File                   
                        List<ProcessVisioShape> shapes = btVisioPage.ReadDocument();
                        shapes.ForEach(p => p.Initialise(shapes));

                        if (btProcess == null)
                        {
                            #region Create new .subprocess process file from visio import

                            btProcess = CloudCoreArchitectSubProcessSerializationHelper.Instance.CreateModelHelper(partition);
                            _btProcessList.Add(btProcess);

                            _bDiagram = CloudCoreArchitectSubProcessSerializationHelper.Instance.CreateDiagramHelper(partition, btProcess);
                            _bDiagram.ModelElement = btProcess;

                            btProcess.SubProcessName = btVisioPage.ProcessName;
                            btProcess.VisioId = btVisioPage.VisioId;

                            _bDiagram.ModelElement = btProcess;

                            var modelElementActivityList = new List<Activity>();

                            foreach (ProcessVisioShape activity in shapes.FindAll(p => p.ShapeCategory == ShapeTypeCategory.Activity))
                            {
                                List<ProcessVisioShape> attachments = shapes.FindAll(p => p.ShapeCategory == ShapeTypeCategory.Attachment && p.AttachedTo == activity);
                                var isStart = (attachments.FirstOrDefault(p => p.Type == ShapeTypes.Start) != null);

                                //TODO: Check if Activity already exists in returned Diagram, Update returned diagram, or create new Activity if it doesn't exist

                                if (activity.Type == ShapeTypes.PageActivity)
                                {
                                    if (isStart)
                                    {
                                        var PageShape = new PageShape(store);

                                        var btPage = new CloudcoreUser(store)
                                        {
                                            IsMenuItem = activity.IsMenuItem,
                                            VisioId = activity.VisioId,
                                            Name = activity.DescriptiveText,
                                            Height = PageShape.DefaultSize.Height,
                                            Width = PageShape.DefaultSize.Width,
                                            Left = activity.TopLeft.X,
                                            Top = activity.TopLeft.Y,
                                            IsStartable = true
                                        };

                                        btProcess.Activities.Add(btPage);
                                        modelElementActivityList.Add(btPage);
                                    }
                                    else
                                    {
                                        var pageShape = new PageShape(store);

                                        var btPage = new CloudcoreUser(store)
                                        {
                                            IsMenuItem = activity.IsMenuItem,
                                            VisioId = activity.VisioId,
                                            Name = activity.DescriptiveText,
                                            Height = pageShape.DefaultSize.Height,
                                            Width = pageShape.DefaultSize.Width,
                                            Left = activity.TopLeft.X,
                                            Top = activity.TopLeft.Y,
                                            IsStartable = false
                                        };
                                        btProcess.Activities.Add(btPage);
                                        modelElementActivityList.Add(btPage);
                                    }

                                }
                                else if (activity.Type == ShapeTypes.BusinessRule)
                                {
                                    var ruleShape = new WorkflowRuleShape(store);

                                    var btRule = new WorkflowRule(store)
                                    {
                                        VisioId = activity.VisioId,
                                        Name = activity.DescriptiveText,
                                        Height = ruleShape.DefaultSize.Height,
                                        Width = ruleShape.DefaultSize.Width,
                                        Left = activity.TopLeft.X,
                                        Top = activity.TopLeft.Y
                                    };

                                    btProcess.Activities.Add(btRule);
                                    modelElementActivityList.Add(btRule);
                                }
                                else if (activity.Type == ShapeTypes.SubProcess)
                                {
                                    var subProcessShape = new ToProcessConnectorShape(store);

                                    Visio.Hyperlinks hl = activity.VisShape.Hyperlinks;
                                    Visio.Shape sp = hl.Shape;
                                    var visioShape = new ProcessVisioShape(sp);

                                    var btSubProcess = new ToProcessConnector(store)
                                    {
                                        VisioId = activity.VisioId,
                                        Name = activity.DescriptiveText,
                                        Height = subProcessShape.DefaultSize.Height,
                                        Width = subProcessShape.DefaultSize.Width,
                                        Left = activity.TopLeft.X,
                                        Top = activity.TopLeft.Y,
                                        ExternalActivityRef = null,
                                        ToProcessConnectorRef = null,
                                        ToActivityId = visioShape.VisioId.ToString(),
                                        ToProcessId = btProcess.VisioId.ToString()
                                    };

                                    btProcess.Activities.Add(btSubProcess);
                                    modelElementActivityList.Add(btSubProcess);
                                }
                                else if (activity.Type == ShapeTypes.DatabaseActivity)
                                {
                                    if (isStart)
                                    {
                                        //var startEventShape = new StartEventShape(store);

                                        //var btEvent = new StartEvent(store)
                                        //{
                                        //    VisioId = activity.VisioId,
                                        //    Name = activity.DescriptiveText,
                                        //    Height = startEventShape.DefaultSize.Height,
                                        //    Width = startEventShape.DefaultSize.Width,
                                        //    Left = activity.TopLeft.X,
                                        //    Top = activity.TopLeft.Y
                                        //};

                                        //btProcess.Activities.Add(btEvent);
                                        //modelElementActivityList.Add(btEvent);
                                    }
                                    else
                                    {
                                        //var eventShape = new EventShape(store);

                                        //var btEvent = new Event(store)
                                        //{
                                        //    VisioId = activity.VisioId,
                                        //    Name = activity.DescriptiveText,
                                        //    Height = eventShape.DefaultSize.Height,
                                        //    Width = eventShape.DefaultSize.Width,
                                        //    Left = activity.TopLeft.X,
                                        //    Top = activity.TopLeft.Y
                                        //};
                                        //btProcess.Activities.Add(btEvent);
                                        //modelElementActivityList.Add(btEvent);
                                    }
                                }
                                else if (activity.Type == ShapeTypes.Completed)
                                {
                                    var stopShape = new StopShape(store);

                                    var btStop = new Stop(store)
                                    {
                                        VisioId = activity.VisioId,
                                        Name = activity.DescriptiveText,
                                        Height = stopShape.DefaultSize.Height,
                                        Width = stopShape.DefaultSize.Width,
                                        Left = activity.TopLeft.X,
                                        Top = activity.TopLeft.Y
                                    };

                                    btProcess.Activities.Add(btStop);
                                    modelElementActivityList.Add(btStop);
                                }
                                else if (activity.Type == ShapeTypes.Parked)
                                {
                                    //var parkShape = new DBParkShape(store);

                                    //var btParked = new DBPark(store)
                                    //{
                                    //    VisioId = activity.VisioId,
                                    //    Name = activity.DescriptiveText,
                                    //    Height = parkShape.DefaultSize.Height,
                                    //    Width = parkShape.DefaultSize.Width,
                                    //    Left = activity.TopLeft.X,
                                    //    Top = activity.TopLeft.Y
                                    //};

                                    //btProcess.Activities.Add(btParked);
                                    //modelElementActivityList.Add(btParked);
                                }
                            }

                            #region Create Activity Flows

                            foreach (ProcessVisioShape activity in shapes.FindAll(p => p.ShapeCategory == ShapeTypeCategory.Activity))
                            {
                                if (activity.Targets == null) break;

                                Activity sourceElement = modelElementActivityList.FirstOrDefault(p => p.VisioId == activity.VisioId);

                                foreach (ProcessVisioShape target in activity.Targets)
                                {
                                    Activity targetElement = modelElementActivityList.FirstOrDefault(p => p.VisioId == target.VisioId);

                                    if (sourceElement != null && targetElement != null)
                                    {
                                        foreach (var b in target.GetConnectors(activity).Where(b => b != null))
                                        {
                                            CreateNewFlow(sourceElement, targetElement, b.Outcome, b.StoryLine, b.VisioId, DetermineFlowType(b.FlowType));
                                        }
                                    }
                                }
                            }

                            #endregion

                            //vReader.CloseVisio();
                            subProcessList.Add(btProcess);
                            CreateNewProcessFile(btProcess);

                            #endregion

                        }
                        else
                        {
                            #region Update found .subprocess process file from visio import

                            #region Code Folder Variables

                            var processFolderPath = string.Format(@"{0}BTProcess_{1}\", _folderPath, btProcess.VisioId.ToString().Replace("-", "_"));
                            var pagesFolderPath = string.Format(@"{0}Pages\", processFolderPath);
                            var eventsFolderPath = string.Format(@"{0}Events\", processFolderPath);
                            var rulesFolderPath = string.Format(@"{0}Rules\", processFolderPath);

                            #endregion

                            _btProcessList.Add(btProcess);
                            _bDiagram = ImportHelper.GetSubProcessDiagram(btProcess);
                            //Update Process Details
                            btProcess.SubProcessName = btVisioPage.ProcessName;

                            #region Delete Elements that don't exist anymore

                            #region Build Activities List and delete from process diagram that don't exist in the Visio file

                            activityList.AddRange(from activity in btProcess.Activities
                                                  where shapes.FirstOrDefault(a => (a.VisioId == activity.VisioId) && (a.ShapeCategory == ShapeTypeCategory.Activity)) == null
                                                  select activity);

                            #region Complete Activity Deletion Process

                            foreach (var act in activityList)
                            {
                                using (Transaction trans = btProcess.Store.TransactionManager.BeginTransaction("delete activity"))
                                {
                                    #region  Check if link between activity and source activities

                                    //Check if link between activity and source activities
                                    foreach (Activity sAct in act.SourceActs)
                                    {
                                        if (sAct != null)
                                        {
                                            var fMCollection = new List<dynamic>();

                                            //if (sAct is Rule)
                                            //{
                                            //    fMCollection.AddRange(Flow.GetLinks(sAct, act));
                                            //}
                                            //else
                                            //{
                                            //    fMCollection.AddRange(FlowMinimal.GetLinks(sAct, act));
                                            //}
                                        }
                                    }

                                    #endregion

                                    var actName = string.Format("{0} ({1})", act.Name, act.GetType()).Replace("Architect.BT", string.Empty);

                                    #region Build ActivityDelete

                                    //if (act is Rule)
                                    //{
                                    //    string ruleFileName = string.Format(@"{0}BTRule_{1}.sql", rulesFolderPath, act.VisioId.Replace("-", "_"));

                                    //    if (File.Exists(ruleFileName))
                                    //    {
                                    //        deletedCode.Add(new DeletedInfo { Name = actName, Path = ruleFileName, Id = act.VisioId });
                                    //    }
                                    //}

                                    #endregion

                                    act.Delete();

                                    trans.Commit();
                                }
                            }

                            #endregion

                            #endregion

                            #region delete flows that don't exists anymore

                            List<string> connectorList = new List<string>();

                            foreach (var shapeSource in shapes.FindAll(x => (x.ShapeCategory == ShapeTypeCategory.Activity) && (x.Targets != null)))
                            {
                                foreach (var shapeTarget in shapeSource.Targets)
                                {
                                    foreach (var connector in shapeSource.GetConnectors(shapeTarget))
                                    {
                                        if (connector != null)
                                            connectorList.Add(connector.VisioId);
                                    }
                                }
                            }

                            foreach (var vtAct in btProcess.Activities)
                            {
                                var fL = FlowBase.GetLinksToTargetActs(vtAct);

                                foreach (var s in fL)
                                {
                                    if (connectorList.FindAll(f => f == s.VisioId).Count == 0)
                                    {
                                        using (Transaction trans = s.Store.TransactionManager.BeginTransaction("delete non-existing Flow Minimal"))
                                        {
                                            s.Delete();
                                            trans.Commit();
                                        }
                                    }
                                }

                            }

                            #endregion

                            #endregion

                            #region Create/Update Current Task's Activities

                            #region Loop through all activities in the process

                            foreach (ProcessVisioShape activity in shapes.FindAll(p => p.ShapeCategory == ShapeTypeCategory.Activity))
                            {
                                List<ProcessVisioShape> attachments = shapes.FindAll(p => p.ShapeCategory == ShapeTypeCategory.Attachment && p.AttachedTo == activity);
                                var isStart = (attachments.FirstOrDefault(p => p.Type == ShapeTypes.Start) != null);
                                Activity btActivity = btProcess.Activities.FirstOrDefault(a => a.VisioId == activity.VisioId);

                                //TODO: Check if Activity already exists in returned Diagram, Update returned diagram, or create new Activity if it doesn't exist

                                if (btActivity == null)
                                {
                                    #region Create New Activity

                                    using (Transaction trans = btProcess.Store.TransactionManager.BeginTransaction("Create activity"))
                                    {

                                        if (activity.Type == ShapeTypes.PageActivity)
                                        {
                                            if (isStart)
                                            {
                                                //var btPage = new StartPage(store)
                                                //{
                                                //    IsMenuItem = activity.IsMenuItem,
                                                //    VisioId = activity.VisioId,
                                                //    Name = activity.DescriptiveText,
                                                //    Height = activity.Height,
                                                //    Width = activity.Width,
                                                //    Left = activity.TopLeft.X,
                                                //    Top = activity.TopLeft.Y
                                                //};

                                                //startPagesList.Add(btPage);

                                                //btProcess.Activities.Add(btPage);
                                            }
                                            else
                                            {
                                                var btPage = new CloudcoreUser(store)
                                                {
                                                    IsMenuItem = activity.IsMenuItem,
                                                    VisioId = activity.VisioId,
                                                    Name = activity.DescriptiveText,
                                                    Height = activity.Height,
                                                    Width = activity.Width,
                                                    Left = activity.TopLeft.X,
                                                    Top = activity.TopLeft.Y
                                                };
                                                btProcess.Activities.Add(btPage);
                                            }

                                        }
                                        else if (activity.Type == ShapeTypes.BusinessRule)
                                        {
                                            //var btRule = new Rule(store)
                                            //{
                                            //    VisioId = activity.VisioId,
                                            //    Name = activity.DescriptiveText,
                                            //    Height = activity.Height,
                                            //    Width = activity.Width,
                                            //    Left = activity.TopLeft.X,
                                            //    Top = activity.TopLeft.Y
                                            //};

                                            //btProcess.Activities.Add(btRule);
                                        }
                                        else if (activity.Type == ShapeTypes.DatabaseActivity)
                                        {
                                            if (isStart)
                                            {
                                                //var btEvent = new StartEvent(store)
                                                //{
                                                //    VisioId = activity.VisioId,
                                                //    Name = activity.DescriptiveText,
                                                //    Height = activity.Height,
                                                //    Width = activity.Width,
                                                //    Left = activity.TopLeft.X,
                                                //    Top = activity.TopLeft.Y
                                                //};
                                                //btProcess.Activities.Add(btEvent);
                                            }
                                            else
                                            {
                                                //var btEvent = new Event(store)
                                                //{
                                                //    VisioId = activity.VisioId,
                                                //    Name = activity.DescriptiveText,
                                                //    Height = activity.Height,
                                                //    Width = activity.Width,
                                                //    Left = activity.TopLeft.X,
                                                //    Top = activity.TopLeft.Y
                                                //};
                                                //btProcess.Activities.Add(btEvent);
                                            }
                                        }
                                        else if (activity.Type == ShapeTypes.Completed)
                                        {
                                            var btStop = new Stop(store)
                                            {
                                                VisioId = activity.VisioId,
                                                Name = activity.DescriptiveText,
                                                Height = activity.Height,
                                                Width = activity.Width,
                                                Left = activity.TopLeft.X,
                                                Top = activity.TopLeft.Y
                                            };

                                            btProcess.Activities.Add(btStop);
                                        }

                                        trans.Commit();
                                    }

                                    #endregion
                                }
                                else
                                {
                                    #region Update Existing Activity

                                    //if (activity.Type == ShapeTypes.PageActivity && isStart)
                                    //    startPagesList.Add((StartPage)btActivity);

                                    using (Transaction trans = btActivity.Store.TransactionManager.BeginTransaction("update task"))
                                    {
                                        btActivity.Name = activity.DescriptiveText;
                                        btActivity.Height = activity.Height;
                                        btActivity.Width = activity.Width;
                                        btActivity.Left = activity.TopLeft.X;
                                        btActivity.Top = activity.TopLeft.Y;

                                        trans.Commit();
                                    }

                                    #endregion
                                }
                            }

                            #endregion

                            #endregion

                            #region Create/Update Activity Flows

                            #region Create ActivityList in current diagram

                            var modelElementActivityList = new List<Activity>();

                            modelElementActivityList.AddRange(from Activity a in ((SubProcess)_bDiagram.ModelElement).Activities
                                                              select a);

                            #endregion

                            //#region Create Flow List in current diagram

                            //List<dynamic> modelElementActivityFlowList = (from activitySource in modelElementActivityList
                            //                                              from activityTarget in modelElementActivityList.Where(a => a != activitySource)
                            //                                              select GetFlowDetermined(activitySource, activityTarget)
                            //                                                  into fFlow
                            //                                                  where fFlow != null
                            //                                                  select fFlow).ToList();

                            //#endregion

                            foreach (var shapeSource in shapes.FindAll(x => (x.ShapeCategory == ShapeTypeCategory.Activity) && (x.Targets != null)))
                            {
                                foreach (var shapeTarget in shapeSource.Targets)
                                {
                                    foreach (var connector in shapeSource.GetConnectors(shapeTarget))
                                    {
                                        if (connector != null)
                                        {
                                            //dynamic fMinimal = modelElementActivityFlowList.FirstOrDefault(f => f.VisioId == connector.VisioId);

                                            //if (fMinimal != null)
                                            //{
                                            //    #region Update existing flow

                                            //    var source = modelElementActivityList.FirstOrDefault(p => p.VisioId == shapeSource.VisioId);
                                            //    var target = modelElementActivityList.FirstOrDefault(p => p.VisioId == shapeTarget.VisioId);

                                            //    if (fMinimal.SourceBTActivity != source && fMinimal.TargetBTActivity != target)
                                            //    {
                                            //        using (Transaction trans = fMinimal.Store.TransactionManager.BeginTransaction("update Flow"))
                                            //        {
                                            //            fMinimal.Delete();
                                            //            trans.Commit();
                                            //        }
                                            //    }

                                            //    //Check if the source and the target are the same
                                            //    if ((source.VisioId != shapeSource.VisioId) || (target.VisioId != shapeTarget.VisioId))
                                            //    {
                                            //        #region The activity(source) connecting to current activity or activity(target) connected to this activity is different

                                            //        using (Transaction trans = fMinimal.Store.TransactionManager.BeginTransaction("update Flow"))
                                            //        {
                                            //            fMinimal.Delete();
                                            //            trans.Commit();
                                            //        }

                                            //        Activity start, end;

                                            //        //Source is an activity
                                            //        //Get existing in and outports for task to task flow
                                            //        start = fMinimal.TargetBTActivity;
                                            //        end = start.TargetActs[0];

                                            //        #region create new flow

                                            //        using (Transaction trans = fMinimal.Store.TransactionManager.BeginTransaction("Create New Flow"))
                                            //        {
                                            //            CreateNewFlow(source, target, connector.Outcome, connector.StoryLine, fMinimal.VisioId, fMinimal.Type);

                                            //            trans.Commit();
                                            //        }

                                            //        #endregion
                                            //        #endregion
                                            //    }
                                            //    else
                                            //    {
                                            //        #region The activity(source) connecting to current activity or or activity(target) connected to this activity is the same

                                            //        //if (source is Rule)
                                            //        //{
                                            //        //    Flow f = Flow.GetLink(source, target);

                                            //        //    if (f != null)
                                            //        //    {
                                            //        //        using (Transaction trans = fMinimal.Store.TransactionManager.BeginTransaction("update Flow Minimal"))
                                            //        //        {
                                            //        //            f.Storyline = connector.StoryLine;
                                            //        //            f.Outcome = connector.Outcome;

                                            //        //            trans.Commit();
                                            //        //        }
                                            //        //    }
                                            //        //    else
                                            //        //    {
                                            //        //        using (Transaction trans = source.Store.TransactionManager.BeginTransaction("Create Link"))
                                            //        //        {
                                            //        //            CreateNewFlow(source, target, connector.Outcome, connector.StoryLine, connector.VisioId, DetermineFlowType(connector.FlowType));

                                            //        //            trans.Commit();
                                            //        //        }
                                            //        //    }
                                            //        //}
                                            //        //else
                                            //        //{
                                            //        //    FlowMinimal f = FlowMinimal.GetLink(source, target);

                                            //        //    using (Transaction trans = fMinimal.Store.TransactionManager.BeginTransaction("update Flow Minimal"))
                                            //        //    {
                                            //        //        f.Storyline = connector.StoryLine;

                                            //        //        trans.Commit();
                                            //        //    }
                                            //        //}

                                            //        #endregion
                                            //    }

                                            //    #endregion

                                            //}
                                            //else
                                            //{
                                            //    #region Create new flow

                                            //    if (shapeSource.Targets != null && shapeTarget.Sources != null)
                                            //    {
                                            //        Activity source = modelElementActivityList.FirstOrDefault(p => p.VisioId == shapeSource.VisioId);
                                            //        Activity target = modelElementActivityList.FirstOrDefault(p => p.VisioId == shapeTarget.VisioId);

                                            //        #region Source Activity's Parent Task equal to Target Activity's Parent Task

                                            //        using (Transaction trans = source.Store.TransactionManager.BeginTransaction("update Flow Minimal"))
                                            //        {
                                            //            CreateNewFlow(source, target, connector.Outcome, connector.StoryLine, connector.VisioId, DetermineFlowType(connector.FlowType));

                                            //            trans.Commit();
                                            //        }

                                            //        #endregion
                                            //    }

                                            //    #endregion
                                            //}
                                        }
                                    }
                                }
                            }

                            #endregion

                            //vReader.CloseVisio();

                            if (deletedCode.Count > 0)
                            {
                                pnlBackup.Enabled = true;
                            }
                            else
                            {
                                deletedCode.Add(new DeletedInfo
                                                        {
                                                            Name = "No items will be deleted."
                                                        });

                                pnlBackup.Enabled = false;
                            }

                            lstDeleted.DataSource = deletedCode;
                            lstDeleted.DisplayMember = "Name";

                            pnlDeleted.Visible = true;

                            #endregion
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }


            IModelBus modelBus = store.GetService(typeof(SModelBus)) as IModelBus;

            if (modelBus != null)
            {
                foreach (SubProcess process in subProcessList)
                {
                    using (Transaction transaction = process.Store.TransactionManager.BeginTransaction("update modelbus"))
                    {
                        //List<Activity> subProcessActivities = process.Activities.Where(a => a is SubProcessActivity).ToList();
                        //foreach (Activity act in subProcessActivities)
                        //{
                        //    var _act = (SubProcessActivity)act;

                        //    string toProc = ((SubProcessActivity)act).ToProcessId;
                        //    string toAct = ((SubProcessActivity)act).ToActivityId;

                        //    var toProcess = (SubProcess)subProcessList.Where(p => p.VisioId.ToString() == toProc).SingleOrDefault();

                        //    var toActivity = (SubProcessActivity)toProcess.Activities.Where(a => a.VisioId.ToString() == toAct).SingleOrDefault();

                        //    string projectPath = lstProjects.SelectedValue.ToString().Substring(0, lstProjects.SelectedValue.ToString().LastIndexOf(@"\"));
                        //    string folderPath = string.Format(@"{0}\processes\", _projectFolderPath);
                        //    string filePath = string.Format("{0}{1}.subprocess", _folderPath, toActivity.SubProcess.SubProcessName.Replace(" ", "_"));


                        //    ModelBusAdapterManager manager = modelBus.FindAdapterManagers(filePath).First();
                        //    ModelBusReference reference = manager.CreateReference(filePath);

                        //    using (ModelBusAdapter adapter = modelBus.CreateAdapter(reference))
                        //    {
                        //        _act.ExternalActivityRef = adapter.GetElementReference(toActivity);
                        //        _act.SubProcessActivityRef = adapter.GetElementReference(toActivity);
                        //    }
                        //}

                        transaction.Commit();
                    }
                }
            }
           
            vReader.CloseVisio();
            Close();
        }

        private void CreateNewFlow(Activity source, Activity target, string outcome, string storyLine, string visioId, FlowType type)
        {
            //if (source is Rule)
            //{
            //    new Flow(source, target)
            //    {
            //        Outcome = outcome,
            //        Storyline = storyLine,
            //        VisioId = visioId,
            //        Type = type

            //    };
            //}
            //else
            //{
            //    new FlowMinimal(source, target)
            //    {
            //        Storyline = storyLine,
            //        VisioId = visioId,
            //        Type = type
            //    };
            //}
        }

        //private dynamic GetFlowDetermined(Activity source, Activity target)
        //{
        //    //if (source is Rule)
        //    //    return Flow.GetLink(source, target);

        //    //return FlowMinimal.GetLink(source, target);
        //}

        private void UpdateExistingProcessFile()
        {
            var store = new Store(typeof(CloudCoreArchitectSubProcessDomainModel));
            var result = new SerializationResult();
            _backupFolderPath = txtBackupLocation.Text + ((txtBackupLocation.Text.Last().ToString() != @"\") ? @"\" : string.Empty);

            btnImport.Enabled = false;
            btnCancel.Enabled = false;

            foreach (SubProcess btProcess in _btProcessList)
            {
                #region Delete Existing start page elements from assemblyinfo

                var assemblyPath = string.Format(@"{0}\Properties\AssemblyInfo.cs", _projectFolderPath);
                ProjectItem assemblyProjectItem = _dte.Solution.FindProjectItem(assemblyPath);
                var elements = assemblyProjectItem.FileCodeModel.CodeElements;
                var processIdStr = string.Format(", \"{0}\"", btProcess.VisioId);

                for (var index = 1; index <= elements.Count; index++)
                {
                    var elemnt = elements.Item(index);

                    if (elemnt.Kind != vsCMElement.vsCMElementAttribute) continue;
                    if (elemnt.Name != "BTEmbeddedProcessUrl") continue;

                    var u = (CodeAttribute)elemnt;

                    if (u.Value.IndexOf(processIdStr) != -1)
                    {
                        u.Delete();
                    }
                }

                #endregion

                #region Add start page elements to assembly info

                //ImportHelper.AddAssembly(_dte, assemblyProjectItem.ContainingProject, btProcess, startPagesList);

                #endregion

                #region Delete and move code items marked for deletion

                if (deletedCode.Count > 0)
                {
                    foreach (var f in deletedCode)
                    {
                        if (f.Path != null)
                            if (f.Path.IndexOf("aspx") != -1)
                            {
                                ImportHelper.MovePageCodeToBackup(f.Id, f.Path, f.Name, _backupFolderPath, _dte);
                            }
                            else
                            {
                                ImportHelper.MoveCodeToBackup(f.Id, f.Path, f.Name, _backupFolderPath, _dte);
                            }
                    }
                }
                #endregion

                #region Save Diagram

                using (Transaction trans = store.TransactionManager.BeginTransaction("save"))
                {
                    CloudCoreArchitectSubProcessSerializationHelper.Instance.SaveModelAndDiagram(result, btProcess, _filePath, _bDiagram, _filePath + ".diagram", Encoding.UTF8, false);
                    ProjectItem file = _dte.Solution.FindProjectItem(_filePath);
                    file.Open().Activate();
                    file.Save();

                    trans.Commit();
                }

                #endregion

                CreateCodeFiles(btProcess);
            }
            Close();
        }

        private void CreateNewProcessFile(SubProcess btProcess)
        {
            var store = new Store(typeof(CloudCoreArchitectSubProcessDomainModel));
            var result = new SerializationResult();

            #region Delete Existing start page elements from assemblyinfo

            var assemblyPath = string.Format(@"{0}\Properties\AssemblyInfo.cs", _projectFolderPath);
            ProjectItem assemblyProjectItem = _dte.Solution.FindProjectItem(assemblyPath);
            var elements = assemblyProjectItem.FileCodeModel.CodeElements;
            var processIdStr = string.Format(", \"{0}\"", btProcess.VisioId);

            for (var index = 1; index <= elements.Count; index++)
            {
                var elemnt = elements.Item(index);

                if (elemnt.Kind != vsCMElement.vsCMElementAttribute) continue;
                if (elemnt.Name != "BTEmbeddedProcessUrl") continue;

                var u = (CodeAttribute)elemnt;

                if (u.Value.IndexOf(processIdStr) != -1)
                {
                    u.Delete();
                }
            }

            #endregion

            #region Add start page elements to assembly info

            //ImportHelper.AddAssembly(_dte, assemblyProjectItem.ContainingProject, btProcess, startPagesList);

            #endregion

            using (Transaction trans = store.TransactionManager.BeginTransaction("save"))
            {
                CloudCoreArchitectSubProcessSerializationHelper.Instance.SaveModelAndDiagram(result, btProcess, _filePath, _bDiagram, _filePath + ".diagram", Encoding.UTF8, false);
                ProjectItem file = _l.FirstOrDefault(p => p.ProjectPath == lstProjects.SelectedValue.ToString()).ProjectObject.ProjectItems.AddFromFile(_filePath);
                file.Open().Activate();
                file.Save();
                //file.Properties.Item("CustomTool").Value = "SubProcessFileCodeGenerator";

                trans.Commit();
            }

            CreateCodeFiles(btProcess);
        }

        private void CreateCodeFiles(SubProcess btProcess)
        {
            Project project = _dte.Solution.FindProjectItem(_filePath).ContainingProject;

            foreach (var activity in btProcess.Activities)
            {
                foreach (var target in activity.TargetActs)
                {
                    //dynamic flow;

                    //if (activity is Rule)
                    //{
                    //    flow = Flow.GetLink(activity, target);
                    //}
                    //else
                    //{
                    //    flow = FlowMinimal.GetLink(activity, target);
                    //}
                }

                ////Create code pages
                //if (activity is StartEvent)
                //{
                //    SubProcessFiles.AddSql(project, activity.VisioId, btProcess.VisioId, "SQLEvent");
                //}
                //else if (activity is StartPage)
                //{
                //    SubProcessFiles.AddPage(project, activity.VisioId, btProcess.VisioId, true);

                //    var assemblyPath = string.Format(@"{0}\Properties\AssemblyInfo.cs", _projectFolderPath);
                //    ProjectItem assemblyProjectItem = _dte.Solution.FindProjectItem(assemblyPath);

                //    ImportHelper.AddAssembly(_dte, assemblyProjectItem.ContainingProject, btProcess, startPagesList);
                //}
                //else 
                //    if (activity is Page)
                //{
                //    SubProcessFiles.AddPage(project, activity.VisioId, btProcess.VisioId, false);
                //}
                //else if (activity is Rule)
                //{
                //    SubProcessFiles.AddSql(project, activity.VisioId, btProcess.VisioId, "SQLRule");
                //}
                //else if (activity is Event)
                //{
                //    SubProcessFiles.AddSql(project, activity.VisioId, btProcess.VisioId, "SQLEvent");
                //}
            }
        }

        private FlowType DetermineFlowType(string flowType)
        {
            switch (flowType)
            {
                case "Negative":
                    return FlowType.Negative;
                case "Optimal":
                    return FlowType.Optimal;
            }

            return FlowType.none;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Import Subprocess Process from Visio";
            openFileDialog.Filter = "Visio Files|*.vsd";

            switch (openFileDialog.ShowDialog())
            {
                case DialogResult.OK:
                    txtVisio.Text = openFileDialog.FileName;
                    break;
                case DialogResult.Cancel:
                    break;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (txtVisio.Text == string.Empty)
            {
                MessageBox.Show("Please select a visio file to import");
                return;
            }

            if (!File.Exists(txtVisio.Text))
            {
                MessageBox.Show("Please make sure you have selected a  file that exists");
                return;
            }


            if (txtVisio.Text.IndexOf(".vsd") == -1)
            {
                MessageBox.Show("Please make sure you have selected a visio file");
                return;
            }

            BuildProcessFileVisioToSubProcess(txtVisio.Text);
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.Description = "Select a folder for your code backup";
            switch (folderBrowserDialog.ShowDialog())
            {
                case DialogResult.OK:
                    txtBackupLocation.Text = folderBrowserDialog.SelectedPath;
                    break;
                case DialogResult.Cancel:
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Close();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            UpdateExistingProcessFile();
        }
    }

    public class ProjectListInfo
    {
        public string ProjectName { get; set; }
        public string ProjectPath { get; set; }
        public Project ProjectObject { get; set; }
    }

    public class DeletedInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
