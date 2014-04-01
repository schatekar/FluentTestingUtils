using System.Web.Http;

namespace Core.WebApi
{
    public static class Configure
    {
        public static ControllerConfigurator<T> Controller<T>(T controller) where T : ApiController
        {
            return new ControllerConfigurator<T>(controller);
        }
    }
}