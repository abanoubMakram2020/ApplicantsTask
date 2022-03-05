using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;

namespace SharedKernal.Common
{
    /// <summary>
    /// Generic extension methods.
    /// </summary>
    public static class ExtensionMethods
    {

        /// <summary>
        /// To get enum string value
        /// </summary>
        /// <param name="value"></param>
        /// <returns>string</returns>
        public static EnumMessage GetDescription(this System.Enum value)
        {
            EnumMessage descriptionAttribute = (EnumMessage)value.GetType().GetField(value.ToString()).GetCustomAttributes(false).Where(a => a is EnumMessage).FirstOrDefault();
            return descriptionAttribute != null ? descriptionAttribute : new EnumMessage(value.ToString());
        }

        /// <summary>
        /// Validate the value with given regex pattern.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="pattern"></param>
        /// <returns>true, if match. Otherwize, false</returns>
        public static bool ValidateRegex(this string value, string pattern)
        {
            return new Regex(pattern).IsMatch(value);
        }

        /// <summary>
        /// Remove the text WhiteSpace
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Clear the text with no whitespace</returns>
        public static string RemoveWhiteSpace(this string text)
        {
            string[] spaceDecimals = ("9,10,11,13,32,115,133,160,5760,8192,8193,8194,8195,8196,8197,8198,8199,8200,8201,8202,8203,8204,8205,8230,8232,8233,8236,8237,8239,8287,12288,6158,8288,65279").Split(',');
            List<int> spaceUnicodes = new List<int>(spaceDecimals.Length);
            List<Regex> rejSpace = new List<Regex>(spaceDecimals.Length);
            spaceDecimals.ToList().ForEach(code => spaceUnicodes.Add(int.Parse(code)));
            spaceUnicodes.ForEach(code => rejSpace.Add(new Regex(Convert.ToString(Convert.ToChar(code)))));
            rejSpace.ForEach(rejex => rejex.Replace(text, string.Empty).Replace("?", string.Empty));
            return text.Trim();
        }

        /// <summary>
        /// Remove the text WhiteSpace
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Clear the text with no emoji</returns>
        public static string DetectEmoji(this string text)
        {
            // Emoji Regex.
            Regex rgx = new Regex(@"\uD83D[\uDC00-\uDFFF]|\uD83C[\uDC00-\uDFFF]|\uFFFD");
            return rgx.IsMatch(text) ? Regex.Replace(text, rgx.ToString(), string.Empty) : text;
        }

        /// <summary>
        /// //TODO
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="predicate"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> queryable, Func<bool> predicate, System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = queryable;
            if (predicate())
                query = queryable.Where(filter);
            return query;
        }
    }
}
