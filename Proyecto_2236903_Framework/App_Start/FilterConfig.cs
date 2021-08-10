using System.Web;
using System.Web.Mvc;

namespace Proyecto_2236903_Framework
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
