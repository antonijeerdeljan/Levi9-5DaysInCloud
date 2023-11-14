using Levi9_5DaysInCloud.Enum;

namespace Levi9_5DaysInCloud.Model.PlayersModel
{
    public class PlayerPerformanceModel
    {
        public string Name { get; set; }
        public Position Position { get; set; }
        public int FreeThrowMade { get; set; }
        public int FreeThrowAttempted { get; set; }
        public int TwoPointsMade { get; set; }
        public int TwoPointsAttempted { get; set; }
        public int ThreePointsMade { get; set; }
        public int ThreePointsAttempted { get; set; }
        public int Rebounds { get; set; }
        public int Blocks { get; set; }
        public int Assists { get; set; }
        public int Steals { get; set; }
        public int Turnovers { get; set; }
    }
}
