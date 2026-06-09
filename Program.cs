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

var retries = 30;

while (retries > 0)
{
    try
    {
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        Console.WriteLine("Running migrations...");
        db.Database.Migrate();
        Console.WriteLine("Migrations completed.");

        break;
    }
    catch (Exception ex)
    {
        retries--;

        Console.WriteLine($"Oracle not ready yet. Retries left: {retries}");
        Console.WriteLine(ex.Message);

        Thread.Sleep(10000); // 10 seconds
    }
}
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();