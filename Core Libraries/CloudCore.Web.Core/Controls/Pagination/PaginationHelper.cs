using System;
using System.Collections.Generic;
using System.Linq;
using CloudCore.Web.Core.Controls.Grid.Components;

namespace CloudCore.Web.Core.Controls.Pagination
{
	/// <summary>
	/// Extension methods for creating paged lists.
	/// </summary>
	public static class PaginationHelper
	{
		/// <summary>
		/// Converts the speciied IEnumerable into an IPagination using the specified page size and returns the specified page. 
		/// </summary>
		/// <typeparam name="T">Type of object in the collection</typeparam>
		/// <param name="source">Source enumerable to convert to the paged list.</param>
        /// <param name="pageOptions">The pageOptions to return.</param>
		/// <returns>An IPagination of T</returns>
        public static IPagination<T> AsPagination<T>(this IEnumerable<T> source, IGridPageOptions pageOptions)
		{
            if (pageOptions.CurrentPage < 1)
			{
                throw new ArgumentOutOfRangeException("pageOptions", @"The pageOptions page number should be greater than or equal to 1.");
			}

            return new SingleQueryPagination<T>(source.AsQueryable(), pageOptions.CurrentPage, pageOptions.PageSize);
		}
	}
}
