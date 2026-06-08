namespace neoHorizonApi.Models
{
    public class PredictionsMade
    {
        public int Id { get; set; }

        public short IsGoingToCollide { get; set; }

        public long TimeUntilImpact { get; set; }

        public List<SpaceObject> ObjectsInvolved { get; set; } = new();
    }
}
