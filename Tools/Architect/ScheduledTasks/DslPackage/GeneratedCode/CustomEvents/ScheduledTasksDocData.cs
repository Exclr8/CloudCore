using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;
using Architect.ScheduledTasks.CustomCode.Validation;
using EnvDTE80;
using EnvDTE;
using Architect.ScheduledTasks.VsEnvironment;

namespace Architect.ScheduledTasks
{
    internal partial class ScheduledTasksDocData
    {
        protected override void OnDocumentLoaded(EventArgs e)
        {
            base.OnDocumentLoaded(e);

            EventManagerDirectory emd = Store.EventManagerDirectory;

            #region Group Property Events

            DomainPropertyInfo groupDomainGroupNamePropertyInfo = Store.DomainDataDirectory.FindDomainProperty(Group.GroupNameDomainPropertyId);

            emd.ElementPropertyChanged.Add(groupDomainGroupNamePropertyInfo, new EventHandler<ElementPropertyChangedEventArgs>(GroupNameChanged));

            #endregion

            #region Scheduled Task Property Events

            DomainPropertyInfo scheduledTaskDomainIntervalPropertyInfo = Store.DomainDataDirectory.FindDomainProperty(BaseScheduledTask.IntervalDomainPropertyId);
            DomainPropertyInfo scheduledTaskDomainNamePropertyInfo = Store.DomainDataDirectory.FindDomainProperty(BaseScheduledTask.NameDomainPropertyId);
            DomainPropertyInfo scheduledTaskDomainStartDatePropertyInfo = Store.DomainDataDirectory.FindDomainProperty(BaseScheduledTask.StartDateDomainPropertyId);

            emd.ElementPropertyChanged.Add(scheduledTaskDomainIntervalPropertyInfo, new EventHandler<ElementPropertyChangedEventArgs>(BaseScheduledTaskIntervalChanged));
            emd.ElementPropertyChanged.Add(scheduledTaskDomainStartDatePropertyInfo, new EventHandler<ElementPropertyChangedEventArgs>(BaseScheduledTaskStartDateChanged));
            emd.ElementPropertyChanged.Add(scheduledTaskDomainNamePropertyInfo, new EventHandler<ElementPropertyChangedEventArgs>(BaseScheduledTaskNameChanged));

            #endregion
        }

        #region Groups properties events

        private void GroupNameChanged(object sender, ElementPropertyChangedEventArgs e)
        {
            var group = e.ModelElement as Group;
            var newName = e.NewValue.ToString();
            var noError = true;

            if (string.IsNullOrEmpty(newName) || string.IsNullOrWhiteSpace(newName))
            {
                System.Windows.Forms.MessageBox.Show(Validation.GroupNameEmpty);
                noError = false;
                return;
            }

            if (newName.Length > 50)
            {
                System.Windows.Forms.MessageBox.Show(Validation.GroupNameLength);
                noError = false;
                return;
            }

            if (noError)
            {
                return;
            }

            using (Transaction t = group.Store.TransactionManager.BeginTransaction("Fix Name"))
            {
                group.GroupName = e.OldValue.ToString();
                t.Commit();
            }
        }

        #endregion

        #region Scheduled task properties events

        private void BaseScheduledTaskStartDateChanged(object sender, ElementPropertyChangedEventArgs e)
        {
            var scheduledTask = e.ModelElement as BaseScheduledTask;
            var newValue = Convert.ToDateTime(e.NewValue);
            var oldValue = Convert.ToDateTime(e.OldValue);

            if (newValue > DateTime.Now)
                return;

            System.Windows.Forms.MessageBox.Show(Validation.STaskDateInvalid);

            using (Transaction t = scheduledTask.Store.TransactionManager.BeginTransaction("Fix Date"))
            {
                scheduledTask.StartDate = (oldValue > DateTime.Now) ? oldValue : DateTime.Now.AddDays(1);
                t.Commit();
            }
        }

        private void BaseScheduledTaskNameChanged(object sender, ElementPropertyChangedEventArgs e)
        {
            var scheduledTask = e.ModelElement as BaseScheduledTask;
            var newName = e.NewValue.ToString();
            var noError = true;

            if (string.IsNullOrEmpty(newName) || string.IsNullOrWhiteSpace(newName))
            {
                System.Windows.Forms.MessageBox.Show(Validation.STaskNameEmpty);
                noError = false;
                return;
            }

            if (newName.Length > 50)
            {
                System.Windows.Forms.MessageBox.Show(Validation.STaskNameLength);
                noError = false;
                return;
            }

            if (noError)
                return;

            using (Transaction t = scheduledTask.Store.TransactionManager.BeginTransaction("Fix Name"))
            {
                scheduledTask.Name = e.OldValue.ToString();
                t.Commit();
            }
        }

        private void BaseScheduledTaskIntervalChanged(object sender, ElementPropertyChangedEventArgs e)
        {
            var scheduledTask = e.ModelElement as BaseScheduledTask;

            if (Convert.ToInt32(e.NewValue) > 0)
                return;

            System.Windows.Forms.MessageBox.Show(Validation.STaskIntervalLessThanOrEqualToZero);

            using (Transaction t = scheduledTask.Store.TransactionManager.BeginTransaction("Fix Interval"))
            {
                scheduledTask.Interval = (Convert.ToInt32(e.OldValue) <= 0) ? 1 : Convert.ToInt32(e.OldValue);
                t.Commit();
            }

        }

        #endregion
    }
}
