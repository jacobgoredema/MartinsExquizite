using System;

namespace MartinsExquizite.Web.Framework.Helpers
{
    public class StringHelper
    {
        public static string RepaceIgnoringCase(string stringToReplace, string placeholder, object value)
        {
            stringToReplace = stringToReplace.Replace(placeholder, value == null ? string.Empty : value.ToString());

            return stringToReplace;
        }
    }
}