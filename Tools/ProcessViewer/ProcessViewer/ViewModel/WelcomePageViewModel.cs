using ProcessViewer.Resources;

namespace ProcessViewer.ViewModel
{
    /// <summary>
    /// The first wizard page in the workflow.  
    /// This page has no functionality.
    /// </summary>
    public class WelcomePageViewModel : WizardPageViewModelBase
    {
        public WelcomePageViewModel()
            : base(null)
        {
            
        }

        public override string DisplayName
        {
            get { return Strings.PageDisplayName_Welcome; }
        }

        internal override bool IsValid()
        {
            return true;
        }

        internal override bool StepBack()
        {
            return true;
        }
    }
}