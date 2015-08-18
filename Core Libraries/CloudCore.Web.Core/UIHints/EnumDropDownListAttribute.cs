using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using CloudCore.Web.Core.Razor.Extensions;

namespace CloudCore.Web.Core.UIHints
{
    public class EnumDropDownListAttribute : UIHintAttribute
    {
        private static bool useEnumValue = true;

        /// <summary>
        /// Causes the model property to use the EnumDropDownList control to render the editor field on the web page form when using an editor (template). The enum values will be used for the value field of all the SelectListItems.
        /// </summary>
        public EnumDropDownListAttribute() : base("EnumDropDownList") { }

        /// <summary>
        /// Causes the model property to use the EnumDropDownList control to render the editor field on the web page form when using an editor (template).
        /// </summary>
        /// <param name="useEnumValues">Specifies whether or not to use the enum value for the SelectListItem's value. If false, the string representation of the enum instance will be used instead.</param>
        public EnumDropDownListAttribute(bool useEnumValues)
            : base("EnumDropDownList")
        {
            useEnumValue = useEnumValues;
        }

        /// <summary>
        /// Returns an IEnumerable of SelectListItem using the values of an Enum type of the model metadata contained in the viewData parameter.
        /// </summary>
        /// <param name="viewData"></param>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> GetItemsFromTypeMetaData(ViewDataDictionary<object> viewData)
        {
            ModelMetadata metadata = viewData.ModelMetadata;
            Type enumType = EnumDropDownLists.GetNonNullableModelType(metadata);

            IEnumerable<dynamic> values;

            try
            {
                values = Enum.GetValues(enumType).Cast<dynamic>();
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(@"The model type contained in the viewData parameter is not an Enum type.", ex);
            }

            IEnumerable<SelectListItem> items;

            //string[] names = Enum.GetNames(enumType);

            items = from value in values
                    select new SelectListItem
                    {
                        Text = EnumDropDownLists.GetEnumDescription(value),
                        Value = useEnumValue ? value.ToString() : EnumDropDownLists.GetEnumDescription(value),
                        Selected = value.Equals(metadata.Model)
                    };

            if (metadata.IsNullableValueType)
            {
                items = EnumDropDownLists.SingleEmptyItem.Concat(items);
            }

            return items;
        }
    }
}
