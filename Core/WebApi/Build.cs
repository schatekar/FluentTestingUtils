using System.Web.Http;

namespace Core.WebApi
{
    public static class Build
    {
        public static ControllerBuilder<T> Controller<T>() where T : ApiController, new()
        {
            return new ControllerBuilder<T>();
        }
    }
}