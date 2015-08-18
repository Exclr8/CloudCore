using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CloudCore.Web.Core.Controls.Grid;
using CloudCore.Web.Core.Controls.Grid.Common;
using CloudCore.Web.Core.Controls.Grid.Components;

namespace CloudCore.Web.Core.Razor.Extensions
{
    public static class SearchGridExtensions
    {
        private const string CouldNotFindView =
               "The view '{0}' or its master could not be found. The following locations were searched:{1}";

        /// <summary>
        /// Creates a grid using the specified datasource.
        /// </summary>
        /// <typeparam name="T">Type of datasouce element</typeparam>
        /// <returns></returns>
        public static IGrid<T> SearchGrid<T>(this HtmlHelper helper, IEnumerable<T> dataSource) where T : class
        {
            var grid = new Grid<T>(dataSource.AsQueryable(), helper.ViewContext);

            grid.Empty("Your search criteria did not return any results. Please revise and try again.");

            if (helper.ViewContext.HttpContext.Request.HttpMethod != "POST")
            {
                grid.SetInvisible();
            }
            else
            {
                var gridOptions = new GridOptions
                {
                    CurrentPage = 1,
                };

                grid.DisableNavigation();
                grid.Page(gridOptions, String.Empty);
            }

            return grid;
        }

        /// <summary>
        /// Creates a grid from an entry in the viewdata.
        /// </summary>
        /// <typeparam name="T">Type of element in the grid datasource.</typeparam>
        /// <returns></returns>
        public static IGrid<T> SearchGrid<T>(this HtmlHelper helper, string viewDataKey) where T : class
        {
            var dataSource = helper.ViewContext.ViewData.Eval(viewDataKey) as IQueryable<T>;

            if (dataSource == null)
            {
                throw new InvalidOperationException(string.Format(
                                                        "Item in ViewData with key '{0}' is not an IQueryable of '{1}'.", viewDataKey,
                                                        typeof(T).Name));
            }

            return helper.SearchGrid(dataSource);
        }
    }
}
