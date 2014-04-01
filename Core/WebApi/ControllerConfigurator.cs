using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;

namespace Core.WebApi
{
    public class ControllerConfigurator<T> where T: ApiController
    {
        private readonly T controller;

        public ControllerConfigurator(T controller)
        {
            this.controller = controller;
        }

        private RequestBuilder requestBuilder;
        private RouteBuilder routeBuilder;

        public RequestBuilder PostRequest()
        {
            requestBuilder = new RequestBuilder(HttpMethod.Post);
            return requestBuilder;
        }

        public RouteBuilder UsingRoute(string name, string value)
        {
            routeBuilder = new RouteBuilder(name, value);
            return routeBuilder;
        }

        public RouteBuilder UsingDefaultRoute()
        {
            return UsingRoute("DefaultApi", "api/{controller}/{id}");
        }

        public void AsHaving(Action<ControllerConfigurator<T>> builder)
        {
            builder(this);
            Build();
        }

        protected T Build()
        {
            var configuration = new HttpConfiguration();
            var routeData = routeBuilder.BuildFor(configuration);
            var request = requestBuilder.Build();

            controller.ControllerContext = new HttpControllerContext(configuration, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = configuration;

            return controller;
        }
    }
}