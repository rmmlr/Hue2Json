using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Hue2Json.HtmlConverter
{
    public static class HtmlExtensions
    {
        #region Member


        #endregion Member

        #region Properties


        #endregion Properties

        #region Services

        /// <summary>
        /// Serialisierung aller Properties ins HTML Format
        /// </summary>
        public static string ToHtml(this object obj, HtmlOutputFormat format)
        {
            string surroundingTag;
            string innerTag = "li";
            var innerHtml = new StringBuilder();

            switch (format)
            {
                case HtmlOutputFormat.SortedList:
                    surroundingTag = "ol";
                    break;
                case HtmlOutputFormat.UnsortetList:
                    surroundingTag = "ul";
                    break;
                default:
                    surroundingTag = null;
                    break;
            }

            Type t = obj.GetType();
            // Get the public properties.
            PropertyInfo[] propInfos = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var cnt = propInfos.Length;


            // Display information for all properties.
            foreach (var propInfo in propInfos)
            {
                var value = t.GetProperty(propInfo.Name).GetValue(obj, null);
                innerHtml.AppendFormat("<{0}>{1}: {2}</{0}>\n", innerTag, propInfo.Name, value);
            }


            return String.Format("<{0}>{1}</{0}>", surroundingTag, innerHtml);
        }

        #endregion Services

        #region Internal services


        #endregion Internal services

        #region Events


        #endregion Events
    }

    public enum HtmlOutputFormat
    {
        SortedList,
        UnsortetList,
    }
}
