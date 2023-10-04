
using BookLib;
using RestClientLib;

Console.WriteLine("Hello, Client of Books");
Pause();

RestClient<Book> restClient = new("https://localhost:7285");

//creating some books
CreateBooks();
Pause();

//viewing all available books
var books = GetBooks();
ViewBooks(GetBooks());
Pause();

//updating some books
UpdateBooks();
Pause();

//viewing all available books
books = GetBooks();
ViewBooks(GetBooks());
Pause();

//deleting some books
DeleteBooks();
Pause();

//viewing all available books
books = GetBooks();
ViewBooks(GetBooks());
Pause();


void DeleteBooks()
{
    Console.Write("\nDeleting products...");
    var keys = new[]{ "1", "4" };
   
   
    var results = new List<(string key, Task<Result<string?>?> task)>();
    foreach(var key in keys)
    {
        string endpoint = $"api/books/{key}";
        results.Add((key, restClient.DeleteAsync<Result<string?>>(endpoint)));
    }
    while (results.Any(t => !t.task.IsCompleted))
    {
        Console.WriteLine(".");
        Thread.Sleep(300);
    }
    Console.WriteLine();
    foreach(var result in results)
    {
        var text = (result.task.Result!.Succeded ? "Succeded" : "Failed");
        Console.WriteLine($"{text} to delete the book with id, {result.key}");
    }  
}

void UpdateBooks()
{
    Console.Write("\nUpdating products...");
    var reqs = new[]{
        new Book() { Id = "1", Title = "Mastering Java Programming Language", Pages = 800 },
        new Book() { Id = "5", Title = "Hello PL", Pages = 200 }
    };
    Console.CursorVisible = false;
    string endpoint = "api/books";
    var results = new List<(Book req, Task<Result<string?>?> task)>();
    foreach(var req in reqs)
    {
        results.Add((req, restClient.PutAsync<Book, Result<string?>>(endpoint, req)));
    }
    while (results.Any(t => !t.task.IsCompleted))
    {
        Console.WriteLine(".");
        Thread.Sleep(300);
    }
    Console.WriteLine();
    foreach (var result in results)
    {
        var text = (result.task.Result!.Succeded ? "Succeded" : "Failed");
        Console.WriteLine($"{text} to update the book with id, {result.req.Id}");
    }
    Console.CursorVisible = true;
}

List<Book> GetBooks()
{
    string getEndpoint = "api/books";
    var task= restClient.GetAsync<Result<List<Book>>>(getEndpoint);
    task.Wait();
    return  task.Result!.Data ??= new();
}
void CreateBooks()
{
    Console.Write("\nCreating products...");
    var reqs = new[] {
        new Book() { Id = "1", Title = "Mastering Java", Pages = 300 },
        new Book() { Id = "2", Title = "Learning C#", Pages = 500 }
    };
    Console.CursorVisible = false;
    string endpoint = "api/books";
    var results = new List<(Book req, Task<Result<string?>?> task)>();
    foreach (var req in reqs)
    {
        results.Add((req, restClient.PostAsync<Book, Result<string?>>(endpoint, req)));
    }
    while (results.Any(t => !t.task.IsCompleted))
    {
        Console.WriteLine(".");
        Thread.Sleep(300);
    }
    Console.WriteLine();
    foreach (var result in results)
    {
        var text = (result.task.Result!.Succeded ? "Succeded" : "Failed");
        Console.WriteLine($"{text} to create the book with id, {result.req.Id}");
    }
    Console.CursorVisible = true;

}
void ViewBooks(IEnumerable<Book> books)
{
    Console.WriteLine($"\n{"Id",-20} {"Title",-40} {"Pages",5}");
    Console.WriteLine(new string('=', 20 + 1 + 40 + 1 + 5));
    foreach(var b in books)
    {
        Console.WriteLine($"{b.Id,-20} {b.Title, -40}{b.Pages,5}");
    };
}

void Pause()
{
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}