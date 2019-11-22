using System.Web.Mvc;

namespace MartinsExquizite.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin",
                "Admin",
                new { controller="Admin", action = "Index", id = UrlParameter.Optional }
            );




            context.MapRoute(
                "EntityList",
                "Dashboard/{controller}/",
                new { action = "Index" }
                );



            context.MapRoute(
                "EntityDelete",
                "Dashboard/{controller}/Delete",
                new { action = "Delete" }
                );


        }
    }
}