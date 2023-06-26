using GeoLocationDemoAPI.WebAPI;


var builder = WebApplication.CreateBuilder(args);
builder.Services.RegisterWebAPIServices();
var app = builder.Build();
app.UseWebAPISetup();
app.Run();
