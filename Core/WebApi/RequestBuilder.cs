using System.Net.Http;

namespace Core.WebApi
{
    public class RequestBuilder
    {
        private readonly HttpMethod httpMethod;
        private string requestUrl;

        public RequestBuilder(HttpMethod httpMethod)
        {
            this.httpMethod = httpMethod;
        }

        public RequestBuilder At(string url)
        {
            requestUrl = url;
            return this;
        }

        public HttpRequestMessage Build()
        {
            return new HttpRequestMessage(httpMethod, requestUrl);
        }
    }
}