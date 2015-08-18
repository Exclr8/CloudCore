using System;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CloudCore.Web.Core.Controls.Pagination;

namespace CloudCore.Web.Core.Controls.Pager
{
	/// <summary>
	/// Renders a pager component from an IPagination datasource.
	/// </summary>
	public class Pager : IHtmlString
	{
		private readonly IPagination _pagination;
		private readonly ViewContext _viewContext;

        private string _paginationNoCountFormat = "Showing {0} record(s) ";
        private string _paginationSearchLessThanTenFormat = "{0} record(s) found.";
        private string _paginationSearchMoreThanTenFormat = "More than {0} record(s) match your search criteria. Please be more specific.";
		private string _paginationFirst = "first";
		private string _paginationPrev = "prev";
		private string _paginationNext = "next";
		private string _paginationLast = "last";
		private string _pageQueryParam;
        private bool _showNavigation = true;
		private Func<int, string> _urlBuilder;
        private bool _hasCustomFooter;
        private string _customFooterText = string.Empty;

		/// <summary>
		/// Creates a new instance of the Pager class.
		/// </summary>
		/// <param name="pagination">The IPagination datasource</param>
		/// <param name="context">The view context</param>
		public Pager(IPagination pagination, ViewContext context, string pageQueryParam = "page")
		{
			_pagination = pagination;
			_viewContext = context;
            _pageQueryParam = pageQueryParam;
			_urlBuilder = CreateDefaultUrl;
		}

		protected ViewContext ViewContext 
		{
			get { return _viewContext; }
		}


		/// <summary>
		/// Specifies the query string parameter to use when generating pager links. The default is 'page'
		/// </summary>
		public Pager QueryParam(string queryStringParam)
		{
            _pageQueryParam = queryStringParam;
			return this;
		}

        public Pager DisableCustomFooter()
        {
            _hasCustomFooter = false;
            return this;
        }

        public Pager EnableCustomFooter(string customFooterText)
        {
            _hasCustomFooter = true;
            _customFooterText = customFooterText;
            return this;
        }
        
        public Pager DisableNavigation()
        {
            _showNavigation = false;
            return this;
        }

		/// <summary>
		/// Specifies the format to use when rendering a pagination containing multiple pages. 
		/// The default is 'Showing {0} - {1} of {2}' (eg 'Showing 1 to 3 of 6')
		/// </summary>
		public Pager Format(string format)
		{
			//_paginationFormat = format;
			return this;
		}

		/// <summary>
		/// Text for the 'first' link.
		/// </summary>
		public Pager First(string first)
		{
			_paginationFirst = first;
			return this;
		}

		/// <summary>
		/// Text for the 'prev' link
		/// </summary>
		public Pager Previous(string previous)
		{
			_paginationPrev = previous;
			return this;
		}

		/// <summary>
		/// Text for the 'next' link
		/// </summary>
		public Pager Next(string next)
		{
			_paginationNext = next;
			return this;
		}

		/// <summary>
		/// Text for the 'last' link
		/// </summary>
		public Pager Last(string last)
		{
			_paginationLast = last;
			return this;
		}

		/// <summary>
		/// Uses a lambda expression to generate the URL for the page links.
		/// </summary>
		/// <param name="urlBuilder">Lambda expression for generating the URL used in the page links</param>
		public Pager Link(Func<int, string> urlBuilder)
		{
			_urlBuilder = urlBuilder;
			return this;
		}

		// For backwards compatibility with WebFormViewEngine
		public override string ToString()
		{
			return ToHtmlString();
		}

		public string ToHtmlString()
		{
			if (_pagination.TotalItems == 0) 
			{
				return null;
			}

			var builder = new StringBuilder();

			RenderLeftSideOfPager(builder);

			if (_pagination.HasPreviousPage || _pagination.HasNextPage)
			{
				RenderRightSideOfPager(builder);
			}

			return builder.ToString();
		}

		protected virtual void RenderLeftSideOfPager(StringBuilder builder)
		{
			builder.Append(@"<span class=""left"">");

            if (!_showNavigation)
            {
                RenderNumberOfItemsBasedOnSearchGrid(builder);
            }
            else
            {
               RenderNumberOfItemsWhenThereAreMultipleItemsPerPage(builder);
            }
			builder.Append("</span>");
		}

		protected virtual void RenderRightSideOfPager(StringBuilder builder)
		{
            if (!_showNavigation)
            {
                return;
            }

            builder.Append(@"<span class=""right"">");

            //If we're on page 1 then there's no need to render a link to the first page. 
            if (_pagination.PageNumber == 1)
            {
                builder.Append(_paginationFirst);
            }
            else
            {
                builder.Append(CreatePageLink(1, _paginationFirst));
            }

            builder.Append(" | ");

            //If we're on page 2 or later, then render a link to the previous page. 
            //If we're on the first page, then there is no need to render a link to the previous page. 
            if (_pagination.HasPreviousPage)
            {
                builder.Append(CreatePageLink(_pagination.PageNumber - 1, _paginationPrev));
            }
            else
            {
                builder.Append(_paginationPrev);
            }

            builder.Append(" | ");

            //Only render a link to the next page if there is another page after the current page.
            if (_pagination.HasNextPage)
            {
                builder.Append(CreatePageLink(_pagination.PageNumber + 1, _paginationNext));
            }
            else
            {
                builder.Append(_paginationNext);
            }

            builder.Append(" | ");

            builder.Append("</span>");
		}

        protected virtual void RenderNumberOfItemsBasedOnSearchGrid(StringBuilder builder)
        {
            if (_pagination.HasNextPage)
            {
                builder.AppendFormat(_paginationSearchMoreThanTenFormat, _pagination.PageSize);
            }
            else
            {
                builder.AppendFormat(_paginationSearchLessThanTenFormat, _pagination.TotalItems);
            }
        }

		protected virtual void RenderNumberOfItemsWhenThereAreMultipleItemsPerPage(StringBuilder builder) 
		{
            if (_hasCustomFooter)
            {
                string footerName = _pageQueryParam;
                int dotIndex = _pageQueryParam.IndexOf(".");

                if (dotIndex >= 0)
                {
                    footerName = _pageQueryParam.Substring(0, dotIndex);
                }
                
                builder.AppendFormat(@"<span id=""customFooter_{0}"">{1}</span>", footerName, _customFooterText);
            }
            else
            {
                builder.AppendFormat(_paginationNoCountFormat, _pagination.TotalItems);
            }
		}

		private string CreatePageLink(int pageNumber, string text)
		{
			var builder = new TagBuilder("a");
			builder.SetInnerText(text);
			builder.MergeAttribute("href",  _urlBuilder(pageNumber));
            return builder.ToString(TagRenderMode.Normal);
		}

		private string CreateDefaultUrl(int pageNumber)
		{
			var routeValues = new RouteValueDictionary();

			foreach (var key in _viewContext.RequestContext.HttpContext.Request.QueryString.AllKeys.Where(key => key != null))
			{
				routeValues[key] = _viewContext.RequestContext.HttpContext.Request.QueryString[key];
			}

            routeValues[_pageQueryParam] = pageNumber;

			var url = UrlHelper.GenerateUrl(null, null, null, routeValues, RouteTable.Routes, _viewContext.RequestContext, true);
			return url;
		}
	}
}