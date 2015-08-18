namespace CloudCore.Web.Core.BaseViews
{
    public abstract class WorkItemView<T> : WebView<T>
    {
        public override void ExecutePageHierarchy()
        {
            base.ExecutePageHierarchy();
            this.Write(Html.Raw(@"<input type=""button"" name=""btnComplete"" value=""Complete"" onclick=""document.forms[0].submit();"" />"));
        }

    }
}
