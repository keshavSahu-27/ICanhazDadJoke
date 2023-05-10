using ICanHazDadJoke.Extensions;
using ICanHazDadJoke.Dto;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration
    .GetSection("ICanHazeDadJokeConnectionProperties")
    .Get(typeof(ICanHazDadJokeConnectionProperties));

if (configuration == null)
{
    throw new ArgumentNullException("Config could not be null");
}

builder.Services.RegisterServices((ICanHazDadJokeConnectionProperties)configuration);

var app = builder.Build();

app.UseCors("icanhazdadjoke");

app.ConfigureMiddleware();

app.Run();
