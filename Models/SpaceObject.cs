namespace neoHorizonApi.Models
{
    public class SpaceObject
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public double VelocityX { get; set; }

        public double VelocityY { get; set; }

        public double VelocityZ { get; set; }

        public double Radius { get; set; }

        public List<PredictionsMade> Predictions { get; set; } = new();
    }
}
