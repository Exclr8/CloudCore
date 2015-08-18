using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Web;
using CloudCore.Web.Core.Controls.Grid.Components;
using System.Web.Helpers;

namespace CloudCore.Web.Core.Controls.Grid.Common
{
	public interface IGrid<T> : IGridWithOptions<T> where T: class 
	{
		/// <summary>
		/// Specifies a custom GridModel to use.
		/// </summary>
		/// <param name="model">The GridModel storing information about this grid</param>
		/// <returns></returns>
		IGrid<T> WithModel(IGridModel<T> model);
	}

	public interface IGridWithOptions<T> : IHtmlString where T : class 
	{
		/// <summary>
		/// The GridModel that holds the internal representation of this grid.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)] //hide from fluent interface
		IGridModel<T> Model { get; }

		/// <summary>
		/// Specifies that the grid should be rendered using a specified renderer.
		/// </summary>
		/// <param name="renderer">Renderer to use</param>
		/// <returns></returns>
		IGridWithOptions<T> RenderUsing(IGridRenderer<T> renderer);

		/// <summary>
		/// Specifies the columns to use. 
		/// </summary>
		/// <param name="columnBuilder"></param>
		/// <returns></returns>
		IGridWithOptions<T> Columns(Action<ColumnBuilder<T>> columnBuilder);

		/// <summary>
		/// Text to render when grid is empty.
		/// </summary>
		/// <param name="emptyText">Empty Text</param>
		/// <returns></returns>
		IGridWithOptions<T> Empty(string emptyText);

        /// <summary>
        /// Display empty text based on item name
        /// </summary>
        /// <param name="emptyTableItemName">Empty Text</param>
        /// <returns></returns>
        IGridWithOptions<T> EmptyTableItemName(string emptyTableItemName);

		/// <summary>
		/// Additional custom attributes
		/// </summary>
		/// <returns></returns>
		IGridWithOptions<T> Attributes(IDictionary<string, object> attributes);

		/// <summary>
		/// Additional custom attributes for each row
		/// </summary>
		/// <param name="attributes">Lambda expression that returns custom attributes for each row</param>
		/// <returns></returns>
		IGridWithOptions<T> RowAttributes(Func<GridRowViewData<T>, IDictionary<string, object>> attributes);

		/// <summary>
		/// Additional custom attributes for the header row.
		/// </summary>
		/// <param name="attributes">Attributes for the header row</param>
		/// <returns></returns>
		IGridWithOptions<T> HeaderRowAttributes(IDictionary<string, object> attributes);


		/// <summary>
		/// Specifies that the grid is currently sorted
		/// </summary>
		IGridWithOptions<T> Sort(IGridSortOptions sortOptions);

		/// <summary>
		/// Specifies that the grid is sorted. Column links will have the specified prefix prepended.
		/// </summary>
        IGridWithOptions<T> Sort(IGridSortOptions sortOptions, string prefix);

        IGridWithOptions<T> PageSize(int pageSize);

        IGridWithOptions<T> DisableNavigation();

        IGridWithOptions<T> CustomFooter(string customFooterText);

        IGridWithOptions<T> Title(string title);

        IGridWithOptions<T> InitialSortColumn(string columnName, SortDirection direction);

        IGridWithOptions<T> InitialSortColumn(Expression<Func<T, object>> propertySpecifier, SortDirection direction);
    }
}
