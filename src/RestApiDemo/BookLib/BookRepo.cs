namespace BookLib;

public class BookRepo
{
    private readonly IDbContext _context;
    public BookRepo(IDbContext context) { _context = context; }

    public IDbContext DbContext => _context;

    public void Create(Book entity)
    {
        try
        {
            _context.Books.Add(entity.Clone());
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to create > {ex.Message}");
        }
    }
    public IQueryable<Book> GetQueryable()
    {
        return _context.Books.AsQueryable();
    }

    public bool Update(Book entity)
    {
        var found = GetQueryable().FirstOrDefault(x => x.Id == entity.Id);
        if (found != null)
        {
            try
            {
                found.Copy(entity);
                _context.Books.Update(found);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update > {ex.Message}");
            }
        }
        return found != null;
    }
    public bool Delete(string id)
    {
        var found = GetQueryable().FirstOrDefault(x => x.Id == id);
        if (found != null)
        {
            try
            {
                _context.Books.Remove(found);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete > {ex.Message}");
            }
        }
        return false;
    }

}