using BooksAPI.Data;
using BooksAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();
var app = builder.Build();

app.MapGet("v1/books", async (AppDbContext context) =>
{
    var books =await context.Books.ToListAsync();
    return Results.Ok(books);
});

app.MapGet("v1/books/author/{authorName}", async (string authorName, AppDbContext context) =>
{
    var authorBooks = context.Books.Where(book => book.Author == authorName).ToList();
    if (authorBooks.Count == 0)
        return Results.NoContent();
    return Results.Ok(authorBooks);
});


app.MapPost("v1/books/create", async (Book book, AppDbContext context) =>
{
    await context.Books.AddAsync(book);
    context.SaveChanges();
    return Results.Created($"v1/books/create/{book.Id}", book);
});


app.MapPut("v1/books/update/{id}", async (int id, Book inputBook, AppDbContext context) =>
{
    var book = await context.Books.FindAsync(id);
    if (book is null)
        return Results.NotFound();

    book.Title = inputBook.Title;
    book.Status = inputBook.Status;
    await context.SaveChangesAsync();
    return Results.NoContent();
});


app.MapDelete("v1/books/delete/{id}", async (int id, AppDbContext context) =>
{
    if (await context.Books.FindAsync(id) is Book book)
    {
        context.Books.Remove(book);
        await context.SaveChangesAsync();
        return Results.Ok(book);
    }
    return Results.NotFound();
});

app.Run();
