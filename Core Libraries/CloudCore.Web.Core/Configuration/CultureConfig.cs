using System.Globalization;

namespace CloudCore.Web.Core.Configuration
{
    public static class CultureConfig
    {
        public static void RegisterCulture()
        {
            var newCulture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            newCulture.NumberFormat.CurrencyDecimalSeparator = ".";
            newCulture.NumberFormat.NumberDecimalSeparator = ".";
            newCulture.NumberFormat.PercentDecimalSeparator = ".";

            System.Threading.Thread.CurrentThread.CurrentCulture = newCulture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = newCulture;
        }
    }
}
