using System.Web.Optimization;

namespace CloudCore.Web.Core.Configuration
{

    public static class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Assets/Scripts/jquery/jquery-{version}.js",
                                                                     "~/Assets/Scripts/jquery/jquery.observable.js",
                                                                     "~/Assets/Scripts/jquery/jsrender.js",
                                                                     "~/Assets/Scripts/jquery/jquery.validate.*",
                                                                     "~/Assets/Scripts/jquery/jquery.views.js",
                                                                     "~/Assets/Scripts/jquery/jquery.ui.core.js",
                                                                     "~/Assets/Scripts/jquery/jquery.ui.datepicker.js",
                                                                     "~/Assets/Scripts/jquery/jquery.ui.position.js",
                                                                     "~/Assets/Scripts/jquery/jquery.ui.widget.js",
                                                                     "~/Assets/Scripts/jquery/jquery.unobtrusive-ajax.js",
                                                                     "~/Assets/Scripts/cloudcore/*.js"));

            bundles.Add(new ScriptBundle("~/bundles/dashboard").IncludeDirectory("~/Assets/Scripts/DashboardService", "*.js", true));

            bundles.Add(new ScriptBundle("~/bundles/localStorageCache").IncludeDirectory("~/Assets/Scripts/LocalStorageCache", "*.js", true));

            bundles.Add(new ScriptBundle("~/bundles/highcharts").Include("~/Assets/Scripts/highcharts/highcharts.src.js",
                                                                         "~/Assets/Scripts/highcharts/highcharts-more.src.js",
                                                                         "~/Assets/Scripts/highcharts/highcharts-3d.src.js"));

            bundles.Add(new StyleBundle("~/Content/Core")
                .Include("~/Assets/Styles/Bootstrap/bootstrap.min.css")
                //.IncludeDirectory("~/Assets/Styles/Core/", "*.css", true)
                .IncludeDirectory("~/Assets/Styles/JQueryUi/", "*.css", true)
                .Include("~/Assets/Styles/Core/cloudcore-custom.css")
                .Include("~/Assets/Styles/Internal/_CloudCoreInternal_Dashboard.css")
                .Include("~/Assets/Styles/Bootstrap/bootstrap-datetimepicker.min.css")
                .Include("~/Assets/Styles/Core/theme-submenu.css"));

            // bundles.Add(new StyleBundle("~/Content/Internal").IncludeDirectory("~/Assets/Styles/Internal/", "*.css", true));
            bundles.Add(new StyleBundle("~/Content/Internal").IncludeDirectory("~/Assets/Styles/Internal/", "lookup.css", true));

            bundles.Add(new StyleBundle("~/Content/Page").IncludeDirectory("~/Assets/Styles/Page/", "*.css", true));

            bundles.Add(new ScriptBundle("~/Assets/Scripts/Bootstrap/bootstrap").Include(
                      "~/Assets/Scripts/Bootstrap/bootstrap.js",
                      "~/Assets/Scripts/Bootstrap/moment.min.js",
                      "~/Assets/Scripts/Bootstrap/moment-with-locales.min.js",
                      "~/Assets/Scripts/Bootstrap/bootstrap-datetimepicker.min.js",
                      "~/Assets/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/PasswordStrengthLibrary").Include(
                      "~/Assets/Scripts/PasswordStrength/*.js"));

            //bundles.Add(new ScriptBundle("~/bundles/HideSeek").Include(
            //          "~/Assets/Scripts/cloudcore/jquery.hideseek.min.js"));

#if DEBUG
            BundleTable.EnableOptimizations = false;
#else
            BundleTable.EnableOptimizations = false; //TODO: optimizing creates virtual paths, some assets eg bootstrap reference dependencies via absolute paths. Fix before allowing Optimizations.
#endif
        }
    }
}
