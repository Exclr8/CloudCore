using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Markup;

namespace ProcessViewer
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // *******************************************************************
            // TODO - Uncomment one of the lines of code that create a CultureInfo
            // in order to see the application run with localized text in the UI.
            // *******************************************************************

            CultureInfo culture = null;

            if (culture != null)
            {
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;
            }

            // Ensure the current culture passed into bindings is the OS culture.
            // By default, WPF uses en-US as the culture, regardless of the system settings.
            FrameworkElement.LanguageProperty.OverrideMetadata(
              typeof(FrameworkElement),
              new FrameworkPropertyMetadata(
                  XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));

            base.OnStartup(e);
        }
    }
}