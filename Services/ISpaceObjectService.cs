using neoHorizonApi.Models;

namespace neoHorizonApi.Services
{
    public interface ISpaceObjectService
    {
        Task<List<SpaceObject>> GetAllAsync();

        Task<SpaceObject?> GetByIdAsync(int id);

        Task<SpaceObject> CreateAsync(SpaceObject obj);

        Task UpdateAsync(int id, SpaceObject obj);

        Task DeleteAsync(int id);
    }
}
