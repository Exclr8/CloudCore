using System.Windows;
using System;


namespace ProcessViewer.Forms
{
    /// <summary>
    /// Interaction logic for ProgressWindow.xaml
    /// </summary>
    public partial class ProgressWindow : Window
    {
        public ProgressWindow()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
            //((ProcessViewerDialog)Owner).CancelProcess();
        }

    }
}
