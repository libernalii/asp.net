using Newtonsoft.Json;

namespace NewChatApp.Application.Services.Users;

public class UserDto
{
    [JsonProperty("id")]
    public Guid Id { get; set; }
    [JsonProperty("nickname")]
    public string Nickname { get; set; }
    [JsonProperty("email")]
    public string Email { get; set; }
}