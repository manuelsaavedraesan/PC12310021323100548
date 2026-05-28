using Microsoft.EntityFrameworkCore;
using BibliotecaClases.Infrastructure.Data;
using BibliotecaClases.Core.Interfaces;
using BibliotecaClases.Infrastructure.Repositories;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<TallerDbContext>(options =>
    options.UseSqlServer("Server=AO2300940;Database=TallerMecanicoDb;Trusted_Connection=True;TrustServerCertificate=True;"));
builder.Services.AddScoped<IOrdenServicioRepository, OrdenServicioRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
