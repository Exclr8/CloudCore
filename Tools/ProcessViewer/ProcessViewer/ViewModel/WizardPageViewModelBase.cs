using System.ComponentModel;
using ProcessViewer.Library;

namespace ProcessViewer.ViewModel
{
    public abstract class WizardPageViewModelBase : INotifyPropertyChanged
    {
        #region Fields

        readonly DrawItem _drawItem;
        bool _isCurrentPage;

        #endregion

        #region Constructors

        protected WizardPageViewModelBase(DrawItem drawItem)
        {
            _drawItem = drawItem;
        }

        #endregion

        #region Properties

        public DrawItem DrawItem
        {
            get { return _drawItem; }
        }

        public abstract string DisplayName { get; }

        public bool IsCurrentPage
        {
            get { return _isCurrentPage; }
            set
            {
                if (value == _isCurrentPage)
                    return;

                _isCurrentPage = value;
                OnPropertyChanged("IsCurrentPage");
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns true if the user has filled in this page properly
        /// and the wizard should allow the user to progress to the 
        /// next page in the workflow.
        /// </summary>
        internal abstract bool IsValid();

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        internal abstract bool StepBack();
    }
}
