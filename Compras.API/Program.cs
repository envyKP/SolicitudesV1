using Compras.API.Infraestructura.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Compras.API.Aplicacion;
using Compras.API.Infraestructura;
using Compras.API.Aplicacion.Interfaces.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Solicitude.API", Version = "v1" });
});
builder.Services.AddDbContext<ComprasDevContextBD>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ComprasTransaccionesConnection")));
//builder.Services.AddScoped<IUsuariosRepositorio, UsuariosRepositorio>();

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

app.Run();
