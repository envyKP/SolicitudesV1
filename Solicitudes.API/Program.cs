using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Solicitudes.API.Infraestructura;
using Solicitudes.API.Infraestructura.Context;
using Solicitudes.API.Aplicacion;
using Solicitudes.API.Entidades.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Solicitudes.API", Version = "v1" });
});

// AutoMapper
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(configMapper));
builder.Services.AddAutoMapper(typeof(SolicitudMapper));


// Inyección de dependencias de la capa Aplicación
builder.Services.AddService();



// Conexión a la base de datos
builder.Services.AddDbContext<SolicitudesContextBD>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SolicitudesConnection")));

// Repositorios
builder.Services.AddInfrastructura();



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
