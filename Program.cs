using TodoApi.Context;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AgendaContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConexaoPadrao"))); // UserNpgsql -> Para o Postgres

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi("Api");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
