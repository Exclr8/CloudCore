using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Btomic
{
    public partial class Revision : Form
    {
        private readonly int _processId;

        public int RevisionID { get; private set; }

        public Revision(int processID)
        {
            InitializeComponent();
            _processId = processID;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lbRevisions.SelectedItem == null)
            {
                DialogResult = DialogResult.None;
                return;
            }

            RevisionID = ((RevisionListItem)lbRevisions.SelectedItem).ResvisionID;
            DialogResult = DialogResult.OK;
            return;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Revision_Load(object sender, EventArgs e)
        {
            var db = new BtomicDB();

            var revisions = (from p in db.Model_BTProcessRevision
                             join u in db.BTUser on p.UserId equals u.UserId
                             orderby p.ProcessRevisionId descending
                             where p.ProcessModelId == _processId
                             select new RevisionListItem
                             {
                                 ResvisionID = p.ProcessRevisionId,
                                 Revision = p.ProcessRevision,
                                 CreatorName = u.NFullname,
                                 Changed = p.Changed
                             });

            var selected = false;
            foreach (var revision in revisions)
            {
                lbRevisions.Items.Add(revision);
                if (selected) continue;
                selected = true;
                lbRevisions.SelectedItem = revision;

            }

        }
    }

    class RevisionListItem
    {
        public int ResvisionID { get; set; }
        public int Revision { get; set; }
        public String CreatorName { get; set; }
        public DateTime Changed { get; set; }

        public override string ToString()
        {
            return String.Format(@" Revision: {0}  Creator: {1}  Date: {2:dd MMMM yyyy}", Revision, CreatorName, Changed);
        }

    }
}
