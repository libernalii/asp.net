using hw_2.Data;
using hw_2.Repositories;
using hw_2.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(
    opt => opt.UseInMemoryDatabase("BookStoreDB")
);

builder.Services.AddScoped<BookRepository>();
builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<DescriptionValidator>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
