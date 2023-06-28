using GeoLocationDemoAPI.WebAPI;
using GeoLocationDemo.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterInfrastructureRepositoryServices();
builder.Services.RegisterWebAPIServices();

var app = builder.Build();


app.UseWebAPISetup();
app.Run();
