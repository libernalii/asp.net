using hw_2.Models;
using Microsoft.EntityFrameworkCore;

namespace hw_2.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<Book> Books { get; set; }
}
