namespace NewChatApp.Shared.Common;

public class PagedList<T> where T : class
{
    public ICollection<T> Items { get; set; }
    public int Limit { get; set; }
    public int Offset { get; set; }
    public int TotalCount { get; set; }

    public PagedList<K> Cast<K>(Func<T, K> castFunc) where K : class => new PagedList<K>
    {
        Limit = Limit,
        Offset = Offset,
        TotalCount = TotalCount,
        Items = Items.Select(castFunc).ToArray()
    };
}