using Newtonsoft.Json;

namespace NewChatApp.Core.Models.Users;

public class User
{
    [JsonProperty("id")]
    public Guid Id { get; set; }
    [JsonProperty("nickname")]
    public string Nickname { get; set; }
    [JsonProperty("password_hash")]
    public string PasswordHash { get; set; }
    [JsonProperty("email")]
    public string Email { get; set; }
    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }
}