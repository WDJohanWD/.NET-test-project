using Microsoft.EntityFrameworkCore;
using test.Services;
using Test.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuración de EF Core con SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=test.db"));

builder.Services.AddControllers();

// Register the service with its interface so DI can resolve ITaskService
builder.Services.AddScoped<ITaskService, TaskService>();

// Use the lightweight Microsoft.AspNetCore.OpenApi support (no Swashbuckle)
builder.Services.AddOpenApi();

var app = builder.Build();

// Swagger solo en desarrollo
if (app.Environment.IsDevelopment())
{
    // MapOpenApi exposes the generated OpenAPI document/endpoints in development
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
