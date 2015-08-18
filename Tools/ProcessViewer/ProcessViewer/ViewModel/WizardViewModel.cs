using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using ProcessViewer.Command;
using ProcessViewer.Library;
using ProcessViewer.Resources;
using System.Linq;

namespace ProcessViewer.ViewModel
{
    class WizardViewModel : INotifyPropertyChanged
    {
        #region Fileds
        
        RelayCommand _cancelCommand;
        RelayCommand _moveNextCommand;
        RelayCommand _movePreviousCommand;
        ReadOnlyCollection<WizardPageViewModelBase> _pages;
        WizardPageViewModelBase _currentPage;

        #endregion

        #region Constructor

        public WizardViewModel()
        {
            DrawItem = new DrawItem();
            CurrentPage = Pages[0];
        }

        #endregion

        #region CancelCommand

        /// <summary>
        /// Returns the command which, when executed, cancels the order 
        /// and causes the Wizard to be removed from the user interface.
        /// </summary>
        public ICommand CancelCommand
        {
            get { return _cancelCommand ?? (_cancelCommand = new RelayCommand(CancelOrder)); }
        }

        void CancelOrder()
        {
            DrawItem = null;
            OnRequestClose();
        }

        #endregion

        #region MovePreviousCommand

        /// <summary>
        /// Returns the command which, when executed, causes the CurrentPage 
        /// property to reference the previous page in the workflow.
        /// </summary>
        public ICommand MovePreviousCommand
        {
            get { return _movePreviousCommand ?? (_movePreviousCommand = new RelayCommand(MoveToPreviousPage, () => CanMoveToPreviousPage)); }
        }

        bool CanMoveToPreviousPage
        {
            get { return 0 < CurrentPageIndex && CurrentPage.StepBack(); }
        }

        void MoveToPreviousPage()
        {
            if (CanMoveToPreviousPage)
                CurrentPage = Pages[CurrentPageIndex - 1];
        }

        #endregion

        #region MoveNextCommand

        /// <summary>
        /// Returns the command which, when executed, causes the CurrentPage 
        /// property to reference the next page in the workflow.  If the user
        /// is viewing the last page in the workflow, this causes the Wizard
        /// to finish and be removed from the user interface.
        /// </summary>
        public ICommand MoveNextCommand
        {
            get { return _moveNextCommand ?? (_moveNextCommand = new RelayCommand(MoveToNextPage, () => CanMoveToNextPage)); }
        }

        bool CanMoveToNextPage
        {
            get { return CurrentPage != null && CurrentPage.IsValid(); }
        }

        void MoveToNextPage()
        {
            if (CurrentPage.DisplayName == Strings.PageDisplayName_Database)
            {
                try
                {
                    var dbPage = ((DatabaseViewModel)_currentPage); 
                    
                    DrawItem.ConnectionString =  dbPage.ConnectionString;
                    
                    if (!((DatabaseViewModel)_currentPage).SaveToRegistry())
                    {
                        throw new ArgumentException("Unable to connect to the database with the current configuration.");
                    }
                    DrawItem.Process.Clear();

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            if (!CanMoveToNextPage) return;
            if (CurrentPageIndex < Pages.Count - 1)
                CurrentPage = Pages[CurrentPageIndex + 1];
            else
                OnRequestClose();
        }        

        #endregion 

        #region properties

        /// <summary>
        /// Returns item to be drawn
        /// If this returns null, the wizard has been cancelled
        /// </summary>
        public DrawItem DrawItem { get; private set; }

        /// <summary>
        /// Returns the page ViewModel that the user is currently viewing.
        /// </summary>
        public WizardPageViewModelBase CurrentPage
        {
            get { return _currentPage; }
            private set
            {
                if (value == _currentPage)
                    return;

                if (_currentPage != null)
                    _currentPage.IsCurrentPage = false;

                _currentPage = value;

                if (_currentPage != null)
                    _currentPage.IsCurrentPage = true;

                OnPropertyChanged("CurrentPage");
                OnPropertyChanged("IsOnLastPage");
            }
        }

        /// <summary>
        /// Returns true if the user is currently viewing the last page 
        /// in the workflow.  This property is used by ProcessViewerWizardView
        /// to switch the Next button's text to "Finish" when the user
        /// has reached the final page.
        /// </summary>
        public bool IsOnLastPage
        {
            get { return CurrentPageIndex == Pages.Count - 1; }
        }

        /// <summary>
        /// Returns a read-only collection of all page ViewModels.
        /// </summary>
        public ReadOnlyCollection<WizardPageViewModelBase> Pages
        {
            get
            {
                if (_pages == null)
                    CreatePages();

                return _pages;
            }
        }


        #endregion

        #region Private Helpers

        void CreatePages()
        {
            var pages = new List<WizardPageViewModelBase>();
            var btdl = new DisplayLevelViewModel(DrawItem);
            var btdo = new OptionsViewModel(DrawItem);
            var btpm = new ProcessViewModel(DrawItem);
            var btdm = new DatabaseViewModel(DrawItem);
            var btpr = new ProcessRevisionViewModel(DrawItem);
            
            pages.Add(new WelcomePageViewModel());
            pages.Add(btdm);
            pages.Add(btpm);
            pages.Add(btpr);
            pages.Add(btdl);
            pages.Add(btdo);
            pages.Add(new SummaryPageViewModel(
                 btdl.AvailableDiagramTypes,
                 btdl.AvailableViewLevels,
                 btdo.AvailableOptions,
                 btdm.AvailableVersions
                 ));

            _pages = new ReadOnlyCollection<WizardPageViewModelBase>(pages);
        }

        int CurrentPageIndex
        {
            get
            {
                if (CurrentPage == null)
                {
                    Debug.Fail("Why is the current page null?");
                    return -1;
                }

                return Pages.IndexOf(CurrentPage);
            }
        }

        void OnRequestClose()
        {
            var handler = RequestClose;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        
        #endregion

        #region Events

        /// <summary>
        /// Raised when the wizard should be removed from the UI.
        /// </summary>
        public event EventHandler RequestClose;

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
