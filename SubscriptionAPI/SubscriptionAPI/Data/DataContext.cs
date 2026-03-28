using Microsoft.EntityFrameworkCore;
using SubscriptionAPI.Models;

namespace SubscriptionAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options ) : base(options)
        {
            Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(e => e.Id);
            modelBuilder.Entity<User>().Property(u => u.Name).IsRequired().HasMaxLength(10);
            modelBuilder.Entity<User>().Property(u => u.Bday).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Email).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<User>().HasMany(u => u.subscriptions).WithOne().HasForeignKey(s => s.UserId);


            modelBuilder.Entity<Subscription>().HasKey(s => s.Id);
            modelBuilder.Entity<Subscription>().Property(s => s.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Subscription>().Property(s => s.Price).IsRequired();
            modelBuilder.Entity<Subscription>().Property(s => s.StartedDate).IsRequired();
            modelBuilder.Entity<Subscription>().Property(s => s.FinishedDate).IsRequired();
            modelBuilder.Entity<Subscription>().Property(s => s.Type).IsRequired().HasMaxLength(20);



        }
    }
}
