using Dapper;
using NewChatApp.Core.Abstractions;
using NewChatApp.Core.Models.Chats;
using NewChatApp.Storage.Models;

namespace NewChatApp.Storage.Repositories;

public class ChatsRepository : RepositoryBase<ChatEntity>, IChatsRepository
{
    public ChatsRepository(SqlConnectionFactory connectionFactory, IUnitOfWork unitOfWork)
        : base(connectionFactory, unitOfWork)
    {
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
    }

    public async Task<ChatBase[]> GetAll(Guid userId, int limit, int offset)
    {
        var sql = @"
SELECT c.*, cur.user_id, cur.is_admin
FROM chats c
JOIN chat_user_relations cur ON c.id = cur.chat_id
WHERE cur.user_id = @userId
ORDER BY c.created_at DESC
OFFSET @offset ROWS FETCH NEXT @limit ROWS ONLY";

        var lookup = new Dictionary<Guid, ChatBase>();

        await SelectWithRetry<ChatWithUserEntity, object>(sql, new { userId, limit, offset })
            .ContinueWith(task =>
            {
                foreach (var row in task.Result)
                {
                    if (!lookup.TryGetValue(row.Id, out var chat))
                    {
                        chat = MapToDomain(row);
                        lookup.Add(chat.Id, chat);
                    }

                    if (chat is GroupChatBase group)
                    {
                        group.UsersRelations.Add(new ChatUserRelation
                        {
                            ChatId = row.Id,
                            UserId = row.UserId,
                            IsAdmin = row.IsAdmin
                        });
                    }
                }
            });

        return lookup.Values.ToArray();
    }

    public async Task<ChatBase> Get(Guid id)
    {
        var sql = @"
SELECT c.*, cur.user_id, cur.is_admin
FROM chats c
JOIN chat_user_relations cur ON c.id = cur.chat_id
WHERE c.id = @id";

        var rows = await SelectWithRetry<ChatWithUserEntity, object>(sql, new { id });

        var first = rows.First();
        var chat = MapToDomain(first);

        foreach (var row in rows)
        {
            if (chat is GroupChatBase group)
            {
                group.UsersRelations.Add(new ChatUserRelation
                {
                    ChatId = row.Id,
                    UserId = row.UserId,
                    IsAdmin = row.IsAdmin
                });
            }
        }

        return chat;
    }

    public async Task<ChatBase> Add(ChatBase chat)
    {
        var sql = @"
INSERT INTO chats (id, created_at, type, name)
OUTPUT inserted.*
VALUES (@Id, @CreatedAt, @Type, @Name)";

        var entity = MapToEntity(chat);

        var result = await InsertWithRetry(sql, entity);

        return MapToDomain(result);
    }

    public async Task Delete(ChatBase chat)
    {
        var sql = "DELETE FROM chats WHERE id = @Id";

        await SelectWithRetry<object, object>(sql, new { chat.Id });
    }

    // 🔥 Mapping

    private static ChatBase MapToDomain(ChatEntity entity)
    {
        return entity.Type switch
        {
            "Private" => new PrivateChat(entity.Id, entity.CreatedAt, new List<ChatUserRelation>()),
            "Group" => new GroupChat(entity.Id, entity.CreatedAt, new List<ChatUserRelation>(), entity.Name),
            "Channel" => new ChannelChat(entity.Id, entity.CreatedAt, new List<ChatUserRelation>(), entity.Name),
            _ => throw new Exception("Unknown chat type")
        };
    }

    private static ChatEntity MapToEntity(ChatBase chat)
    {
        return new ChatEntity
        {
            Id = chat.Id,
            CreatedAt = chat.CreatedAt,
            Type = chat switch
            {
                PrivateChat => "Private",
                GroupChat => "Group",
                ChannelChat => "Channel",
                _ => throw new Exception("Unknown chat type")
            },
            Name = chat is GroupChatBase g ? g.Name : null
        };
    }
}