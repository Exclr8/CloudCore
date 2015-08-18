using System.Collections.Generic;
using System.Web.Helpers;

namespace CloudCore.Web.Core.Controls.Grid.Components
{
	/// <summary>
	/// Defines a grid model
	/// </summary>
	public interface IGridModel<T> where T: class 
	{
		IGridRenderer<T> Renderer { get; set; }
		IList<GridColumn<T>> Columns { get; }
		IGridSections<T> Sections { get; }
		string EmptyText { get; set; }
		IDictionary<string, object> Attributes { get; set; }
        IGridSortOptions SortOptions { get; set; }
        IGridPageOptions PageOptions { get; set; }
        bool DisablePaging { get; set; }
        bool HasCustomFooter { get; set; }
        string SortPrefix { get; set; }
        string PagePrefix { get; set; }
        string EmptyTableItemName { get; set; }
        string Title { get; set; }
        string CustomFooterText { get; set; }
        string InitialSortColumnName { get; set; }
        SortDirection InitialSortDirection { get; set; }
    }
}