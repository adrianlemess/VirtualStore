﻿using System.Web.Mvc;
using System.Web.Routing;

namespace LojaVirtual
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "AdItem", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}