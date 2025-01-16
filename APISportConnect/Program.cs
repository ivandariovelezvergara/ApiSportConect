using BSportConect.Security;
using BSportConect.Security.Service;
using DSportConnect.Repositories.Security;
using Entity.Enumerable;
using MongoDB.Driver;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Any;
using DSportConnect.Repositories.Master;
using BSportConect.Master;
using BSportConect.Master.Service;
using DSportConnect.Repositories.Sport;
using BSportConect.Sport;
using BSportConect.Sport.Service;
using System.Text;
using Entity.AppSettings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using DSportConnect.Repositories.User;
using BSportConect.User;
using BSportConect.User.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using BSportConect.Email.Service;
using BSportConect.Email;

var builder = WebApplication.CreateBuilder(args);

#region Mapeo del appSetting
builder.Services.AddSingleton<IMongoClient>(_ =>
    new MongoClient(builder.Configuration.GetConnectionString("MongoDB")));

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
builder.Services.Configure<UserRol>(builder.Configuration.GetSection("UserRol"));
builder.Services.Configure<Email>(builder.Configuration.GetSection("EmailSettings"));
#endregion

#region Mapeo de MongoDB
builder.Services.AddScoped<IRoleRepository, RoleRepository>(sp =>
    new RoleRepository(
        sp.GetRequiredService<IMongoClient>(),
        builder.Configuration["DatabaseName"],
        sp.GetRequiredService<IAppObjectRepository>()
    ));

builder.Services.AddScoped<IAppObjectRepository, AppObjectRepository>(sp =>
    new AppObjectRepository(
        sp.GetRequiredService<IMongoClient>(),
        builder.Configuration["DatabaseName"]
    ));

builder.Services.AddScoped<IParameterRepository, ParameterRepository>(sp =>
    new ParameterRepository(
        sp.GetRequiredService<IMongoClient>(),
        builder.Configuration["DatabaseName"]
    ));

builder.Services.AddScoped<ISportRepository, SportRepository>(sp =>
    new SportRepository(
        sp.GetRequiredService<IMongoClient>(),
        builder.Configuration["DatabaseName"]
    ));

builder.Services.AddScoped<IInformationRepository, InformationRepository>(sp =>
    new InformationRepository(
        sp.GetRequiredService<IMongoClient>(),
        builder.Configuration["DatabaseName"],
        sp.GetRequiredService<IRoleRepository>(),
        sp.GetRequiredService<IOptions<UserRol>>()
    ));

builder.Services.AddScoped<IOAuth2Repository, OAuth2Repository>(sp =>
    new OAuth2Repository(
        sp.GetRequiredService<IMongoClient>(),
        builder.Configuration["DatabaseName"],
        sp.GetRequiredService<IInformationRepository>()
    ));
#endregion

#region Integracion Clases con interface
// Add services to the container.
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IAppObjectService, AppObjectService>();
builder.Services.AddScoped<IParameterService, ParameterService>();
builder.Services.AddScoped<ISportService, SportService>();
builder.Services.AddScoped<IInformationService, InformationService>();
builder.Services.AddScoped<IOAuth2Service, OAuth2Service>();
builder.Services.AddTransient<IEmailService, EmailService>();
#endregion

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

#region Implementacion swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "APISportConnect",
        Version = "v1",
        Description = "Documentación de la API para gestión deportiva"
    });

    // Configurar el esquema de autenticación Bearer para Swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Ingrese el token en el formato: Bearer {token}"
    });

    // Requerir el esquema de autenticación para todas las solicitudes
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new List<string>()
        }
    });
});
#endregion

// Habilita CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()  
              .AllowAnyMethod()  
              .AllowAnyHeader(); 
    });
});

builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseCors("AllowAll");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint($"/swagger/v1/swagger.json", "API v1");
    c.RoutePrefix = "swagger"; // Hace que Swagger esté disponible en la raíz
});
app.MapControllers();
app.Run();