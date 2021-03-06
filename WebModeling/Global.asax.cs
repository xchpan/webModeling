﻿using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebModeling;
using WebModeling.Cache;
using xpan.plantDesign.WebApi.Config;

namespace xpan.plantDesign.WebHost
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            HttpConfiguration config = GlobalConfiguration.Configuration;
            config.MapHttpAttributeRoutes();
            RouteConfig.RegisterRoutes(config.Routes);
            WebApiConfig.Configure(config);
            AutofacWebApi.Initialize(config);

            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            MvcRouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            config.EnsureInitialized();

            //config.MessageHandlers.Insert(0, new HttpCachingHandler("Accept", "Accept-Charset"));
        }
    }
}