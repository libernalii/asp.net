namespace TarasMessenger.Core.Models.Messages;

public class PictureMessage : MessageBase
{
    public string Text { get; set; }
    public required string PicturePath { get; set; }
}