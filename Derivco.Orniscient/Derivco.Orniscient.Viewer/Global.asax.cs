﻿using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Derivco.Orniscient.Viewer.Observers;
using Orleans;

namespace Derivco.Orniscient.Viewer
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GrainClient.Initialize(Server.MapPath("~/DevTestClientConfiguration.xml"));
            OrniscientObserver.Instance.SetTypeFilter(p => p.Contains("TestHost.Grains")).Wait();
        }
    }
}
