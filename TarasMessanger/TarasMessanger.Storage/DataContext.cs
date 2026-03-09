using Microsoft.EntityFrameworkCore;
using TarasMessenger.Core.Models;
using TarasMessenger.Core.Models.Messages;

namespace TarasMessanger.Storage;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<MessageBase> MessageBases { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*modelBuilder.Entity<MessageBase>()
            .HasDiscriminator<string>("Discriminator")
            .HasValue<TextMessage>("TextMessage")
            .HasValue<PictureMessage>("PictureMessage");*/
        
        modelBuilder.Entity<TextMessage>()
            .HasBaseType<MessageBase>();
        
        modelBuilder.Entity<PictureMessage>()
            .HasBaseType<MessageBase>();
    }
}

/* messages
 * id, discriminator, user_id, text, picture_path
 *  1    TextMessage,       1, Hello,       null,
 * 2    PictureMessage,     1, null,        picture.jpg
 */