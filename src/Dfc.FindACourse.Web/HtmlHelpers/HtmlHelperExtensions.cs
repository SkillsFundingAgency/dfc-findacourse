using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dfc.FindACourse.Web.HtmlHelpers
{
    public static class HtmlHelperExtensions
    {
        public static SelectListItem GetEnumSelectListItem<TModel, TEnum>(this IHtmlHelper<TModel> htmlHelper, TEnum item) 
            where TModel : class 
            where TEnum : struct 
        {
            if (!typeof(TEnum).IsEnum)
                throw new ArgumentException("Not an enum.", nameof(TEnum));
            if (!item.GetType().IsEnum)
                throw new ArgumentException("Not an enum.", nameof(item));
            if (typeof(TEnum) != item.GetType())
                throw new ArgumentException($"Type {typeof(TEnum)} does not match type {item.GetType()}.");
            if (!Enum.IsDefined(typeof(TEnum), item))
                throw new ArgumentException($"{item} is not defined in {typeof(TEnum)}.", nameof(item));

            var enumValue = Enum.Parse(typeof(TEnum), item.ToString(), false);
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
            var text = enumValue.ToString();

            if (fieldInfo.GetCustomAttributes(typeof(DisplayAttribute), false) is DisplayAttribute[] descriptionAttributes && descriptionAttributes.Length > 0)
            {
                text = descriptionAttributes[0].Name;
            }

            Enum.TryParse(enumValue.GetType(), enumValue.ToString(), out object value);

            var sli = new SelectListItem((new HtmlString(text)).ToString(), ((int)value).ToString());

            return sli;
        }
    }
}
