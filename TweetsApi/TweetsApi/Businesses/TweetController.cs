using System;
using System.Collections.Generic;
using System.Net;
using TweetsApi.Models;
using TweetsApi.WebClientExtends;

namespace TweetsApi.Businesses
{
    public class TweetController
    {
        public static string RootUrl = "https://salty-mesa-4348.herokuapp.com/";

        public string Cookie { get; set; }

        private readonly HttpWebRequestFactory httpWebRequestFactory;

        public TweetController()
        {
            httpWebRequestFactory = HttpWebRequestFactory.ForRoot(RootUrl);
        }

        public void Login(string login, string password)
        {
            var httpRequest = httpWebRequestFactory.CreateRequest("login", "POST");

            httpRequest.WriteJsonObject(new LoginForm(login, password));

            try
            {
                Cookie = httpRequest.GetWebResponse()
                    .GetResponseHeader("Set-Cookie");
            }
            catch (WebException ex)
            {
                switch (((HttpWebResponse)ex.Response).StatusCode)
                {
                    case HttpStatusCode.Unauthorized:
                        throw new Exception("Wrong username/password");
                    default:
                        throw;
                }
            }
        }

        public List<TweetModel> GetTweets()
        {
            if (string.IsNullOrEmpty(Cookie))
            {
                throw new Exception("Need to login first");
            }

            var httpRequest = httpWebRequestFactory.CreateRequest("tweets", "GET");
            httpRequest.SetHeader("Cookie", Cookie);
            return httpRequest.GetWebResponse().GetResponseData<List<TweetModel>>();
        }

        public void Logout()
        {
            if (string.IsNullOrEmpty(Cookie))
            {
                throw new Exception("Need to login first");
            }

            var httpRequest = httpWebRequestFactory.CreateRequest("logout", "DELETE");
            httpRequest.SetHeader("Cookie", Cookie);
            httpRequest.GetWebResponse();
        }
    }
}
