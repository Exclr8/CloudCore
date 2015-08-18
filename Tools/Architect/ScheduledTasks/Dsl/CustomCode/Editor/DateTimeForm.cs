using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Architect.ScheduledTasks.Editors
{
    public partial class DateTimeForm : Form
    {
        public DateTime SelectedDate { get; set; }

        public DateTimeForm()
        {
            InitializeComponent();
        }

        private void DateTimeForm_Load(object sender, EventArgs e)
        {
            cldStartDate.MinDate = DateTime.MinValue;
            cldStartDate.SetDate(SelectedDate <= DateTime.MinValue ? DateTime.Now : SelectedDate);
            dtStartTime.Value = SelectedDate <= DateTime.MinValue ? DateTime.Now : SelectedDate;
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = new DateTime(cldStartDate.SelectionStart.Year, 
                                             cldStartDate.SelectionStart.Month, 
                                             cldStartDate.SelectionStart.Day,
                                             dtStartTime.Value.Hour, 
                                             dtStartTime.Value.Minute, 
                                             dtStartTime.Value.Second);

            this.SelectedDate = selectedDate;
        }
    }
}
