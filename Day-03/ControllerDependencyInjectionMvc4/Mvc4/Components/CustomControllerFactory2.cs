//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using System.Web.SessionState;
//using Mvc4.Controllers;

//namespace Mvc4.Components
//{
//    public class CustomControllerFactory : IControllerFactory
//    {
//        private readonly string _controllerNamespace;
//        public CustomControllerFactory(string controllerNamespace)
//        {
//            _controllerNamespace = controllerNamespace;
//        }D:\Projects\VS2012\Mvc4\Mvc4\App_Start\
//        public IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
//        {
//            ILogger logger = new DefaultLogger();
//            Type controllerType = Type.GetType(string.Concat(_controllerNamespace, ".", controllerName, "Controller"));
//            IController controller = Activator.CreateInstance(controllerType, new[] {logger}) as Controller;
//            return controller;
//        }
//        public System.Web.SessionState.SessionStateBehavior GetControllerSessionBehavior(System.Web.Routing.RequestContext requestContext, string controllerName)
//        {
//            return SessionStateBehavior.Default;
//        }
//        public void ReleaseController(IController controller)
//        {
//            //cleanup code
//            IDisposable disposable = controller as IDisposable;
//            if (disposable != null)
//            {
//                disposable.Dispose();
//            }
//        }
//    }
//}