using System.Reflection.Metadata.Ecma335;
using BookLib;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
    app.MapGet("api/books", ()=>{return new BookService().ReadAll();}).WithTags(tag);
    app.MapGet("api/books/{key}",(string key)=>{return new BookService().Read(key); }).WithTags(tag);
    app.MapPost("api/books", (Book req)=>{return new BookService().Create(req);}).WithTags(tag);
    app.MapPut("api/books", (Book req) => { return new BookService().Update(req);}).WithTags(tag);
    app.MapDelete("api/books/{key}", (string key)=> { return new BookService().Delete(key);}).WithTags(tag);
}
