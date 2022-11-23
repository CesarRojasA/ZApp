using Newtonsoft.Json;

namespace ZApp.Models
{
    public class LoginRequestModel
    {
        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }
    }
}
