namespace NewChatApp.Core.Models.ChatMessages;

public sealed class PictureChatMessage : ChatMessageBase
{
    public ICollection<PictureItem> PictureItems { get; set; } = new List<PictureItem>();
}

public class PictureItem
{
    public required string PictureSourcePath { get; set; }
}