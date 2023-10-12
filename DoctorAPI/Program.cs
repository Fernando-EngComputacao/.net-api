using System.Reflection;
using System.Text;
using DoctorAPI.Assets.data;
using DoctorAPI.Assets.Security;
using DoctorAPI.Assets.service;
using DoctorAPI.core;
using DoctorAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionStringClinic = builder.Configuration.GetConnectionString(("DoctorConnection"));
var connectionStringUser = builder.Configuration.GetConnectionString(("UserConnection"));

builder.Services.AddDbContext<DoctorContext>(
    opts =>
    {
        opts.UseMySql(connectionStringClinic, ServerVersion.AutoDetect(connectionStringClinic));
    }
);

builder.Services.AddDbContext<UserDBContext>(
    opts =>
    {
        opts.UseMySql(connectionStringUser, ServerVersion.AutoDetect(connectionStringUser));
        
    }
);

builder.Services
    .AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<UserDBContext>()
    .AddDefaultTokenProviders();


// To use AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// To add UserAuthorization (method created by myselg), UserAuthorization > ValidUser
builder.Services.AddSingleton<IAuthorizationHandler, UserAuthorization>();

// To use Service
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TokenService>();

// To apply authorization
builder.Services.AddAuthorization(opt =>
    {
        opt.AddPolicy("standard", policy =>
        {
            policy.AddRequirements(new ValidUser());
        });
        opt.AddPolicy("local", policy =>
        {
            policy.RequireAuthenticatedUser();
            policy.AddRequirements(new ValidUser());
            policy.RequireClaim("NívelDeAcesso", "Admin");
        });
    }
);

// To apply authentication
builder.Services.AddAuthentication(
    opts =>
    {
        opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    }    
).AddJwtBearer(opts =>
    {
        opts.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("5DFA4F56ASDFA6SF54A6SD5F4")),
            ValidateAudience = false,
            ValidateIssuer = false,
            ClockSkew = TimeSpan.Zero
        };
    }
);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo() { Title = "ClinicAPI", Version = "v1" });

    // Configuração do esquema de segurança Bearer
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            new string[] {}
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

    // Adiciona o filtro personalizado para adicionar ícones de cadeado
    c.OperationFilter<SwaggerString>();
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();