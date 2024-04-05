using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.Extensions.Hosting.Internal;
using YourSneaker.WebApp.MVC.Configuration;
using YourSneaker.WebApp.MVC.Extensions;

//========================================== Configura Ambiente ===============================================/
var builder = WebApplication.CreateBuilder(args);
builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();
//================================================ Fim ========================================================/


builder.Services.AddIdentityConfiguration();//IDENTITY CONFIG AND COOKIES CONFIG


builder.Services.RegisterServices();
builder.Services.AddControllersWithViews();

builder.Services.Configure<AppSettings>(builder.Configuration);

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/erro/500");
    app.UseStatusCodePagesWithRedirects("/erro/{0}");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityConfiguration();//AUTHENTICATION AND AUTHORIZATION SETUP

app.UseMiddleware<ExceptionMiddleware>();//USING CUSTOM MIDDLEWARE

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Catalogo}/{action=Index}/{id?}");

app.Run();
