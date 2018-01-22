using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using Newtonsoft.Json;
using TweetsApi.Businesses;
using TweetsApi.Models;
using TweetsApi.WebClientExtends;

namespace TweetsApi
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            var controller = new TweetController();
            controller.Login("foo", "bar");
            var tweets = controller.GetTweets();
            controller.Logout();
        }
    }
}
