using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.WebPages;

namespace CloudCore.Web.Core.Razor.Extensions
{
    public static class WebGridExtensions
    {
        [Obsolete("This grid extenstion is obsolete and will be removed in future versions of CloudCore. Please make plans to change your code to make use of the new Grid features in the 'CloudCore.Controls.UI.Grid namespace'.", error: false)]
        public static IHtmlString GetHtmlWithSelectAllCheckBox(this WebGrid webGrid, string tableStyle = null, string headerStyle = null, string footerStyle = null, string rowStyle = null, string alternatingRowStyle = null, string selectedRowStyle = null, string caption = null, bool displayHeader = true, bool fillEmptyRows = false, string emptyRowCellValue = null, IEnumerable<WebGridColumn> columns = null, IEnumerable<string> exclusions = null, WebGridPagerModes mode = WebGridPagerModes.All, string firstText = null, string previousText = null, string nextText = null, string lastText = null, int numericLinksCount = 5, object htmlAttributes = null, string checkBoxValue = "ID", int checkBoxColumnPosition = 0, bool defaultCheckedState = false, System.Web.Mvc.HtmlHelper helper = null)
        {
            var newVisibleCheckBoxColumn = AddVisibleCheckBoxColumnForCheckedItems(webGrid, checkBoxValue, defaultCheckedState);

            var newInvisibleCheckBoxColumn = AddInvisibleCheckboxColumnForUncheckedItems(webGrid, checkBoxValue, !defaultCheckedState);

            var newColumns = AddColumnsToGrid(columns, checkBoxColumnPosition, newVisibleCheckBoxColumn, newInvisibleCheckBoxColumn);

            var script = @"<script type=""text/javascript"">
                $(document).ready(function(){
                    $('.grid td:nth-child(' + " + checkBoxColumnPosition + 2 + @" + '),th:nth-child( ' + " + checkBoxColumnPosition + 2 + @" + ')').hide();
                    $('#allCheckBox').click(function () {
                        var isChecked = $(this).attr('checked');
                        if (isChecked){
                            $('.singleHiddenCheckBox').attr('checked', 'checked');
                        }
                        else{
                            $('.singleHiddenCheckBox').removeAttr('checked');
                        }
                        if (isChecked){
                            $('.singleCheckBox').removeAttr('checked');
                        }
                        else{
                            $('.singleCheckBox').attr('checked', 'checked');
                        }
                        $('.singleCheckBox').closest('tr').addClass(isChecked  ? 'selected-row': 'not-selected-row');
                        $('.singleCheckBox').closest('tr').removeClass(isChecked  ? 'not-selected-row': 'selected-row');
                    });
                    $('.singleCheckBox').click(function () {
                        var isChecked = $(this).attr('checked');
                        var id = $(this).attr('value');
                        if (isChecked){
                            $('#unChecked' + id).removeAttr('checked');
                        }
                        else{
                            $('#unChecked' + id).attr('checked', 'checked');
                        }
                        $(this).closest('tr').addClass(isChecked  ? 'selected-row': 'not-selected-row');
                        $(this).closest('tr').removeClass(isChecked  ? 'not-selected-row': 'selected-row');
                        if(isChecked && $('.singleCheckBox').length == $('.selected-row').length)
                                $('#allCheckBox').attr('checked','checked');
                        else
                            $('#allCheckBox').removeAttr('checked');
                    });
                });
            </script>";

            var html = string.Format("{0}{1}{2}", script, Environment.NewLine, webGrid.GetHtml(tableStyle, headerStyle, footerStyle, rowStyle, alternatingRowStyle, selectedRowStyle, caption, displayHeader, fillEmptyRows, emptyRowCellValue, newColumns, exclusions, mode, firstText, previousText, nextText, lastText, numericLinksCount, htmlAttributes));
            return MvcHtmlString.Create(html.ToString().Replace("{}", "<input type=\"checkbox\" id=\"allCheckBox\" " + (defaultCheckedState ? "checked=\"checked\" " : string.Empty) + "/>") + (helper == null ? script : string.Empty));
        }

        private static List<WebGridColumn> AddColumnsToGrid(IEnumerable<WebGridColumn> columns, int checkBoxColumnPosition, WebGridColumn newVisibleCheckBoxColumn, WebGridColumn newInvisibleCheckBoxColumn)
        {
            var newColumns = columns.ToList();
            newColumns.Insert(checkBoxColumnPosition, newVisibleCheckBoxColumn);
            newColumns.Insert(checkBoxColumnPosition + 1, newInvisibleCheckBoxColumn);
            return newColumns;
        }

        private static WebGridColumn AddInvisibleCheckboxColumnForUncheckedItems(WebGrid webGrid, string checkBoxValue, bool defaultCheckedState)
        {
            var newInvisibleCheckBoxColumn = webGrid.Column(header: "",
            format: item => new HelperResult(writer =>
            {
                var id = item.Value.GetType().GetProperty(checkBoxValue).GetValue(item.Value, null).ToString();
                writer.Write("<input class=\"singleHiddenCheckBox\" name=\"unSelectedRows\" value=\"" + id + "\" id=\"unChecked" + id + "\" type=\"checkbox\" " + (defaultCheckedState ? "checked=\"checked\"" : string.Empty) + " />");
            }), style: "invisiblecolumn");
            return newInvisibleCheckBoxColumn;
        }

        private static WebGridColumn AddVisibleCheckBoxColumnForCheckedItems(WebGrid webGrid, string checkBoxValue, bool defaultCheckedState)
        {
            var newVisibleCheckBoxColumn = webGrid.Column(header: "{}",// This header will be replaced by checkbox
            format: item => new HelperResult(writer =>
            {
                var id = item.Value.GetType().GetProperty(checkBoxValue).GetValue(item.Value, null).ToString();
                writer.Write("<input class=\"singleCheckBox\" name=\"selectedRows\" value=\"" + id + "\" id=\"checked" + id + "\" type=\"checkbox\" " + (defaultCheckedState ? "checked=\"checked\"" : string.Empty) + "\" />");
            }));
            return newVisibleCheckBoxColumn;
        }
    }

}
