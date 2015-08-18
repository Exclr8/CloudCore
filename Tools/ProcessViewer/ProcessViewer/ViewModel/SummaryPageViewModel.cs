using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ProcessViewer.Library;
using ProcessViewer.Resources;

namespace ProcessViewer.ViewModel
{
    /// <summary>
    /// This page in the wizard displays all of the options selected by the user
    /// in the previous pages.
    /// </summary>
    public class SummaryPageViewModel : WizardPageViewModelBase
    {
        #region Fields

        readonly ReadOnlyCollection<OptionViewModel<DiagramType>> _availableDiagramTypes;
        readonly ReadOnlyCollection<OptionViewModel<ViewLevel>> _availableViewLevel;
        readonly ReadOnlyCollection<OptionViewModel<Options>> _availableOptions;
        readonly ReadOnlyCollection<OptionViewModel<DBVersion>> _availableVersions;

        #endregion

        #region Constructor

        public SummaryPageViewModel(
            ReadOnlyCollection<OptionViewModel<DiagramType>> availableDiagramTypes,
            ReadOnlyCollection<OptionViewModel<ViewLevel>> availableViewLevel,
            ReadOnlyCollection<OptionViewModel<Options>> availableOptions,
            ReadOnlyCollection<OptionViewModel<DBVersion>> availableVersions)
            : base(null)
        {
            _availableDiagramTypes = availableDiagramTypes;
            _availableViewLevel = availableViewLevel;
            _availableOptions = availableOptions;
            _availableVersions = availableVersions;
        }

        #endregion

        #region Properties

        public string DiagramType
        {
            get { return GetSelectedOptionDisplayName(_availableDiagramTypes); }
        }

        public override string DisplayName
        {
            get { return Strings.PageDisplayName_Summary; }
        }

        public string Version
        {
            get { return GetSelectedOptionDisplayName(_availableVersions); }
        }

        public string ViewLevel
        {
            get { return GetSelectedOptionDisplayName(_availableViewLevel); }
        }

        public string Options
        {
            get
            {
                var optionNames =
                    (from options in _availableOptions
                     where options.IsSelected
                     select options.DisplayName).ToList();

                string returnValue = null;

                for (var i = 0; i < optionNames.Count; ++i)
                {
                    returnValue += optionNames[i];

                    if (i < optionNames.Count - 1)
                        returnValue += ",\n";
                }

                return returnValue ?? Strings.Options_NoSelection;
            }
        }

        //public string Processes
        //{
        //    get
        //    {
        //        List<String> ProcessNames =
        //            (from p in _availableProcesses
        //             where p.IsSelected
        //             select p.DisplayName).ToList();

        //        string returnValue = null;

        //        for (int i = 0; i < ProcessNames.Count; ++i)
        //        {
        //            returnValue += ProcessNames[i];

        //            if (i < ProcessNames.Count - 1)
        //                returnValue += ",\n";
        //        }

        //        return returnValue ?? Strings.Options_NoSelection;
        //    }
        //}

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

        #region Private Helpers

        static string GetSelectedOptionDisplayName<T>(IEnumerable<OptionViewModel<T>> availableOptions)
        {
            if (availableOptions == null)
                throw new ArgumentNullException("availableOptions");

            return (from option in availableOptions
                    where option.IsSelected
                    select option.DisplayName).FirstOrDefault();
        }

        #endregion
    }
}