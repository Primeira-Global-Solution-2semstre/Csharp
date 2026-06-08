using Microsoft.AspNetCore.Mvc;
using neoHorizonApi.Models;
using neoHorizonApi.Services;

[ApiController]
[Route("api/spaceobjects")]
public class SpaceObjectController : ControllerBase
{
    private readonly ISpaceObjectService _service;

    public SpaceObjectController(ISpaceObjectService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<List<SpaceObject>> GetAll()
    {
        return await _service.GetAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SpaceObject>> GetById(int id)
    {
        var obj = await _service.GetByIdAsync(id);

        if (obj == null)
            return NotFound();

        return Ok(obj);
    }

    [HttpPost]
    public async Task<ActionResult<SpaceObject>> Create(SpaceObject obj)
    {
        var created = await _service.CreateAsync(obj);

        return CreatedAtAction(nameof(GetById),
            new { id = created.Id },
            created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, SpaceObject obj)
    {
        await _service.UpdateAsync(id, obj);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);

        return NoContent();
    }
}