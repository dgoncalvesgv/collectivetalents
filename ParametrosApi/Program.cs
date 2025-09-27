using Microsoft.EntityFrameworkCore;
using ParametrosApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// EF Core
builder.Services.AddDbContext<ParametrosDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Controllers (MVC)
builder.Services.AddControllers();

// CORS (ajuste em produção)cl
builder.Services.AddCors(p => p.AddDefaultPolicy(b =>
    b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

app.UseCors();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Parametros API v1");
});

app.MapControllers();

app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();
