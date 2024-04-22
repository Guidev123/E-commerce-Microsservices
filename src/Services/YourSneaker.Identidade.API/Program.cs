using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using YourSneaker.Identidade.API.Data;
using System.Text;
using YourSneaker.Identidade.API.Extensions;
using YourSneaker.WebAPI.Core.Identidade;
using YourSneaker.Identidade.API.Configuration;

//========================================== Environment Configure ===============================================/
var builder = WebApplication.CreateBuilder(args);
builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();
//================================================ END ========================================================/


// DATA BASE CONFIG

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//IDENTITY CONFIG

builder.Services
    .AddDefaultIdentity<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddErrorDescriber<IdentityMessagePT>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

//JWT CONFIG
builder.Services.AddJwtConfiguration(builder.Configuration);
builder.Services.AddMessageBusConfiguration(builder.Configuration);

builder.Services.AddControllers();

// SWAGGER CONFIG

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo 
{
   Title = "YourSneaker Enterprise Identity API",
   Description = "API de identidade",
   Contact = new OpenApiContact() { Name = "Guilherme Nascimento", Email = "guirafaelrn@gmail.com"},
   License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/license/MIT")}
}));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));
}

// HTTP CONFIG

app.UseHttpsRedirection();

app.UseAuthConfiguration();

app.MapControllers();

app.Run();
