using BookApi;
using BookLib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<IDbContext, MemoryDbContext>(options =>
{
    options.UseInMemoryDatabase("BookDb");
});
builder.Services.AddTransient<BookRepo>();
builder.Services.AddTransient<BookService>();
builder.Services.AddTransient<IHostedService, InitService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

MapBookEndpoints(app, "Books");
app.Run();

void MapBookEndpoints(WebApplication app, string tag)
{
    app.MapGet("api/books", ([FromServices] BookService service)
        => { return service.ReadAll(); }).WithTags(tag);
    app.MapGet("api/books/{key}", ([FromServices] BookService service, string key) 
        => { return service.Read(key); }).WithTags(tag);
    app.MapPost("api/books", (Book req, [FromServices] BookService service) 
        => { return service.Create(req); }).WithTags(tag);
    app.MapPut("api/books", ([FromServices] BookService service, Book req) 
        => { return service.Update(req); }).WithTags(tag);
    app.MapDelete("api/books/{key}", ([FromServices] BookService service, string key) 
        => { return service.Delete(key); }).WithTags(tag);
}
