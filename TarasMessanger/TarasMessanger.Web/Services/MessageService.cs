using Microsoft.EntityFrameworkCore;
using TarasMessanger.Storage;
using TarasMessenger.Core.Models.Messages;

namespace TarasMessanger.Web.Services;

public class MessageService
{
    private DataContext _context;

    public MessageService(DataContext context)
    {
        _context = context;
    }

    public async Task AddMessage(MessageBase message)
    {
        _context.MessageBases.Add(message);
        await _context.SaveChangesAsync();
    }
    
    public Task<List<MessageBase>> GetMessages(Guid chatId, int limit, int offset)
    {
        return _context.MessageBases
            .AsNoTracking()
            .Where(x => !x.IsDeleted)
            .OrderByDescending(x => x.SendAt)
            .Skip(offset)
            .Take(limit)
            .ToListAsync();
    }
}