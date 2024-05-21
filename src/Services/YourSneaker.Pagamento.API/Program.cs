using YourSneaker.Pagamento.API.Configuration;
using YourSneaker.WebAPI.Core.Identidade;
//========================================== Environment Configure ===============================================/
var builder = WebApplication.CreateBuilder(args);
builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();
//================================================ End ========================================================/


//API CONFIG
builder.Services.AddApiConfig(builder.Configuration);
builder.Services.AddMessageBusConfiguration(builder.Configuration);
builder.Services.AddJwtConfiguration(builder.Configuration);
builder.Services.RegisterServices();

//SWAGGER CONFIG
builder.Services.AddSwaggerConfig();

var app = builder.Build();


app.UseSwaggerConfig();
app.UseApiConfig(app.Environment);
app.UseAuthorization();

app.MapControllers();

app.Run();