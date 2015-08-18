using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using CloudCore.Web.Core.Controls.Grid.Common;
using CloudCore.Web.Core.Controls.Grid.Components;
using CloudCore.Web.Core.Controls.Grid.Wrappers;
using System.Web.Helpers;

namespace CloudCore.Web.Core.Controls.Grid
{
	/// <summary>
	/// Defines a grid to be rendered.
	/// </summary>
	/// <typeparam name="T">Type of datasource for the grid</typeparam>
	public class Grid<T> : IGrid<T> where T : class
	{
		private readonly ViewContext context;
		private IGridModel<T> gridModel = new GridModel<T>();
        private bool visible = true;

		/// <summary>
		/// The GridModel that holds the internal representation of this grid.
		/// </summary>
		public IGridModel<T> Model
		{
			get { return gridModel; }
		}

		/// <summary>
		/// Creates a new instance of the Grid class.
		/// </summary>
		/// <param name="dataSource">The datasource for the grid</param>
		/// <param name="context"></param>
		public Grid(IQueryable<T> dataSource, ViewContext context)
		{
			this.context = context;
			DataSource = dataSource;
		}

		public IQueryable<T> DataSource { get; private set; }

		public IGridWithOptions<T> RenderUsing(IGridRenderer<T> renderer)
		{
			gridModel.Renderer = renderer;
			return this;
		}

		public IGridWithOptions<T> Columns(Action<ColumnBuilder<T>> columnBuilder)
		{
			var builder = new ColumnBuilder<T>();
			columnBuilder(builder);

			foreach (var column in builder)
			{
				if (column.Position == null) 
				{
					gridModel.Columns.Add(column);
				} 
				else
				{
					gridModel.Columns.Insert(column.Position.Value, column);	
				}
            }

			return this;
		}

		public IGridWithOptions<T> Empty(string emptyText)
		{
			gridModel.EmptyText = emptyText;
			return this;
		}

        public IGridWithOptions<T> CustomFooter(string customFooterText)
        {
            gridModel.CustomFooterText = customFooterText;
            gridModel.HasCustomFooter = true;
            return this;
        }

        public IGridWithOptions<T> EmptyTableItemName(string emptyTableItemName)
        {
            gridModel.EmptyText = string.Format("There are no {0} items to display.", emptyTableItemName);
            return this;
        }

		public IGridWithOptions<T> Attributes(IDictionary<string, object> attributes)
		{
			gridModel.Attributes = attributes;
			return this;
		}

		public IGrid<T> WithModel(IGridModel<T> model)
		{
			gridModel = model;
			return this;
		}

		public IGridWithOptions<T> Sort(IGridSortOptions sortOptions)
		{
			gridModel.SortOptions = sortOptions;
			return this;
		}

        public IGridWithOptions<T> Sort(IGridSortOptions sortOptions, string prefix)
		{
			gridModel.SortOptions = sortOptions;
			gridModel.SortPrefix = prefix;
			return this;
		}

		public override string ToString()
		{
			return ToHtmlString();
		}

		public string ToHtmlString()
		{
            if (!visible)
            {
                return String.Empty;
            }

			var writer = new StringWriter();
            gridModel.Renderer.Render(gridModel, DataSource, writer, context);

			return writer.ToString();
		}

		public IGridWithOptions<T> HeaderRowAttributes(IDictionary<string, object> attributes)
		{
			gridModel.Sections.HeaderRowAttributes(attributes);
			return this;
		}

        public IGridWithOptions<T> InitialSortColumn(string columnName, SortDirection direction)
        {
            gridModel.InitialSortColumnName = columnName;
            gridModel.InitialSortDirection = direction;
            return this;
        }

        public IGridWithOptions<T> InitialSortColumn(Expression<Func<T, object>> propertySpecifier, SortDirection direction)
        {
            var memberExpression = ColumnBuilder<T>.GetMemberExpression(propertySpecifier);
            var propertyType = ColumnBuilder<T>.GetTypeFromMemberExpression(memberExpression);
            var inferredName = memberExpression == null ? null : memberExpression.Member.Name;
            gridModel.InitialSortColumnName = inferredName;
            gridModel.InitialSortDirection = direction;
            return this;
        }

        public IGridWithOptions<T> Title(string title)
        {
            gridModel.Title = title;
            return this;
        }

		public IGridWithOptions<T> RowAttributes(Func<GridRowViewData<T>, IDictionary<string, object>> attributes)
		{
			gridModel.Sections.RowAttributes(attributes);
			return this;
		}


        public IGridWithOptions<T> PageSize(int pageSize)
        {
            if (Model.PageOptions == null)
            {
                Model.PageOptions = new GridOptions();
            }

            Model.PageOptions.PageSize = pageSize;
            return this;
        }


        public IGridWithOptions<T> DisableNavigation()
        {
            Model.DisablePaging = true;
            return this;
        }

        public IGridWithOptions<T> Page(GridOptions gridOptions, string pagePrefix)
        {
            Model.PageOptions = gridOptions;
            Model.PagePrefix = pagePrefix;
            return this;
        }

        internal void SetInvisible()
        {
            visible = false;
        }
    }
}