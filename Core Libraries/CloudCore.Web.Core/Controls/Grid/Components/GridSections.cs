namespace CloudCore.Web.Core.Controls.Grid.Components
{
	/// <summary>
	/// Sections for a grid.
	/// </summary>
	public class GridSections<T> : IGridSections<T> where T : class
	{
		private GridRow<T> _row = new GridRow<T>();
		private GridRow<T> _headerRow = new GridRow<T>();
        private GridRow<T> _footerRow = new GridRow<T>();

		GridRow<T> IGridSections<T>.Row
		{
			get { return _row; }
		}

		GridRow<T> IGridSections<T>.HeaderRow
		{
			get { return _headerRow; }
		}
        GridRow<T> IGridSections<T>.FooterRow
        {
            get { return _footerRow; }
        }
	}

	public interface IGridSections<T> where T : class
	{
		GridRow<T> Row { get; }
		GridRow<T> HeaderRow { get; }
        GridRow<T> FooterRow { get; }
	}
}
