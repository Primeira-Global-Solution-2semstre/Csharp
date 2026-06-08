using SpaceApi.Data;
using Microsoft.EntityFrameworkCore;

namespace neoHorizonApi.Services
{
    public class PredictionService
    {
        private readonly AppDbContext _context;

        public PredictionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CollisionPrediction>> PredictCollisions()
        {
            var objects = await _context.SpaceObjects.ToListAsync();

            var predictions = new List<CollisionPrediction>();

            for (int i = 0; i < objects.Count; i++)
            {
                for (int j = i + 1; j < objects.Count; j++)
                {
                    var a = objects[i];
                    var b = objects[j];

                    double futureAx = a.X + a.VelocityX * 60;
                    double futureAy = a.Y + a.VelocityY * 60;
                    double futureAz = a.Z + a.VelocityZ * 60;

                    double futureBx = b.X + b.VelocityX * 60;
                    double futureBy = b.Y + b.VelocityY * 60;
                    double futureBz = b.Z + b.VelocityZ * 60;

                    double distance = Math.Sqrt(
                        Math.Pow(futureAx - futureBx, 2)
                        + Math.Pow(futureAy - futureBy, 2)
                        + Math.Pow(futureAz - futureBz, 2));

                    bool collision =
                        distance <= (a.Radius + b.Radius);

                    predictions.Add(new CollisionPrediction
                    {
                        ObjectA = a.Name,
                        ObjectB = b.Name,
                        Distance = distance,
                        WillCollide = collision
                    });
                }
            }

            return predictions;
        }
    }
}
