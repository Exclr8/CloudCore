using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ProcessViewer.Library;
using ProcessViewer.Resources;

namespace ProcessViewer.ViewModel
{
    public class OptionsViewModel : WizardPageViewModelBase
    {
        #region Fields

        ReadOnlyCollection<OptionViewModel<Options>> _availableOptions;
 
        #endregion

        #region Constructor

        public OptionsViewModel(DrawItem drawItem)
            : base(drawItem)
        {
        }

        #endregion

        #region Properties

        #region Available Options

        /// <summary>
        /// Returns a read-only collection of all view levels that the user can select.
        /// </summary>
        public ReadOnlyCollection<OptionViewModel<Options>> AvailableOptions
        {
            get
            {
                if (_availableOptions == null)
                    CreateAvailableOptions();

                return _availableOptions;
            }
        }

        void CreateAvailableOptions()
        {
            var list = new List<OptionViewModel<Options>>
                           {
                               new OptionViewModel<Options>(Strings.OptionsView_Colour, Options.Colour, 0),
                               new OptionViewModel<Options>(Strings.OptionsView_ID, Options.Id, 1),
                               new OptionViewModel<Options>("Show Instances", Options.Instance, 2)
                           };

            foreach (var option in list)
            {
                option.PropertyChanged += OnOptionsPropertyChanged;
                if (option.GetValue() == Options.Colour)
                    option.IsSelected = true;
            }

            list.Sort();

            _availableOptions = new ReadOnlyCollection<OptionViewModel<Options>>(list);
        }

        void OnOptionsPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var option = sender as OptionViewModel<Options>;
            
            //More than one option can be selected
            if (option.IsSelected)
                DrawItem.Options |= option.GetValue();
            else
                DrawItem.Options = (DrawItem.Options | option.GetValue()) ^ option.GetValue();
        }

        #endregion

        #region DisplayName

        public override string DisplayName
        {
            get { return Strings.PageDisplayName_Options; }
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
