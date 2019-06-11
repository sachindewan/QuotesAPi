using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesApi.CustomConstraints
{

    public class OnlyGodsConstraint : IRouteConstraint
    {
        private string[] gods = new[] { "Ram", "Shiv", "Krishn", "Vishnu", "Brahma", "Lakshmi" };
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            //return gods.Contains(values[routeKey]);
            return values[routeKey] is string;
        }
    }
}
