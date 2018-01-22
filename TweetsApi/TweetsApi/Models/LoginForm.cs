using System.Runtime.Serialization;

namespace TweetsApi.Models
{
    [DataContract]
    public class LoginForm
    {
        [DataMember(Name = "login")]
        public string Login { get; set; }

        [DataMember(Name = "password")]
        public string Password { get; set; }

        public LoginForm(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
