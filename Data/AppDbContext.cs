using Microsoft.EntityFrameworkCore;
using neoHorizonApi.Models;

namespace SpaceApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
       : base(options)
    {
    }

    public DbSet<SpaceObject> SpaceObjects { get; set; }
}