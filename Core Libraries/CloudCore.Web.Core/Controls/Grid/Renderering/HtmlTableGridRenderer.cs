using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using CloudCore.Web.Core.Controls.Grid.Common;
using CloudCore.Web.Core.Controls.Grid.Components;
using CloudCore.Web.Core.Controls.Pagination;
using System.Web.Helpers;

namespace CloudCore.Web.Core.Controls.Grid.Renderering
{
	/// <summary>
	/// Renders a grid as an HTML table.
	/// </summary>
	public class HtmlTableGridRenderer<T> : GridRenderer<T> where T: class 
	{
        private const string DefaultCssClass = "gridtable table table-striped table-bordered";
        private const string GridDivName = "infowebgrid";

		public HtmlTableGridRenderer(ViewEngineCollection engines) : base(engines)
		{
			
		}
		public HtmlTableGridRenderer() {}

		protected override void RenderHeaderCellEnd()
		{
			RenderText("</th>");
		}

		protected virtual void RenderEmptyHeaderCellStart()
		{
			RenderText("<th>");
		}

		protected override void RenderHeaderCellStart(GridColumn<T> column) 
		{
			var attributes = new Dictionary<string, object>(column.HeaderAttributes);

			if(IsSortingEnabled && column.Sortable)
			{
				bool isSortedByThisColumn = (GridModel.SortOptions.Column == GenerateSortColumnName(column));

				if (isSortedByThisColumn) 
				{
					string sortClass = GridModel.SortOptions.Direction == SortDirection.Ascending ? "sort_asc" : "sort_desc";

					if(attributes.ContainsKey("class") && attributes["class"] != null)
					{
						sortClass = string.Join(" ", new[] { attributes["class"].ToString(), sortClass });
					}

					attributes["class"] = sortClass;
				}
			}

			string attrs = BuildHtmlAttributes(attributes);

            if (attrs.Length > 0)
            {
                attrs = " " + attrs;
            }

			RenderText(string.Format("<th{0}>", attrs));
		}


		protected override void RenderHeaderText(GridColumn<T> column) 
		{
			if(IsSortingEnabled && column.Sortable)
			{
				string sortColumnName = GenerateSortColumnName(column);

				bool isSortedByThisColumn = GridModel.SortOptions.Column == sortColumnName;

				var sortOptions = new GridOptions 
				{
					Column = sortColumnName
				};

				if(isSortedByThisColumn)
				{
					sortOptions.Direction = (GridModel.SortOptions.Direction == SortDirection.Ascending)
						? SortDirection.Descending 
						: SortDirection.Ascending;
				}
				else //default sort order
				{
					sortOptions.Direction = GridModel.SortOptions.Direction;
				}

				var routeValues = CreateRouteValuesForSortOptions(sortOptions, GridModel.SortPrefix);

				//Re-add existing querystring
				foreach(var key in Context.RequestContext.HttpContext.Request.QueryString.AllKeys.Where(key => key != null))
				{
					if(! routeValues.ContainsKey(key))
					{
						routeValues[key] = Context.RequestContext.HttpContext.Request.QueryString[key];
					}
				}

                var link = BuildSortUrl(Context.RequestContext, routeValues, column.DisplayName);
				RenderText(link);
			}
			else
			{
				base.RenderHeaderText(column);
			}
		}

        private string BuildSortUrl(RequestContext requestContext, RouteValueDictionary routeValues, string columnDisplayName)
        {
            var url = UrlHelper.GenerateUrl(null, null, null, routeValues, RouteTable.Routes, requestContext, true);

            var builder = new TagBuilder("a");
            builder.SetInnerText(columnDisplayName);
            builder.MergeAttribute("href", url);
            return builder.ToString(TagRenderMode.Normal);
        }

        private string CreateRouteValuesForPageOptions(IGridPageOptions pageOptions, string prefix)
        {
            if (string.IsNullOrEmpty(prefix))
            {
                return "page";
            }

            return prefix + "." + "page";
        }

        private RouteValueDictionary CreateRouteValuesForSortOptions(IGridSortOptions sortOptions, string prefix)
		{
			if(string.IsNullOrEmpty(prefix))
			{
				return new RouteValueDictionary(sortOptions);
			}

			return new RouteValueDictionary(new Dictionary<string, object>()
			{
				{ prefix + "." + "Column", sortOptions.Column },
				{ prefix + "." + "Direction", sortOptions.Direction }
			});
		}

		protected virtual string GenerateSortColumnName(GridColumn<T> column)
		{
			//Use the explicit sort column name if specified. If not possible, fall back to the property name.
			//If the property name cannot be inferred (ie the expression is not a MemberExpression) then try the display name instead.
			return column.SortColumnName ?? column.Name ?? column.DisplayName;
		}

		protected override void RenderRowStart(GridRowViewData<T> rowData)
		{
			var attributes = GridModel.Sections.Row.Attributes(rowData);

			if(! attributes.ContainsKey("class"))
			{
				attributes["class"] = rowData.IsAlternate ? "gridrow_alternate" : "gridrow";
			}

			string attributeString = BuildHtmlAttributes(attributes);

			if(attributeString.Length > 0)
			{
				attributeString = " " + attributeString;	
			}

			RenderText(string.Format("<tr{0}>", attributeString));
		}

		protected override void RenderRowEnd()
		{
			RenderText("</tr>");
		}

		protected override void RenderEndCell()
		{
			RenderText("</td>");
		}

//        protected override void RenderEmptyFooter()
//        {
//            RenderText(String.Format(@"<tfoot><tr><td colspan=""{0}"">", GridModel.Columns.Count));
//            RenderText("</td></tr></tfoot>");
//        }

        protected override void RenderPagingFooter()
        {
            var pager = new Pager.Pager((IPagination)DataSource, Context, CreateRouteValuesForPageOptions(GridModel.PageOptions, GridModel.PagePrefix));
            RenderText(@"<div class=""pagination label label-default"" >");
            
            if (GridModel.DisablePaging)
            {
                pager = pager.DisableNavigation();
            }
            if (GridModel.HasCustomFooter)
            {
                pager = pager.EnableCustomFooter(GridModel.CustomFooterText);
            }

            RenderText(pager.ToHtmlString());
            RenderText("</div>");
        }

		protected override void RenderStartCell(GridColumn<T> column, GridRowViewData<T> rowData)
		{
			string attrs = BuildHtmlAttributes(column.Attributes(rowData));
			if (attrs.Length > 0)
				attrs = " " + attrs;

			RenderText(string.Format("<td{0}>", attrs));
		}


		protected override void RenderHeadStart(bool removeHeaderRow = false)
		{
            RenderText("<thead>");
            //Check 
            IDictionary<string, object> atts = GridModel.Sections.HeaderRow.Attributes(new GridRowViewData<T>(null, false));

            string attributes = BuildHtmlAttributes(atts);
			if(attributes.Length > 0)
			{
				attributes = " " + attributes;
			}

            if (!removeHeaderRow)
                RenderText(string.Format("<tr{0}>", attributes));
		}

		protected override void RenderHeadEnd()
		{
			RenderText("</tr></thead>");
		}

		protected override void RenderGridStart()
		{
			if(!GridModel.Attributes.ContainsKey("class"))
			{
				GridModel.Attributes["class"] = DefaultCssClass;
			}

			string attrs = BuildHtmlAttributes(GridModel.Attributes);

            if (attrs.Length > 0)
            {
                attrs = " " + attrs;
            }

            RenderText(String.Format(@"<div class=""{0}"">", GridDivName));
            if ((GridModel.Title != string.Empty) && (GridModel.Title != null))
            {
                RenderText(String.Format(@"<h4 class=""page-header"">{0}</h4>", GridModel.Title));
            }
            RenderText(@"<div class=""table-responsive"">");
			RenderText(String.Format("<table{0}>", attrs));
		}

		protected override void RenderGridEnd()
		{
			RenderText("</table>");
            RenderText("</div>");
            RenderText("</div>");
		}

		protected override void RenderEmpty()
		{
		    RenderHeadStart(true);
            //RenderEmptyHeaderCellStart();
            //RenderHeaderCellEnd();
            RenderHeadEnd();            
		    RenderBodyStart();
			RenderText("<tr><td>" + GridModel.EmptyText + "</td></tr>");
            RenderBodyEnd();
		}

		protected override void RenderBodyStart() 
		{
			RenderText("<tbody>");
		}

		protected override void RenderBodyEnd() 
		{
			RenderText("</tbody>");
		} 

		/// <summary>
		/// Converts the specified attributes dictionary of key-value pairs into a string of HTML attributes. 
		/// </summary>
		/// <returns></returns>
		protected string BuildHtmlAttributes(IDictionary<string, object> attributes)
		{
			return DictionaryExtensions.ToHtmlAttributes(attributes);
		}
	}
}