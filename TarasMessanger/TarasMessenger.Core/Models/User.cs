namespace TarasMessenger.Core.Models;

public class User
{
    public Guid Id { get; set; }
    public required string Nickname { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public DateTime CreatedAt { get; set; }
}