using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Minimal_API;
using Minimal_API.Data;
using Minimal_API.Models;
using Minimal_API.Models.DTOs;
using Minimal_API.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBookRepository<Book>, BookRepository>();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));
builder.Services.AddValidatorsFromAssemblyContaining<BookCreateDTO>();
builder.Services.AddAutoMapper(typeof(MappingConfig));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/book", async (IBookRepository<Book> context) =>
{
    APIResponse response = new APIResponse();


    response.Result = await context.GetAll();
    response.IsSucess = true;
    response.StatusCode = System.Net.HttpStatusCode.OK;

    return Results.Ok(response);
}).WithName("GetAllBooks").Produces(200);

app.MapGet("/api/book/{id:int}", async (IBookRepository<Book> context, int id) =>
{
    APIResponse response = new APIResponse();

    response.Result = await context.GetById(id);
    response.IsSucess = true;
    response.StatusCode = System.Net.HttpStatusCode.OK;

    return Results.Ok(response);
}).WithName("GetBookByID");

app.MapPost("/api/book/", async (IBookRepository<Book> context, IValidator<BookCreateDTO> validator, IMapper mapper, [FromBody] BookCreateDTO bookCreateDto) =>
{
    APIResponse response = new APIResponse() { IsSucess = false, StatusCode = System.Net.HttpStatusCode.BadRequest};
    IEnumerable<Book> bookList = await context.GetAll();

    var validationResult = await validator.ValidateAsync(bookCreateDto);
    if (!validationResult.IsValid)
    {
        return Results.BadRequest(response);
    }
    if (bookList.FirstOrDefault(b => b.Name.ToLower() == bookCreateDto.Name.ToLower()) != null)
    {
        response.ErrorMessages.Add("Book with that name already exist.");
        return Results.BadRequest(response);
    }

    Book book = mapper.Map<Book>(bookCreateDto);
    
    await context.Add(book);

    BookDTO bookDto = mapper.Map<BookDTO>(book);

    response.Result = bookDto;
    response.IsSucess = true;
    response.StatusCode = System.Net.HttpStatusCode.Created;
    return Results.Ok(response);
}).WithName("CreateBook").Accepts<BookCreateDTO>("application/json").Produces<APIResponse>(201).Produces(400);

app.MapPut("/api/book/", async (IBookRepository<Book> context, IValidator<BookUpdateDTO> validator, IMapper mapper, [FromBody] BookUpdateDTO bookUpdateDto ) =>
{
    APIResponse response = new APIResponse() { IsSucess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };
    IEnumerable<Book> bookList = await context.GetAll();

    var validationResult = await validator.ValidateAsync(bookUpdateDto);
    if (!validationResult.IsValid)
    {
        return Results.BadRequest(response);
    }

    Book book = mapper.Map<Book>(bookUpdateDto);

    await context.Update(book);

    BookDTO bookDto = mapper.Map<BookDTO>(book);

    response.Result = bookDto;
    response.IsSucess = true;
    response.StatusCode = System.Net.HttpStatusCode.OK;

    return Results.Ok(response);

}).WithName("UpdateBook").Accepts<BookUpdateDTO>("application/json").Produces<APIResponse>(200).Produces(400);

app.MapDelete("api/book/{id:int}", async (IBookRepository<Book> context, int id) =>
{
    APIResponse response = new APIResponse() { IsSucess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };
    IEnumerable<Book> bookList = await context.GetAll();

    Book bookToDelete = bookList.FirstOrDefault(b => b.ID == id);

    if (bookToDelete != null)
    {
        await context.Delete(bookToDelete);
        response.IsSucess = true;
        response.StatusCode = System.Net.HttpStatusCode.NoContent;
        return Results.Ok(response);
    }
    else
    {
        response.ErrorMessages.Add("Invalid ID");
        return Results.BadRequest(response);
    }
}).WithName("DeleteBook");

app.Run();


