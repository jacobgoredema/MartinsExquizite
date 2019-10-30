using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MartinsExquizite.Web
{
    public static class DashBoardUrlHelper
    {
        public static string Dashboard(this UrlHelper helper)
        {
            string routeUrl = string.Empty;
            routeUrl = helper.RouteUrl("Dashboard");
            routeUrl = HttpUtility.UrlDecode(routeUrl, System.Text.Encoding.UTF8);

            return routeUrl.ToLower();
        }

        public static string ListAction(this UrlHelper helper,string controller, string searchTerm="",int? pageNo=0)
        {
            string routeUrl = string.Empty;
            var routeValues = new RouteValueDictionary();
            routeValues.Add("Controller", controller);

            if (!string.IsNullOrEmpty(searchTerm))
            {
                routeValues.Add("searchTerm", searchTerm);
            }

            if(pageNo.HasValue&&pageNo.Value>1)
            {
                routeValues.Add("pageNo", pageNo.Value);
            }

            routeUrl = helper.RouteUrl("EntityList", routeValues);
            routeUrl = HttpUtility.UrlDecode(routeUrl, System.Text.Encoding.UTF8);

            return routeUrl.ToLower();
        }

        public static string EditAction(this UrlHelper helper, string controller,object Id)
        {
            string routeUrl = string.Empty;

            routeUrl = helper.RouteUrl("EntityEdit", new
            {
                controller = controller,
                Id = Id
            });

            routeUrl = HttpUtility.UrlDecode(routeUrl, System.Text.Encoding.UTF8);

            return routeUrl.ToLower();
        }

        public static string Projects(this UrlHelper helper,string searchTerm="",int? pageNo=0,int? categoryId=0)
        {
            string routeUrl = string.Empty;
            var routeValues = new RouteValueDictionary();

            routeValues.Add("Controller", "Projects");

            if (!string.IsNullOrEmpty(searchTerm))
            {
                routeValues.Add("searchTerm", searchTerm);
            }

            if (categoryId.HasValue&&categoryId.Value>0)
            {
                routeValues.Add("CategoryId", categoryId.Value);
            }

            if (pageNo.HasValue&&pageNo.Value>1)
            {
                routeValues.Add("pageNo", pageNo.Value);
            }

            routeUrl = helper.RouteUrl("Entity", routeValues);
            routeUrl = HttpUtility.UrlDecode(routeUrl, System.Text.Encoding.UTF8);

            return routeUrl.ToLower();
        }

        public static string DeleteAction(this UrlHelper helper, string controller)
        {
            string routeUrl = string.Empty;
            routeUrl = helper.RouteUrl("EntityDelete", new
            {
                controller = controller
            });

            routeUrl = HttpUtility.UrlDecode(routeUrl, System.Text.Encoding.UTF8);

            return routeUrl.ToLower();
        }


    }
}