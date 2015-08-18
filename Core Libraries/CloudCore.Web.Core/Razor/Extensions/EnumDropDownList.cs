using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace CloudCore.Web.Core.Razor.Extensions
{
    public static class EnumDropDownLists
    {
        internal static Type GetNonNullableModelType(ModelMetadata modelMetadata)
        {
            Type realModelType = modelMetadata.ModelType;

            Type underlyingType = Nullable.GetUnderlyingType(realModelType);
            if (underlyingType != null)
            {
                realModelType = underlyingType;
            }
            return realModelType;
        }

        internal static readonly SelectListItem[] SingleEmptyItem = new[] { new SelectListItem { Text = "", Value = "" } };

        internal static string GetEnumDescription<TEnum>(TEnum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            var attributes = fi.GetCustomAttributes(typeof (DescriptionAttribute), false) as DescriptionAttribute[];

            if ((attributes != null) && (attributes.Length > 0))
                return attributes[0].Description;

            return value.ToString();
        }

        /// <summary>
        /// Creates the necessary inline HTML that generates a EnumDropDownList control bound to the specified form field.
        /// </summary>
        /// <typeparam name="TModel">The model type</typeparam>
        /// <typeparam name="TEnum">The Enum type</typeparam>
        /// <param name="htmlHelper">The Html Helper</param>
        /// <param name="expression">The expression that evaluates to the model property</param>
        /// <returns>A MvcHtmlString that can be used inline wherever the EnumDropDownList control needs to be placed</returns>
        public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression)
        {
            return EnumDropDownListFor(htmlHelper, expression, true, null);
        }

        /// <summary>
        /// Creates the necessary inline HTML that generates a EnumDropDownList control bound to the specified form field.
        /// </summary>
        /// <typeparam name="TModel">The model type</typeparam>
        /// <typeparam name="TEnum">The Enum type</typeparam>
        /// <param name="htmlHelper">The Html Helper</param>
        /// <param name="expression">The expression that evaluates to the model property</param>
        /// <param name="useEnumValue">Specifies whether or not to use the enum value for the SelectListItem's value. If false, the string representation of the enum instance will be used instead.</param>
        /// <returns>A MvcHtmlString that can be used inline wherever the EnumDropDownList control needs to be placed</returns>
        public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression, bool useEnumValue)
        {
            return EnumDropDownListFor(htmlHelper, expression, useEnumValue, null);
        }

        /// <summary>
        /// Creates the necessary inline HTML that generates a EnumDropDownList control bound to the specified form field.
        /// </summary>
        /// <typeparam name="TModel">The model type</typeparam>
        /// <typeparam name="TEnum">The Enum type</typeparam>
        /// <param name="htmlHelper">The Html Helper</param>
        /// <param name="expression">The expression that evaluates to the model property</param>
        /// <param name="useEnumValue">Specifies whether or not to use the enum value for the SelectListItem's value. If false, the string representation of the enum instance will be used instead.</param>
        /// <param name="htmlAttributes">Any HTML attributes you want to apply to the control</param>
        /// <returns>A MvcHtmlString that can be used inline wherever the EnumDropDownList control needs to be placed</returns>
        public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression, bool useEnumValue, object htmlAttributes)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            Type enumType = GetNonNullableModelType(metadata);

            IEnumerable<TEnum> values = null;

            try
            {
                values = Enum.GetValues(enumType).Cast<TEnum>();
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("The model type contained in the expression parameter is not an Enum type.", ex);
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

            // If the enum is nullable, add an 'empty' item to the collection
            if (metadata.IsNullableValueType)
                items = SingleEmptyItem.Concat(items);

            return htmlHelper.DropDownListFor(expression, items, htmlAttributes);
        }
    }
}
