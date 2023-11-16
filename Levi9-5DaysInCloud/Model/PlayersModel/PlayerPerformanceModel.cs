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

        public PlayerPerformanceModel()
        {

        }
        public PlayerPerformanceModel(string name, Position position, int freeThrowMade, int freeThrowAttempted, int twoPointsMade, int twoPointsAttempted, int threePointsMade, int threePointsAttempted, int rebounds, int blocks, int assists, int steals, int turnovers)
        {
            Name = name;
            Position = position;
            FreeThrowMade = freeThrowMade;
            FreeThrowAttempted = freeThrowAttempted;
            TwoPointsMade = twoPointsMade;
            TwoPointsAttempted = twoPointsAttempted;
            ThreePointsMade = threePointsMade;
            ThreePointsAttempted = threePointsAttempted;
            Rebounds = rebounds;
            Blocks = blocks;
            Assists = assists;
            Steals = steals;
            Turnovers = turnovers;
        }
    }
}
