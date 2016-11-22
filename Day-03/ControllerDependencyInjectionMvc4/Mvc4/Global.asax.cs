using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Mvc4.Components;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;

namespace Mvc4
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private readonly CompositionContainer _composition;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            //RegisterCustomControllerFactory();
            RegisterMef();

        }

        private void RegisterCustomControllerFactory()
        {
            //IControllerFactory factory = new CustomControllerFactory("Mvc4.Controllers");
            IControllerFactory factory = new CustomControllerFactory();
        }

        private void RegisterMef()
        {
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var composition = new CompositionContainer(catalog);
            IControllerFactory mefControllerFactory = new MefControllerFactory(composition);
            ControllerBuilder.Current.SetControllerFactory(mefControllerFactory);
        }
    }
}