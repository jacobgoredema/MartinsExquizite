using MartinsExquizite.Web.Framework.Helpers;
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

    /// <summary>
    /// http://jasonwatmore.com/post/2015/10/30/aspnet-mvc-pagination-example-with-logic-like-google
    /// </summary>
    public class Pager
    {
        public Pager(int totalItems,int? page, int pageSize=10)
        {
            if (pageSize == 0)
                pageSize = ConfigurationsHelper.DashboardRecordsSizePerPage;

            var totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            var currentPage = page != null ? (int)page : 1;
            var startPage = currentPage - 5;
            var endPage = currentPage + 4;

            if (startPage<=0)
            {
                endPage -= (startPage - 1);
                startPage = 1;
            }

            if(endPage>totalPages)
            {
                endPage = totalPages;
                if (endPage>10)
                {
                    startPage = endPage - 9;
                }
            }

            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;
        }

        public int TotalItems { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; set; }
        public int TotalPages { get; private set; }
        public int StartPage { get; set; }
        public int EndPage { get; private set; }
    }
}