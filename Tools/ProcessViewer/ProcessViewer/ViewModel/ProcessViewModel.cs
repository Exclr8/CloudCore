using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using ProcessViewer.Library;
using ProcessViewer.Library.Data;
using ProcessViewer.Library.Shapes;
using ProcessViewer.Resources;

namespace ProcessViewer.ViewModel
{
    public class ProcessViewModel : WizardPageViewModelBase
    {
        #region Fields

        ReadOnlyCollection<OptionViewModel<Process>> _availableProcesses;

        #endregion
        #region Constructor

        public ProcessViewModel(DrawItem drawItem)
            : base(drawItem)
        {
            DrawItem.Process = new List<Process>();
        }

        #endregion

        #region Properties

       #region Available Processes

        public ReadOnlyCollection<OptionViewModel<Process>> AvailableProcesses
        {
            get
            {
                if (_availableProcesses == null || DrawItem.Process.Count < 1 )
                {
                    CreateAvailableProcesses();
                }
                return _availableProcesses;
            }
        }

        void CreateAvailableProcesses()
        {
            var list = new List<OptionViewModel<Process>>();

            try
            {
                list.AddRange(Processes.GetProcesses(DrawItem).Select(p => new OptionViewModel<Process>(p.Title, p)));

                foreach (var option in list)
                {
                    option.PropertyChanged += OnOptionsPropertyChanged;
                }

                list.Sort();
            }
            catch (Exception)
            {
                //do nothing 
            }
            _availableProcesses = new ReadOnlyCollection<OptionViewModel<Process>>(list);
        }

        void OnOptionsPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var option = sender as OptionViewModel<Process>;

            DrawItem.ResetRevisions = true;

            //More than one option can be selected
            if (option.IsSelected)
            {
                DrawItem.Process.Add(option.GetValue());
            }
            else
                DrawItem.Process.Remove(option.GetValue());
        }

        #endregion

        #region DisplayName

        public override string DisplayName
        {
            get { return Strings.PageDisplayName_Processes; }
        }

        #endregion

        #endregion

        #region Methods

        internal override bool IsValid()
        {
            return DrawItem.Process.Count > 0;
        }

        internal override bool StepBack()
        {
            return true;
        }

        #endregion
    }
}
