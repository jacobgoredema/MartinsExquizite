using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MartinsExquizite.Web
{
    public static class PictureHelper
    {



        public static string PictureSource(this HtmlHelper htmlHelper,string pictureUrl)
        {
            return string.Format("/content/images/{0}{1}", pictureUrl);
        }
    }
}