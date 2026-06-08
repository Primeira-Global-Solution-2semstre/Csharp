using Microsoft.EntityFrameworkCore;
using neoHorizonApi.Services;
using SpaceApi.Data;


var builder = WebApplication.CreateBuilder(args);

Console.WriteLine("CONNECTION STRING:");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<PredictionService>();
builder.Services.AddScoped<ISpaceObjectService, SpaceObjectService>();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();