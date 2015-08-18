using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CloudCore.Web.Core.Controls.Grid;
using CloudCore.Web.Core.Controls.Grid.Common;
using CloudCore.Web.Core.Controls.Grid.Components;
using System.Web.Helpers;

namespace CloudCore.Web.Core.Razor.Extensions
{
    public static class InfoGridExtensions
    {
        private const string CouldNotFindView =
               "The view '{0}' or its master could not be found. The following locations were searched:{1}";

        public static IGrid<T> InfoGrid<T>(this HtmlHelper helper, IEnumerable<T> dataSource, string gridName = "grid") where T : class
        {
            var grid = new Grid<T>(dataSource.AsQueryable(), helper.ViewContext);
            var queryStringData = helper.ViewContext.HttpContext.Request.QueryString;

            int currentPage;
            if (!int.TryParse(queryStringData[GetPrefixedName("page", gridName)], out currentPage))
            {
                currentPage = 1;
            }

            var gridOptions = new GridOptions
            {
                CurrentPage = currentPage,
                Direction = queryStringData[GetPrefixedName("Direction", gridName)] == "Ascending" ? SortDirection.Ascending : SortDirection.Descending,
                Column = queryStringData[GetPrefixedName("Column", gridName)]
            };

            grid.Sort(gridOptions, gridName);
            grid.Page(gridOptions, gridName);

            return grid;
        }

        public static IGrid<T> InfoGrid<T>(this HtmlHelper helper, string viewDataKey, string gridName = "") where T : class
        {
            var dataSource = helper.ViewContext.ViewData.Eval(viewDataKey) as IQueryable<T>;

            if (dataSource == null)
            {
                throw new InvalidOperationException(string.Format(
                                                        "Item in ViewData with key '{0}' is not an IQueryable of '{1}'.", viewDataKey,
                                                        typeof(T).Name));
            }

            return helper.InfoGrid(dataSource, gridName);
        }

        private static string GetPrefixedName(string name, string prefix)
        {
            if (string.IsNullOrEmpty(prefix))
            {
                return name;
            }

            return prefix + "." + name;
        }
    }
}