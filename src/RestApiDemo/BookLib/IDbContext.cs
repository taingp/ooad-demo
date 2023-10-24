using Microsoft.EntityFrameworkCore;

namespace BookLib;

public interface IDbContext
{
    DbSet<Book> Books { get; set; }
    int SaveChanges();
}
