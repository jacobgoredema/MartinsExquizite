using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MartinsExquizite.Web.ViewModels
{
    public class PageVm
    {
        public string PageTitle { get; set; }
        public string PageDescription { get; set; }
        public string PageUrl { get; set; }
        public string PageImageUrl { get; set; }

        public List<string> PageCanonicalUrls { get; set; }

        public PageVm()
        {
            PageCanonicalUrls = new List<string>();
        }
    }

    public class Pager
    {

    }
}