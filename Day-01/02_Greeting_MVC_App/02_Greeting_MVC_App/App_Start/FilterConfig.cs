using System.Web;
using System.Web.Mvc;

namespace _02_Greeting_MVC_App
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}