using System.Net;

namespace TweetsApi.WebClientExtends
{
    public class HttpWebRequestFactory
    {
        private readonly string rootUrl;

        private HttpWebRequestFactory(string rootUrl)
        {
            this.rootUrl = rootUrl;
        }

        public static HttpWebRequestFactory ForRoot(string rootUrl)
        {
            return new HttpWebRequestFactory(rootUrl);
        }

        public HttpWebRequest CreateRequest(string uri, string method)
        {
            var httpRequest = (HttpWebRequest)WebRequest.Create(rootUrl + uri);
            httpRequest.Accept = "application/json";
            httpRequest.ContentType = "application/json";
            httpRequest.Method = method;
            return httpRequest;
        }
    }
}
