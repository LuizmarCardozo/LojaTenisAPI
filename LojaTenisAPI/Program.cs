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

var connectionString = builder.Configuration.GetConnectionString("LojaTenis");
builder.Services.AddDbContext<LojaTenisContext>(options=>options.UseMySQL(connectionString));

builder.Services.AddScoped<IProdutoServices, ProdutoServices>();
builder.Services.AddScoped<IProdutoDAO, ProdutoDAO>();
builder.Services.AddScoped<IImagemServices, ImagemServices>();
builder.Services.AddScoped<IImagemDAO, ImagemDAO>();

builder.Services.AddScoped<LojaTenisContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(option => option.AllowAnyOrigin());

app.Run();
