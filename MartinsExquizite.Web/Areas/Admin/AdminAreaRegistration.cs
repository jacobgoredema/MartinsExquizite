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
                new
                {
                    controller = "Admin",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );

            context.MapRoute(
                "UnAuthorized",
                "UnAuthorized",
                new { controller = "Base", action = "UnAuthorized" }
            );

            context.MapRoute(
                "EntityList",
                "Admin/{controller}/",
                new { action = "Index" }
            );

            context.MapRoute(
                "EntityCreate",
                "Admin/{controller}/Create/",
                new { action = "Action" }
            );

            context.MapRoute(
                "EntityEdit",
                "Admin/{controller}/Edit/{id}",
                new { action = "Action" }
            );

            context.MapRoute(
                "EntityEditWithoutID",
                "Admin/{controller}/Edit/",
                new { action = "Action" }
            );

            context.MapRoute(
                "EntityDetails",
                "Dashboard/{controller}/Details/{id}",
                new { action = "Details" }
            );

            context.MapRoute(
                "EntityDelete",
                "Admin/{controller}/Delete/",
                new { action = "Delete" }
            );

            context.MapRoute(
                name: "UserDetails",
                url: "Admin/Users/UserDetails/{userID}",
                defaults: new { controller = "Users", action = "UserDetails" }
            );

            context.MapRoute(
                name: "UserRoles",
                url: "Admin/Users/UserRoles/{userID}",
                defaults: new { controller = "Roles", action = "UserRoles" }
            );

            context.MapRoute(
                name: "RoleDetails",
                url: "Admin/Roles/RoleDetails/{roleID}",
                defaults: new { controller = "Roles", action = "RoleDetails" }
            );

            context.MapRoute(
                name: "RoleUsers",
                url: "Dashboard/Roles/RoleUsers/{roleID}",
                defaults: new { controller = "Roles", action = "RoleUsers" }
            );

            context.MapRoute(
                name: "AssignUserRole",
                url: "Admin/Roles/UserRole/{userID}/Assign/",
                defaults: new { controller = "Roles", action = "AssignUserRole" }
            );

            context.MapRoute(
                name: "DeleteUserRole",
                url: "Admin/Roles/UserRole/{userID}/Delete/",
                defaults: new { controller = "Roles", action = "DeleteUserRole" }
            );

            context.MapRoute(
                name: "OrdersByEmail",
                url: "Admin/Orders/OrdersByEmail",
                defaults: new { controller = "Orders", action = "OrdersByEmail" }
            );

            context.MapRoute(
                name: "UpdateOrderStatus",
                url: "Admin/Orders/{orderID}/Update-Status/",
                defaults: new { controller = "Orders", action = "UpdateStatus" }
            );

            context.MapRoute(
                "Admin_Default",
                "Admin/{controller}/{action}/{id}",
                new
                {
                    controller = "Dashboard",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
        }
    }
}