using System;
using System.Collections.Generic;
using System.Linq;
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
            throw new NotImplementedException();
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
