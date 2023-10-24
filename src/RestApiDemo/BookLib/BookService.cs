namespace BookLib;

public class BookService
{
    private readonly BookRepo _repo;

    public BookService(BookRepo repo)
    {
        _repo = repo;
    }
    public Result<List<string?>> Initialize()
    {
        if (_repo.DbContext.Books.Any()) return new();
        var reqs = new List<Book>()
        {
            new()
            {
                Id = "1",
                Title = "Mastering Java",
                Pages = 600
            },
            new()
            {
                Id = "2",
                Title = "Learning C#",
                Pages = 500
            }
        };
        var result = reqs.Select(x => Create(x).Data).ToList();
        return Result<List<string?>>.Success(result);
    }
    public Result<bool> Exist(string key)
    {
        var result = _repo.GetQueryable().Any(x => x.Id == key);
        return Result<bool>.Success(result);
    }
    public Result<string?> Create(Book req)
    {
        if (Exist(req.Id).Data == true)
            return Result<string?>.Fail($"The Book with the id, {req.Id}, does already exist");
        _repo.Create(req);
        return Result<string?>.Success(req.Id, "Successfully created");
    }

    public Result<List<Book>> ReadAll()
    {
        var result = _repo.GetQueryable().ToList();
        return Result<List<Book>>.Success(result);
    }
    public Result<Book?> Read(string key)
    {
        var entity = _repo.GetQueryable().FirstOrDefault(x => x.Id == key);
        return Result<Book?>.Success(entity);
    }

    public Result<string?> Update(Book req)
    {
        var found = _repo.GetQueryable().FirstOrDefault(x => x.Id == req.Id);
        if (found == null) return Result<string?>.Fail($"No Book with id, {req.Id}");
        var entity = found.Clone();
        entity.Copy(req);
        var result = _repo.Update(entity);
        return result == true ? Result<string?>.Success(entity.Id, "Successfully updated")
                : Result<string?>.Fail($"Failed to update Book with id, {req.Id}");
    }
    public Result<string?> Delete(string key)
    {
        var found = _repo.GetQueryable().FirstOrDefault(x => x.Id == key);
        if (found == null) return Result<string?>.Fail($"No Book with id, {key}");
        var result = _repo.Delete(found.Id);
        return result == true ? Result<string?>.Success(found.Id, "Successfully deleted")
                : Result<string?>.Fail($"Failed to delete Book with id/code, {key}");
    }
}