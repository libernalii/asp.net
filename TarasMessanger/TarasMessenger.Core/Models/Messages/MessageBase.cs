namespace TarasMessenger.Core.Models.Messages;

public abstract class MessageBase
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public required User User { get; set; }
    
    //public Guid ChatId { get; set; }
    
    public DateTime SendAt { get; set; }
    public bool IsDeleted { get; set; }
}