using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DOAN_CLOUND
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Route để chấp nhận đuôi .cshtml
            routes.MapRoute(
                name: "WithCshtml",
                url: "{controller}/{action}.cshtml/{id}",
                defaults: new { controller = "Home", action = "Index_User", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index_User", id = UrlParameter.Optional }
            );
          

        }
    }
}
