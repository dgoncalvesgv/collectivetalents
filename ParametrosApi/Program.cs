var builder = WebApplication.CreateBuilder(args);

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Controllers (MVC)
builder.Services.AddControllers();

// CORS (ajuste em produção)
builder.Services.AddCors(p => p.AddDefaultPolicy(b =>
    b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();
