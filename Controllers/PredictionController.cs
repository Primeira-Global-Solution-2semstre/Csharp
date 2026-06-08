using Microsoft.AspNetCore.Mvc;
using neoHorizonApi.Services;

namespace neoHorizonApi.Controllers
{
    [ApiController]
    [Route("api/predictions")]
    public class PredictionController : ControllerBase
    {
        private readonly PredictionService _service;

        public PredictionController(PredictionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<CollisionPrediction>> GetPredictions()
        {
            return await _service.PredictCollisions();
        }
    }
}
