using System;
using System.Web.Http;

namespace Core.WebApi
{
    public class ControllerBuilder<T> : ControllerConfigurator<T> 
        where T: ApiController, new() 
    {
        public ControllerBuilder() : base(new T())
        {
            
        }
        
        public T Having(Action<ControllerBuilder<T>> builder)
        {
            builder(this);
            return Build();
        }
    }
}