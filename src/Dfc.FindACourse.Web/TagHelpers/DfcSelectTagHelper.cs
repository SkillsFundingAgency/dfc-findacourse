using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dfc.FindACourse.Web.TagHelpers
{
    [HtmlTargetElement("dfc-select")]
    public class DfcSelectTagHelper : TagHelper
    {
        public IEnumerable<SelectListItem> DfcItems { get; set; }
        public SelectListItem DfcSelectedItem { get; set; }
        public IEnumerable<Enum> DfcIgnoredItemValues { get; set; }

        public DfcSelectTagHelper()
        {
            DfcItems = new List<SelectListItem>();
            DfcIgnoredItemValues = new List<Enum>();
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "select";
            output.TagMode = TagMode.StartTagAndEndTag;

            var modifiedItems = SetSelected(DfcItems, DfcSelectedItem);
            modifiedItems = RemoveIgnored(modifiedItems, ToStrings(DfcIgnoredItemValues));

            var html = string.Empty;

            if (modifiedItems.Any())
            {
                html = ToHtmlOptionElements(modifiedItems);
            }

            output.PostContent.SetHtmlContent(html);
        }

        internal IEnumerable<SelectListItem> SetSelected(IEnumerable<SelectListItem> items, SelectListItem selected)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            if (!items.Any() || selected == null)
                return items;

            var modifiedItems = new List<SelectListItem>();

            foreach (var item in items)
            {
                item.Selected = item.Value == selected.Value;
                modifiedItems.Add(item);
            }

            return modifiedItems.AsEnumerable();
        }

        internal IEnumerable<SelectListItem> RemoveIgnored(IEnumerable<SelectListItem> items, IEnumerable<string> ignored)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));
            if (ignored == null)
                throw new ArgumentNullException(nameof(ignored));

            if (!items.Any() || !ignored.Any())
                return items;

            var modifiedItems = new List<SelectListItem>();

            foreach (var item in items)
            {
                if (!ignored.Any(x => x.ToString() == item.Value))
                {
                    modifiedItems.Add(item);
                }
            }

            return modifiedItems.AsEnumerable();
        }

        internal IEnumerable<string> ToStrings(IEnumerable<Enum> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            if (!items.Any())
                return (new string[] { }).AsEnumerable();

            var list = new List<string>();

            foreach (var item in items)
            {
                Enum.TryParse(item.GetType(), item.ToString(), out object value);

                list.Add(((int)value).ToString());
            }

            return list.AsEnumerable();
        }

        internal string ToHtmlOptionElement(SelectListItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            var selected = string.Empty;

            if (item.Selected)
                selected = " selected=\"selected\"";

            var html = $"<option value=\"{item.Value}\"{selected}>{item.Text}</option>";

            return html;
        }

        internal string ToHtmlOptionElements(IEnumerable<SelectListItem> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            if (!items.Any())
                return string.Empty;

            var sb = new StringBuilder();

            foreach (var item in items)
            {
                sb.Append(ToHtmlOptionElement(item));
            }

            return sb.ToString(); ;
        }
    }
}
