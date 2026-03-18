using Newtonsoft.Json;

namespace NewChatApp.Application.Services.Users;

public class CreateUserRequest
{
    [JsonProperty("nickname")]
    public required string Nickname { get; set; }
    [JsonProperty("password")]
    public required string Password { get; set; }
    [JsonProperty("email")]
    public required string Email { get; set; }
}