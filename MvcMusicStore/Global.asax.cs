using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using MvcMusicStore.Controllers;
using NLog;
using PerformanceCounterHelper;
using MvcMusicStore.Infrastructure;

namespace MvcMusicStore
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            ResolveDependencies();

            IncrementStartAppCounter();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private static void IncrementStartAppCounter()
        {
            var counterHelper = PerformanceHelper.CreateCounterHelper<PerformanceCounters>("Test counters");
            counterHelper.RawValue(PerformanceCounters.StartApplication, 0);
            counterHelper.RawValue(PerformanceCounters.SuccessLogIn, 0);
            counterHelper.RawValue(PerformanceCounters.SuccessLogOf, 0);
            counterHelper.Increment(PerformanceCounters.StartApplication);
        }

        private static void ResolveDependencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(HomeController).Assembly);
            builder.Register(logger => LogManager.GetLogger("Logger for controllers")).As<ILogger>();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }
    }
}
