using System;
using System.Collections.Generic;
using System.Linq;
using ProcessViewer.Library;

namespace ProcessViewer.ViewModel
{
    public class ProcessRevisions
    {
        public ProcessRevisions(DrawItem item)
        {
            _drawItem = item;
        }

        private Revision _selectedRevision;
        private readonly DrawItem _drawItem;

        public String ProcessName { get; set; }
        public int ProcessID { get; set; }
        public List<Revision> Revisions { get; set; }
        public Revision SelectedRevision
        {
            get
            {
                return _selectedRevision;
            }
            set
            {
                _selectedRevision = value;
                var x = _drawItem.Process.Where(p => p.Id == _selectedRevision.ProcessID).Single();
                x.RevisionId = value.ID;
            }
        }
    }

    public class ProcessRevisionViewModel : WizardPageViewModelBase
    {

        private List<ProcessRevisions> _availableRevisions;

        public ProcessRevisionViewModel(DrawItem drawItem)
            : base(drawItem)
        {
        }

        public List<ProcessRevisions> AvailableRevisions
        {
            get
            {
                if (_availableRevisions == null)
                {
                    CreateAvailableRevisions();
                    return _availableRevisions;
                }

                if (DrawItem.ResetRevisions)
                {
                    CreateAvailableRevisions();
                    DrawItem.ResetRevisions = false;
                }

                return _availableRevisions;
            }
        }

        public void CreateAvailableRevisions()
        {

            var processRevisions = new List<ProcessRevisions>();

            var db = new Data1.CloudCoreDB(DrawItem.ConnectionString);

                foreach (var process in DrawItem.Process)
                {
                    var revisions = (from pr in db.Cloudcoremodel_ProcessRevision
                                     join u in db.Cloudcore_User on pr.UserId equals u.UserId
                                     orderby pr.ProcessRevision descending
                                     where pr.ProcessModelId == process.Id
                                     select new Revision
                                                {
                                                    Name = "Revision " + pr.ProcessRevision.ToString(),
                                                    ID = pr.ProcessRevisionId,
                                                    User = u.NFullname,
                                                    Date = String.Format("{1}: {0:dd MMMM yyyy}", pr.Changed, "Created"),
                                                    ProcessID = pr.ProcessModelId
                                                }).ToList();


                    var latest = (from r in revisions
                                  select new Revision
                                             {
                                                 Name = "Latest",
                                                 ID = r.ID,
                                                 User = r.User,
                                                 Date = r.Date,
                                                 ProcessID = r.ProcessID

                                             }).First();
                    revisions.Insert(1, latest);

                    //Delete duplicate entry
                    revisions.Remove(revisions.First());


                    processRevisions.Add(new ProcessRevisions(DrawItem)
                                             {
                                                 ProcessName = process.Title,
                                                 ProcessID = process.Id,
                                                 Revisions = revisions
                                             });
            }

            _availableRevisions = processRevisions;
        }

        public bool IsEnabled { get { return DrawItem.Version != DBVersion.Version1; } }

        public override string DisplayName
        {
            get { return "Select Process Revision"; }
        }

        internal override bool IsValid()
        {
            return true;
        }

        internal override bool StepBack()
        {
            return true;
        }
    }
}
