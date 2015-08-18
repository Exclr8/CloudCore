using System;
using System.Collections.Generic;
using CloudCore.Web.Core.Controls.Grid.Common;
using CloudCore.Web.Core.Controls.Grid.Renderering;
using System.Web.Helpers;

namespace CloudCore.Web.Core.Controls.Grid.Components
{
	/// <summary>
	/// Default model for grid
	/// </summary>
	public class GridModel<T>  : IGridModel<T> where T : class
	{
		private readonly ColumnBuilder<T> _columnBuilder;
		private readonly GridSections<T> _sections = new GridSections<T>();
		private IGridRenderer<T> _renderer = new HtmlTableGridRenderer<T>();
		private string _emptyText;
		private IDictionary<string, object> _attributes = new Dictionary<string, object>();
		private IGridSortOptions _sortOptions;
		private string _sortPrefix;
        private string _pagePrefix;
        private IGridPageOptions _pageOptions;
        private bool _disablePaging = false;
        private bool _hasCustomFooter = false;
        private string _customFooterText = string.Empty;
        private string _emptyTableItemName;
        private string _title;
        private SortDirection _initialSortDirection;
        private string _initialSortColumnName;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        IGridSortOptions IGridModel<T>.SortOptions
		{
			get { return _sortOptions; }
			set { _sortOptions = value; }
		}

        bool IGridModel<T>.DisablePaging
        {
            get { return _disablePaging; }
            set { _disablePaging = value; }
        }

        bool IGridModel<T>.HasCustomFooter
        {
            get { return _hasCustomFooter; }
            set { _hasCustomFooter = value; }
        }
        
        IList<GridColumn<T>> IGridModel<T>.Columns
		{
			get { return _columnBuilder; }
		}

		IGridRenderer<T> IGridModel<T>.Renderer
		{
			get { return _renderer; }
			set { _renderer = value; }
		}

		string IGridModel<T>.EmptyText
		{
			get { return _emptyText; }
			set { _emptyText = value; }
		}

		IDictionary<string, object> IGridModel<T>.Attributes
		{
			get { return _attributes; }
			set { _attributes = value; }
		}

		string IGridModel<T>.SortPrefix
		{
			get { return _sortPrefix; }
			set { _sortPrefix = value; }
		}

        public IGridPageOptions PageOptions
        {
            get { return _pageOptions; }
            set { _pageOptions = value; }
        }

        public string CustomFooterText
        {
            get { return _customFooterText; }
            set { _customFooterText = value; }
        }

        public SortDirection InitialSortDirection
        {
            get { return _initialSortDirection; }
            set { _initialSortDirection = value; }
        }

        public string InitialSortColumnName
        {
            get { return _initialSortColumnName; }
            set { _initialSortColumnName = value; }
        }
        
        public string EmptyTableItemName
        {
            get { return _emptyTableItemName; }
            set { _emptyTableItemName = value; }
        }

		/// <summary>
		/// Creates a new instance of the GridModel class
		/// </summary>
		public GridModel()
		{
			_emptyText = "There are no items to display";
			_columnBuilder = CreateColumnBuilder();
		}

		/// <summary>
		/// Column builder for this grid model
		/// </summary>
		public ColumnBuilder<T> Column
		{
			get { return _columnBuilder; }
		}

		/// <summary>
		/// Section overrides for this grid model.
		/// </summary>
		IGridSections<T> IGridModel<T>.Sections
		{
			get { return _sections; }
		}

		/// <summary>
		/// Section overrides for this grid model.
		/// </summary>
		public GridSections<T> Sections
		{
			get { return _sections; }
		}

		/// <summary>
		/// Text that will be displayed when the grid has no data.
		/// </summary>
		/// <param name="emptyText">Text to display</param>
		public void Empty(string emptyText)
		{
			_emptyText = emptyText;
		}

		/// <summary>
		/// Defines additional attributes for the grid.
		/// </summary>
		/// <param name="hash"></param>
		public void Attributes(params Func<object, object>[] hash)
		{
			Attributes(new Hash(hash));
		}

		/// <summary>
		/// Defines additional attributes for the grid
		/// </summary>
		/// <param name="attributes"></param>
		public void Attributes(IDictionary<string, object> attributes)
		{
			_attributes = attributes;
		}

		/// <summary>
		/// Specifies the Renderer to use with this grid. If omitted, the HtmlTableGridRenderer will be used. 
		/// </summary>
		/// <param name="renderer">The Renderer to use</param>
		public void RenderUsing(IGridRenderer<T> renderer)
		{
			_renderer = renderer;
		}

		/// <summary>
		/// Secifies that the grid is currently being sorted by the specified column in a particular direction.
		/// </summary>
        public void Sort(IGridSortOptions sortOptions)
		{
			_sortOptions = sortOptions;
		}

		/// <summary>
		/// Specifies that the grid is currently being sorted by the specified column in a particular direction.
		/// This overload allows you to specify a prefix.
		/// </summary>
        public void Sort(IGridSortOptions sortOptions, string prefix)
		{
			_sortOptions = sortOptions;
			_sortPrefix = prefix;
		}

		protected virtual ColumnBuilder<T> CreateColumnBuilder()
		{
			return new ColumnBuilder<T>();
		}


        public string PagePrefix
        {
            get { return _pagePrefix; }
            set { _pagePrefix = value; }
        }
    }
}
