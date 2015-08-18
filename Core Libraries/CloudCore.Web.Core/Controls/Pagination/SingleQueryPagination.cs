using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CloudCore.Web.Core.Controls.Pagination
{
    public class SingleQueryPagination<T> : IPagination<T>
    {
        private IList<T> results;
		public int PageSize { get; private set; }
		/// <summary>
		/// The query to execute.
		/// </summary>
		public IQueryable<T> Query { get; protected set; }
		public int PageNumber { get; private set; }

        private int _totalItems = 0;
        private bool _hasNext = false;

		/// <summary>
		/// Creates a new instance of the <see cref="LazyPagination{T}"/> class.
		/// </summary>
		/// <param name="query">The query to page.</param>
		/// <param name="pageNumber">The current page number.</param>
		/// <param name="pageSize">Number of items per page.</param>
		public SingleQueryPagination(IQueryable<T> query, int pageNumber, int pageSize)
		{
			PageNumber = pageNumber;
			PageSize = pageSize;
			Query = query;
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			TryExecuteQuery();

			foreach (var item in results)
			{
				yield return item;
			}
		}

		/// <summary>
		/// Executes the query if it has not already been executed.
		/// </summary>
		protected void TryExecuteQuery()
		{
			//Results is not null, means query has already been executed.
			if (results != null)
				return;

            results = ExecuteQuery();
            _totalItems = results.Count();
		}

		/// <summary>
		/// Calls Queryable.Skip/Take to perform the pagination.
		/// </summary>
		/// <returns>The paged set of results.</returns>
		protected virtual IList<T> ExecuteQuery()
		{
			int numberToSkip = (PageNumber - 1) * PageSize;

            IList<T> results;

            if (numberToSkip == 0)
            {
                results = Query.Take(PageSize + 1).ToList();
            }
            else
            {
                results = Query.Skip(numberToSkip).Take(PageSize + 1).ToList();
            }	

            _hasNext = results.Count > PageSize;

            return results.Take(PageSize).ToList();
		}

		public IEnumerator GetEnumerator()
		{
			return ((IEnumerable<T>)this).GetEnumerator();
		}

		public int FirstItem
		{
			get
			{
				TryExecuteQuery();
				return ((PageNumber - 1) * PageSize) + 1;
			}
		}

		public int LastItem
		{
			get
			{
				return FirstItem + results.Count - 1;
			}
		}

		public bool HasPreviousPage
		{
			get { return PageNumber > 1; }
		}

		public bool HasNextPage
		{
			get { return _hasNext; }
		}


        public int TotalItems
        {
            get { return _totalItems; }
        }

    }
}
