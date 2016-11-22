using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc4.Components;
using System.ComponentModel.Composition.Primitives;

namespace Mvc4.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class HomeController : Controller
    {
        private ILogger _logger;

        public HomeController()
        {
            IControllerFactory factory = ControllerBuilder.Current.GetControllerFactory();
        }

        [ImportingConstructor]
        public HomeController(ILogger logger)
        {
            _logger = logger;
            IControllerFactory factory = ControllerBuilder.Current.GetControllerFactory();
        }
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            return View();
        }
        void RaiseException()
        {
            throw new MissingMethodException("Method is missed");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}
