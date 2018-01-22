using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace TweetsApi.WebClientExtends
{
    public static class HttpWebRequestExtends
    {
        public static HttpWebRequest WriteJsonObject(this HttpWebRequest httpWebRequest, object obj)
        {
            using (var stream = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                stream.Write(JsonConvert.SerializeObject(obj));
            }
            return httpWebRequest;
        }

        public static void SetHeader(this HttpWebRequest httpWebRequest, string name, string value)
        {
            httpWebRequest.Headers[name] = value;
        }

        public static HttpWebResponse GetWebResponse(this HttpWebRequest httpWebRequest)
        {
            return httpWebRequest.GetResponse() as HttpWebResponse;
        }
    }
}
