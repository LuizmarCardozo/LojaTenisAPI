using LojaTenisAPI.DAO;
using LojaTenisAPI.DAO.Interfaces;
using LojaTenisAPI.Data;
using LojaTenisAPI.Service;
using LojaTenisAPI.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure connection string for database
var connectionString = builder.Configuration.GetConnectionString("LojaTenis");
builder.Services.AddDbContext<LojaTenisContext>(options => options.UseMySQL(connectionString));

// Register services and DAOs (Dependency Injection)
builder.Services.AddScoped<IProdutoServices, ProdutoServices>();
builder.Services.AddScoped<IProdutoDAO, ProdutoDAO>();
builder.Services.AddScoped<IImagemServices, ImagemServices>();
builder.Services.AddScoped<IImagemDAO, ImagemDAO>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddScoped<LojaTenisContext>();

// Add CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin() // Permitir requisições de qualquer origem
              .AllowAnyMethod() // Permitir qualquer método HTTP (GET, POST, etc.)
              .AllowAnyHeader(); // Permitir todos os cabeçalhos, como Content-Type
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Apply CORS policy
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();