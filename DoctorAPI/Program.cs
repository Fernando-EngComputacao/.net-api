using System.Reflection;
using DoctorAPI.Assets.data;
using DoctorAPI.Assets.service;
using DoctorAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

// To use Service
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TokenService>();

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo() { Title = "ClinicAPI", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

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