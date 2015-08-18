using System.Web.Helpers;
namespace CloudCore.Web.Core.Controls.Grid.Components
{
    public class GridOptions : IGridSortOptions, IGridPageOptions
    {
        public GridOptions()
        {
            PageSize = 10;
            CurrentPage = 1;
            Direction = SortDirection.Ascending;
        }

        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public string Column { get; set; }
        public SortDirection Direction { get; set; }
    }
}
