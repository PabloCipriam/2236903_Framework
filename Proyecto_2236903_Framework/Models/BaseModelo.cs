using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Proyecto_2236903_Framework.Models
{
    public class BaseModelo
    {
        public int ActualPage { get; set; }
        public int Total { get; set; }
        public int RecordsPage { get; set; }
        public RouteValueDictionary valueQueryString { get; set; }
    }
}