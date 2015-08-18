using System;
using ProcessViewer.Forms;
using ProcessViewer.Interface;
using ProcessViewer.Library;
using ProcessViewer.ViewModel;

namespace ProcessViewer
{
    /// <summary>
    /// Interaction logic for ProcessViewerDrawDialog.xaml
    /// </summary>
    public partial class ProcessViewerDialog
    {
        readonly WizardViewModel _processViewerDrawWizardViewModel;
        private ProgressWindow _progressWindow;
        private VisioGraph _visioForm;
        private MsaglForm _msaglForm;

        public ProcessViewerDialog()
        {
            InitializeComponent();
            _processViewerDrawWizardViewModel = new WizardViewModel();
            _processViewerDrawWizardViewModel.RequestClose += OnViewModelRequestClose;
            DataContext = _processViewerDrawWizardViewModel;
        }

        /// <summary>
        /// Returns the Drawing item ordered by the user, 
        /// or null if the user cancelled the order.
        /// </summary>
        public DrawItem Result
        {
            get { return _processViewerDrawWizardViewModel.DrawItem; }
        }

        public void CancelProcess()
        {
            if (_visioForm != null)
                _visioForm.CancelWorker();

        }

        void OnViewModelRequestClose(object sender, EventArgs e)
        {
            if (Result != null)
            {
                _progressWindow = new ProgressWindow() {Owner = this};

                switch (Result.DiagramType)
                {
                    case DiagramType.Msagl:
                        {
                            _msaglForm = new MsaglForm(Result);
                            _msaglForm.ShowDialog();
                            Close();
                        }
                        break;
                    case DiagramType.Visio:
                        {
                            IsEnabled = false;
                            _progressWindow.Show();
                            _visioForm = new VisioGraph(_progressWindow, this);
                        }
                        break;
                }
            }
            else
                Close();
        }

        private void ProcessViewerWizardView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
