using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ProcessViewer.Library;
using ProcessViewer.Library.Common;
using ProcessViewer.Resources;

namespace ProcessViewer.ViewModel
{
    public class DisplayLevelViewModel : WizardPageViewModelBase
    {
        #region Fields

        ReadOnlyCollection<OptionViewModel<DiagramType>> _availableDiagramTypes;
        ReadOnlyCollection<OptionViewModel<ViewLevel>> _availableViewLevels;

        #endregion

        #region Constructor

        public DisplayLevelViewModel(DrawItem drawItem)
            : base(drawItem)
        {
            VLEnabled = true;
        }

        #endregion

        #region Properties

        #region Available Diagram Types

        /// <summary>
        /// Returns a read-only collection of all bean types that the user can select.
        /// </summary>
        public ReadOnlyCollection<OptionViewModel<DiagramType>> AvailableDiagramTypes
        {
            get
            {
                if (_availableDiagramTypes == null)
                    CreateAvailableDiagramTypes();
                return _availableDiagramTypes;
            }
        } 

        void CreateAvailableDiagramTypes()
        {
            var list = new List<OptionViewModel<DiagramType>>
                           {
                               new OptionViewModel<DiagramType>(Strings.DiagramType_MSAGL, DiagramType.Msagl, 0),
                               RegLibrary.CheckForVisio(14) ? new OptionViewModel<DiagramType>(Strings.DiagramType_Visio, DiagramType.Visio, 1) : 
                                                              new OptionViewModel<DiagramType>(Strings.DiagramType_Visio, DiagramType.Visio, 1, false)
                           };

            foreach (var option in list)
            {
                // Select the default value.
                if (option.GetValue() == DrawItem.DiagramType)
                    option.IsSelected = true;

                option.PropertyChanged += OnDiagramTypeOptionPropertyChanged;
            }

            list.Sort();

            _availableDiagramTypes = new ReadOnlyCollection<OptionViewModel<DiagramType>>(list);
        }

        public bool VLEnabled { get; set; }

        void OnDiagramTypeOptionPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var option = sender as OptionViewModel<DiagramType>;
            if (option.IsSelected)
            {
                DrawItem.DiagramType = option.GetValue();
                if (option.GetValue() == DiagramType.Visio)
                    VLEnabled = false;
                else
                    VLEnabled = true;
            }
        }

        #endregion

        #region Available View Levels

        /// <summary>
        /// Returns a read-only collection of all view levels that the user can select.
        /// </summary>
        public ReadOnlyCollection<OptionViewModel<ViewLevel>> AvailableViewLevels
        {
            get
            {
                if (_availableViewLevels == null)
                    CreateAvailableViewLevels();

                return _availableViewLevels;
            }
        }

        void CreateAvailableViewLevels()
        {
            var list = new List<OptionViewModel<ViewLevel>>
                           {
                               new OptionViewModel<ViewLevel>(Strings.ViewLevel_Activity, 
                                   ViewLevel.Activity, 0), new OptionViewModel<ViewLevel>(Strings.ViewLevel_Task, ViewLevel.SubProcess, 1)
                           };

            foreach (OptionViewModel<ViewLevel> option in list)
            {
                // Select the Default Value
                if (option.GetValue() == DrawItem.ViewLevel)
                    option.IsSelected = true;
                
                option.PropertyChanged += OnViewLevelOptionPropertyChanged;

            }

            list.Sort();

            _availableViewLevels = new ReadOnlyCollection<OptionViewModel<ViewLevel>>(list);
        }

        void OnViewLevelOptionPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var option = sender as OptionViewModel<ViewLevel>;
            if (option.IsSelected)
                DrawItem.ViewLevel = option.GetValue();
        }

        #endregion

        #region DisplayName

        public override string DisplayName
        {
            get { return Strings.PageDisplayName_LevelType; }
        }

        #endregion

        #endregion

        #region Methods

        internal override bool IsValid()
        {
            return true;
        }

        internal override bool StepBack()
        {
            return true;
        }

        #endregion
    }
}
