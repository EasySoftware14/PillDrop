using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FluentValidation.Mvc;
using log4net;
using Microsoft.Owin.Builder;
using NHibernate.Burrow;
using Owin;
using StructureMap;

namespace PillDropApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        internal static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        internal static readonly IAppBuilder Builder = new AppBuilder();

        static void ConfigureApplication(HttpConfiguration config)
        {
            config.DependencyResolver = new StructureMapResolver(ObjectFactory.Container);
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            log4net.Config.XmlConfigurator.Configure();
            StructureMapBootStrapper.Bootstrap();
            ConfigureApplication(GlobalConfiguration.Configuration);
            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());
            FluentValidationModelValidatorProvider.Configure();

            //var templateBundle = new DynamicFolderBundle("htm", "*.htm", true);
            //var context = new BundleContext(new HttpContextWrapper(Context), new BundleCollection(), "~/Views/Templates/htm");
            //templateBundle.EnumerateFiles(context);
            //BundleTable.Bundles.Add(templateBundle);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            new BurrowFramework().InitWorkSpace();
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            ObjectFactory.ReleaseAndDisposeAllHttpScopedObjects();
        }
    }
}
