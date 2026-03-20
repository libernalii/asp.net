using Newtonsoft.Json;

namespace NewChatApp.Storage.Models;

public class UserEntity
{
    [JsonProperty("id")]
    public Guid Id { get; set; }
    [JsonProperty("nickname")]
    public string Nickname { get; set; }
    [JsonProperty("email")]
    public string Email { get; set; }
    [JsonProperty("total_count")]
    public int TotalCount { get; set; }
}