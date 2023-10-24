using Microsoft.EntityFrameworkCore;
using BookLib;

namespace BookApi;

public class MemoryDbContext : DbContext, IDbContext
{
    public MemoryDbContext(DbContextOptions<MemoryDbContext> options) : base(options)
    {
        Books = Set<Book>();
    }

    public DbSet<Book> Books { get; set; }
}
