using System;
using System.ComponentModel;

namespace ProcessViewer.ViewModel
{
    /// <summary>
    /// Represents a value with a user-friendly name that can be selected by the user.
    /// </summary>
    /// <typeparam name="TValue">The type of value represented by the option.</typeparam>
    public class OptionViewModel<TValue> : 
        INotifyPropertyChanged, 
        IComparable<OptionViewModel<TValue>>
    {
        #region Fields

        const int UnsetSortValue = Int32.MinValue;

        readonly string _displayName;
        bool _isSelected;
        readonly int _sortValue;
        readonly TValue _value;
        readonly bool _enabled;

        #endregion

        #region Constructor

        public OptionViewModel(string displayName, TValue value)
            : this(displayName, value, UnsetSortValue)
        {
        }

        public OptionViewModel(string displayName, TValue value, int sortValue, bool enabled = true)
        {
            _displayName = displayName;
            _value = value;
            _sortValue = sortValue;
            _enabled = enabled;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Returns the user-friendly name of this option.
        /// </summary>
        public string DisplayName
        {
            get { return _displayName; }
        }

        /// <summary>
        /// Gets/sets whether this option is in the selected state.
        /// When this property is set to a new value, this object's
        /// PropertyChanged event is raised.
        /// </summary>
        public bool IsSelected
        {
            get { return _isSelected; }
            set 
            {
                if (value == _isSelected)
                    return;

                _isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

        public bool IsEnabled
        {
            get { return _enabled; }
        }

        /// <summary>
        /// Returns the value used to sort this option.
        /// The default sort value is Int32.MinValue.
        /// </summary>
        public int SortValue
        {
            get { return _sortValue; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns the underlying value of this option.
        /// Note: this is a method, instead of a property,
        /// so that the UI cannot bind to it.
        /// </summary>
        internal TValue GetValue()
        {
            return _value;
        }

        #endregion

        #region IComparable<OptionViewModel<TValue>> Members

        public int CompareTo(OptionViewModel<TValue> other)
        {
            if (other == null)
                return -1;

            if (SortValue == UnsetSortValue && other.SortValue == UnsetSortValue)
            {
                return DisplayName.CompareTo(other.DisplayName);
            }
            if (SortValue != UnsetSortValue && other.SortValue != UnsetSortValue)
            {
                return SortValue.CompareTo(other.SortValue);
            }
            if (SortValue != UnsetSortValue && other.SortValue == UnsetSortValue)
            {
                return -1;
            }
            return +1;
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion       
    }
}