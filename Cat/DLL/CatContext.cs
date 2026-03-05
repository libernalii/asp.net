using DLL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class CatContext : DbContext
    {
        public DbSet<Cat> Cats { get; set; }
        public CatContext(DbContextOptions<CatContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cat>()
                 .HasKey(c => c.Id);
            modelBuilder.Entity<Cat>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(30);
            modelBuilder.Entity<Cat>()
                .Property(c => c.Age)
                .IsRequired();
            modelBuilder.Entity<Cat>()
                .Property(c => c.Breed)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}
