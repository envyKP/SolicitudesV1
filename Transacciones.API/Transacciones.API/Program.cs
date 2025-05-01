using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Transacciones.API.Aplicacion; // <- Para AddService()
using Transacciones.API.Aplicacion.Interfaces.Irepositorio;
using Transacciones.API.Aplicacion.Interfaces.Iservicio;
using Transacciones.API.Aplicacion.Servicios;
using Transacciones.API.Entidades.Mapper;
using Transacciones.API.Infraestructura;
using Transacciones.API.Infraestructura.Context;
using Transacciones.API.Infraestructura.Repositorios;
using Transacciones.API.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// SGA -> Samuel Gavela ;)

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Transacciones.API", Version = "v1" });
});

// AutoMapper
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(usuarioMappers));
builder.Services.AddAutoMapper(typeof(ConfiguracionAutoMapper));



// Inyección de dependencias de la capa Aplicación
builder.Services.AddService();

// HttpClient para comunicación con ProductoAPI
builder.Services.AddHttpClient<IProductoProxyService, ProductoProxyService>(client =>
{
    var productoApiUrl = builder.Configuration["ApisConsumo:ProductoApiUrl"];
    client.BaseAddress = new Uri(productoApiUrl);

});


// Conexión a la base de datos
builder.Services.AddDbContext<LogicStudioTransaccionesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LogicStudioTransaccionesConnection")));

// Repositorios
builder.Services.AddInfrastructura();
//builder.Services.AddScoped<ITransaccionesRepositorio, TransaccionesRepositorio>();


builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("clave-secreta-super-segura-123"))
        };
    });

builder.Services.AddScoped<JwtTokenService>();  // Agregar servicio para generar el token JWT


var app = builder.Build();

// Pipeline de la app
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// Middleware personalizado para validar cabecera
app.UseValidacionCabeceraMiddleware();
app.UseAuthentication();

app.UseAuthorization();
app.MapControllers();

app.Run();
