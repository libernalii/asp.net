using Dapper;
using NewChatApp.Core.Abstractions;
using NewChatApp.Core.Models.ChatMessages;
using NewChatApp.Storage.Models;

namespace NewChatApp.Storage.Repositories;

public class ChatMessagesRepository : RepositoryBase<ChatMessageEntity>, IChatMessagesRepository
{
    public ChatMessagesRepository(SqlConnectionFactory connectionFactory, IUnitOfWork unitOfWork)
        : base(connectionFactory, unitOfWork)
    {
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
    }

    public async Task<ChatMessageBase[]> Get(Guid chatId, int limit, int offset)
    {
        var sql = @"
            SELECT * FROM chat_messages
            WHERE chat_id = @chatId
            ORDER BY send_at DESC
            OFFSET @offset ROWS FETCH NEXT @limit ROWS ONLY";

        var messages = await SelectWithRetry<ChatMessageEntity, object>(sql, new { chatId, limit, offset });

        return messages.Select(MapToDomain).ToArray();
    }

    public async Task<ChatMessageBase> Add(ChatMessageBase message)
    {
        var sql = @"
            INSERT INTO chat_messages (id, send_at, sender_id, chat_id, status, content, type)
            OUTPUT inserted.*
            VALUES (@Id, @SendAt, @SenderId, @ChatId, @Status, @Content, @Type)";

        var entity = MapToEntity(message);

        var inserted = await InsertWithRetry(sql, entity);

        var result = MapToDomain(inserted);

        if (message is FileChatMessage fileMessage)
        {
            var fileSql = @"
                INSERT INTO chat_message_files (id, message_id, file_name, file_path, size)
                VALUES (@Id, @MessageId, @FileName, @FilePath, @Size)";

            foreach (var file in fileMessage.Files)
            {
                await SelectWithRetry<object, object>(fileSql, new
                {
                    Id = Guid.NewGuid(),
                    MessageId = result.Id,
                    FileName = file.FileName,
                    FilePath = file.FilePath,
                    Size = file.Size
                });
            }
        }

        return result;
    }

    public async Task<ChatMessageBase> Update(ChatMessageBase message)
    {
        var sql = @"
            UPDATE chat_messages
            SET status = @Status,
                content = @Content
            OUTPUT inserted.*
            WHERE id = @Id";

        var entity = MapToEntity(message);

        var result = await InsertWithRetry(sql, entity);

        return MapToDomain(result);
    }

    // Mapping

    private static ChatMessageBase MapToDomain(ChatMessageEntity entity)
    {
        return entity.Type switch
        {
            "Text" => new TextChatMessage
            {
                Id = entity.Id,
                SendAt = entity.SendAt,
                SenderId = entity.SenderId,
                ChatId = entity.ChatId,
                Status = (ChatMessageStatus)entity.Status,
                Content = entity.Content
            },
            "Picture" => new PictureChatMessage
            {
                Id = entity.Id,
                SendAt = entity.SendAt,
                SenderId = entity.SenderId,
                ChatId = entity.ChatId,
                Status = (ChatMessageStatus)entity.Status,
                Content = entity.Content
            },
            "File" => new FileChatMessage
            {
                Id = entity.Id,
                SendAt = entity.SendAt,
                SenderId = entity.SenderId,
                ChatId = entity.ChatId,
                Status = (ChatMessageStatus)entity.Status,
                Content = entity.Content
            },
            _ => throw new Exception("Unknown message type")
        };
    }

    private static ChatMessageEntity MapToEntity(ChatMessageBase message)
    {
        return new ChatMessageEntity
        {
            Id = message.Id,
            SendAt = message.SendAt,
            SenderId = message.SenderId,
            ChatId = message.ChatId,
            Status = (int)message.Status,
            Content = message.Content,
            Type = message switch
            {
                TextChatMessage => "Text",
                PictureChatMessage => "Picture",
                FileChatMessage => "File",
                _ => throw new Exception("Unknown message type")
            }
        };
    }
}