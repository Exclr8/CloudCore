using System.Web.Helpers;
namespace CloudCore.Web.Core.Controls.Grid.Components
{
    public interface IGridSortOptions
    {
        string Column { get; set; }
        SortDirection Direction { get; set; }
    }
}
