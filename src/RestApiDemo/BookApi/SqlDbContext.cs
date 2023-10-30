using Microsoft.EntityFrameworkCore;
using BookLib;

namespace BookApi;

public class SqlDbContext : DbContext, IDbContext
{
    public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
    {
        Books = Set<Book>();
    }

    public DbSet<Book> Books { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BookEntityTypeConfig());
        modelBuilder.Entity<Book>().HasData(
            new Book()
            {
                Id = "1",
                Title = "Mastering Java",
                Pages = 600
            },
            new Book()
            {
                Id = "2",
                Title = "Learning C#",
                Pages = 500
            }
            );
    }
}
