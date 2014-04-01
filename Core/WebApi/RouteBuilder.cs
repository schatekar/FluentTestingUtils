using System.Web.Http;
using System.Web.Http.Routing;

namespace Core.WebApi
{
    public class RouteBuilder
    {
        private readonly string routeName;
        private readonly string routeValue;
        private readonly HttpRouteValueDictionary routeDataCollection = new HttpRouteValueDictionary();

        public RouteBuilder(string routeName, string routeValue)
        {
            this.routeName = routeName;
            this.routeValue = routeValue;
        }

        public RouteBuilder HavingRouteData(string name, string value)
        {
            routeDataCollection.Add(name, value);
            return this;
        }

        public IHttpRouteData BuildFor(HttpConfiguration config)
        {
            var route = config.Routes.MapHttpRoute(routeName, routeValue);
            return new HttpRouteData(route, routeDataCollection);
        }
    }
}