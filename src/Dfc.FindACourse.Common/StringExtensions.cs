using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dfc.FindACourse.Common
{
    public static class StringExtensions
    {
        public static string ToSentenceCase(this string extendee, string delimiter = " ")
        {
            if (string.IsNullOrEmpty(extendee))
                return extendee;

            var split = extendee.Split(delimiter);
            var list = new List<string>();

            foreach (var item in split)
            {
                list.Add(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(item.ToLower()));
            }

            return string.Join(delimiter, list);
        }
    }
}
