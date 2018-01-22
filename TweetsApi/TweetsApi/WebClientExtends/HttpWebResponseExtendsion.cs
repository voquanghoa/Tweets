using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace TweetsApi.WebClientExtends
{
    public static class HttpWebResponseExtendsion
    {
        public static string GetHeader(
            this HttpWebResponse httpWebResponse, 
            string headerName)
        {
            return httpWebResponse.Headers[headerName];
        }

        public static T GetResponseData<T>(this HttpWebResponse httpWebResponse)
        {
            using (var stream = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                var responseString = stream.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(responseString);
            }
        }
    }
}
