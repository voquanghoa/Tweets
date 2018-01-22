using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TweetsApi.Models
{
    [DataContract]
    public class TweetModel
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "author")]
        public string Author { get; set; }

        [DataMember(Name = "content")]
        public string Content { get; set; }

        [DataMember(Name = "images")]
        public List<string> Images { get; set; }
    }

}
