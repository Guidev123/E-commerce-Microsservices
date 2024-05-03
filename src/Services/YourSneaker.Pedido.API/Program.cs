//========================================== Environment Configure ===============================================/
using MediatR;
using YourSneaker.Pedido.API.Configuration;
using YourSneaker.Pedido.API.Controllers;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();
//================================================ End ========================================================/


//API CONFIG
builder.Services.AddApiConfig(builder.Configuration);
builder.Services.AddMediatR(typeof(Program));
builder.Services.RegisterServices();


//SWAGGER CONFIG
builder.Services.AddSwaggerConfig();

var app = builder.Build();


app.UseSwaggerConfig();
app.UseApiConfig(app.Environment);
app.UseAuthorization();

app.MapControllers();

app.Run();