using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Georegis.App_Start.HomeConfig), "Start")]

namespace Georegis.App_Start
{

    public class HomeConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // Указываем, что все ресурсы ext.net нужно игнорировать
            routes.IgnoreRoute("{extnet-root}/{extnet-file}/ext.axd");

            //Теперь настраиваем маршрут для контроллера
            routes.MapRoute(
                "Home", // Имя маршрута
                "{controller}/{action}/{id}", // Как будет выглядеть URL
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } //Что вызывать по умолчанию
            );
        }

        public static void Start()
        {
            HomeConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}