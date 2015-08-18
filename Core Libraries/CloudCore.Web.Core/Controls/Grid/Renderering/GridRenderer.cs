using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using CloudCore.Web.Core.Controls.Grid.Components;
using CloudCore.Web.Core.Controls.Pagination;
using CloudCore.Web.Core.Controls.Sorting;
using System.Web.Helpers;

namespace CloudCore.Web.Core.Controls.Grid.Renderering
{
    /// <summary>
    /// Base class for Grid Renderers. 
    /// </summary>
    public abstract class GridRenderer<T> : IGridRenderer<T> where T : class
    {
        protected IGridModel<T> GridModel { get; private set; }
        protected IEnumerable<T> DataSource { get; private set; }
        protected ViewContext Context { get; private set; }
        private TextWriter _writer;
        private readonly ViewEngineCollection _engines;

        protected TextWriter Writer
        {
            get { return _writer; }
        }

        protected GridRenderer() : this(ViewEngines.Engines) { }

        protected GridRenderer(ViewEngineCollection engines)
        {
            _engines = engines;
        }

        public void Render(IGridModel<T> gridModel, IQueryable<T> dataSource, TextWriter output, ViewContext context)
        {
            int reloadCount = Convert.ToInt16(context.TempData["reloadCheck"] ?? 0);

            _writer = output;
            GridModel = gridModel;

            DataSource = dataSource;
            if (IsSortingEnabled)
            {
                if (GridModel.SortOptions.Column == null)
                {
                    GridColumn<T> column = null;

                    if (!string.IsNullOrEmpty(GridModel.InitialSortColumnName))
                    {
                        column = gridModel.Columns.FirstOrDefault(c => c.Name == GridModel.InitialSortColumnName);
                    }

                    if (column == null)
                    {
                        column = GetFirstSortableColumn(gridModel.Columns);
                    }

                    if (column != null)
                    {
                        var options = GridModel.SortOptions;
                        options.Column = column.SortColumnName;
                        options.Direction = string.IsNullOrEmpty(GridModel.InitialSortColumnName) ? SortDirection.Ascending : GridModel.InitialSortDirection;
                        DataSource = DataSource.OrderBy(column.SortColumnName, options.Direction);
                    }
                }
                else
                {
                    DataSource = DataSource.OrderBy(gridModel.SortOptions.Column, gridModel.SortOptions.Direction);
                }
            }

            if (IsPagingEnable)
            {
                DataSource = DataSource.AsPagination(gridModel.PageOptions);
            }

            Context = context;

            if (!IsDataSourceEmpty())
            {
                RenderGridStart();
                RenderHeader();
                RenderItems();

            }
            else
            {
                if (GridModel.PageOptions.CurrentPage > 1)
                {
                    if (reloadCount == 1)
                    {
                        const string pageQueryString = "page={0}";
                        if (context.HttpContext.Request.Url != null)
                        {
                            var newUrl = context.HttpContext.Request.Url.AbsoluteUri.Replace(
                                string.Format(pageQueryString, GridModel.PageOptions.CurrentPage + reloadCount),
                                string.Format(pageQueryString, 1));

                            var redirect = new RedirectResult(newUrl);
                            redirect.ExecuteResult(context.Controller.ControllerContext);
                        }

                        context.TempData["reloadCheck"] = 0;
                        return;
                    }

                    context.TempData["reloadCheck"] = reloadCount + 1;
                    gridModel.PageOptions.CurrentPage -= 1;
                    Render(gridModel, dataSource, output, context);
                    return;
                }

                RenderGridStart();
                RenderEmpty();
                // RenderEmptyFooter();
            }

            RenderGridEnd();

            if (IsPagingEnable && !IsDataSourceEmpty())
            {
                RenderPagingFooter();
            }
        }

        private GridColumn<T> GetFirstSortableColumn(IList<GridColumn<T>> gridColumns)
        {
            return gridColumns.FirstOrDefault(x => x.Sortable == true && x.SortColumnName != null);
        }

        protected virtual void RenderPagingFooter() { }

        protected virtual void RenderEmptyFooter() { }

        protected void RenderText(string text)
        {
            Writer.Write(text);
        }

        protected virtual void RenderItems()
        {
            RenderBodyStart();

            bool isAlternate = false;
            foreach (var item in DataSource)
            {
                RenderItem(new GridRowViewData<T>(item, isAlternate));
                isAlternate = !isAlternate;
            }

            RenderBodyEnd();
        }

        protected virtual void RenderItem(GridRowViewData<T> rowData)
        {
            BaseRenderRowStart(rowData);

            foreach (var column in VisibleColumns())
            {
                //A custom item section has been specified - render it and continue to the next iteration.
#pragma warning disable 612,618
                // TODO: CustomItemRenderer is obsolete in favour of custom columns. Remove this after next release.
                if (column.CustomItemRenderer != null)
                {
                    column.CustomItemRenderer(new RenderingContext(Writer, Context, _engines), rowData.Item);
                    continue;
                }
#pragma warning restore 612,618

                RenderStartCell(column, rowData);
                RenderCellValue(column, rowData);
                RenderEndCell();
            }

            BaseRenderRowEnd(rowData);
        }

        protected virtual void RenderCellValue(GridColumn<T> column, GridRowViewData<T> rowData)
        {
            var cellValue = column.GetValue(rowData.Item);

            if (cellValue != null)
            {
                RenderText(cellValue.ToString());
            }
        }

        protected virtual bool RenderHeader()
        {
            RenderHeadStart();

            foreach (var column in VisibleColumns())
            {

                //Allow for custom header overrides.
#pragma warning disable 612,618
                if (column.CustomHeaderRenderer != null)
                {
                    column.CustomHeaderRenderer(new RenderingContext(Writer, Context, _engines));
                }
#pragma warning restore 612,618
                else
                {
                    RenderHeaderCellStart(column);
                    RenderHeaderText(column);
                    RenderHeaderCellEnd();
                }
            }

            RenderHeadEnd();

            return true;
        }

        protected virtual void RenderHeaderText(GridColumn<T> column)
        {
            var customHeader = column.GetHeader();

            if (customHeader != null)
            {
                RenderText(customHeader);
            }
            else
            {
                RenderText(column.DisplayName);
            }
        }

        protected bool IsDataSourceEmpty()
        {
            return DataSource == null || !DataSource.Any();
        }

        protected IEnumerable<GridColumn<T>> VisibleColumns()
        {
            return GridModel.Columns.Where(x => x.Visible);
        }

        protected void BaseRenderRowStart(GridRowViewData<T> rowData)
        {
            bool rendered = GridModel.Sections.Row.StartSectionRenderer(rowData, new RenderingContext(Writer, Context, _engines));

            if (!rendered)
            {
                RenderRowStart(rowData);
            }
        }

        protected void BaseRenderRowEnd(GridRowViewData<T> rowData)
        {
            bool rendered = GridModel.Sections.Row.EndSectionRenderer(rowData, new RenderingContext(Writer, Context, _engines));

            if (!rendered)
            {
                RenderRowEnd();
            }
        }

        protected bool IsSortingEnabled
        {
            get { return GridModel.SortOptions != null; }
        }

        protected bool IsPagingEnable
        {
            get { return GridModel.PageOptions != null; }
        }

        protected abstract void RenderHeaderCellEnd();
        protected abstract void RenderHeaderCellStart(GridColumn<T> column);
        protected abstract void RenderRowStart(GridRowViewData<T> rowData);
        protected abstract void RenderRowEnd();
        protected abstract void RenderEndCell();
        protected abstract void RenderStartCell(GridColumn<T> column, GridRowViewData<T> rowViewData);
        protected abstract void RenderHeadStart(bool removeHeaderRow = false);
        protected abstract void RenderHeadEnd();
        protected abstract void RenderGridStart();
        protected abstract void RenderGridEnd();
        protected abstract void RenderEmpty();
        protected abstract void RenderBodyStart();
        protected abstract void RenderBodyEnd();
    }
}
