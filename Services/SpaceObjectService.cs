using neoHorizonApi.Models;
using neoHorizonApi.Services;
using SpaceApi.Data;
using Microsoft.EntityFrameworkCore;

public class SpaceObjectService : ISpaceObjectService
{
    private readonly AppDbContext _context;

    public SpaceObjectService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<SpaceObject>> GetAllAsync()
    {
        return await _context.SpaceObjects.ToListAsync();
    }

    public async Task<SpaceObject?> GetByIdAsync(int id)
    {
        return await _context.SpaceObjects.FindAsync(id);
    }

    public async Task<SpaceObject> CreateAsync(SpaceObject obj)
    {
        _context.SpaceObjects.Add(obj);
        await _context.SaveChangesAsync();

        return obj;
    }

    public async Task UpdateAsync(int id, SpaceObject obj)
    {
        obj.Id = id;

        _context.SpaceObjects.Update(obj);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.SpaceObjects.FindAsync(id);

        if (entity == null)
            return;

        _context.SpaceObjects.Remove(entity);

        await _context.SaveChangesAsync();
    }
}