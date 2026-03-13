namespace NewChatApp.Core.Models;

public class User
{
    public Guid Id { get; set; }
    public string Nickname { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }
}