namespace CloudCore.Web.Core.Controls.Grid.Components
{
    public interface IGridPageOptions
    {
        int PageSize { get; set; }
        int CurrentPage { get; set; }
    }
}
