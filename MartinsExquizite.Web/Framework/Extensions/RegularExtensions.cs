using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace MartinsExquizite.Web.Framework.Extensions
{
    public static class RegularExtensions
    {
        private static string illegalCharacterReplacementPattern = @"[^\w]";

        public static string SanitizeString(this string str)
        {
            string sanitizedString = string.Empty;
            if (!string.IsNullOrEmpty(str))
            {
                sanitizedString = Regex.Replace(str.Trim(), illegalCharacterReplacementPattern, "-");
                sanitizedString = sanitizedString.Replace("---", "-").Replace("--", "-");
                sanitizedString = sanitizedString.TrimStart('-').TrimEnd('-');
            }

            return sanitizedString;
        }

        public static string SanitizeLowerString(this string str)
        {
            return str.SanitizeString().ToLower();
        }

    }
}