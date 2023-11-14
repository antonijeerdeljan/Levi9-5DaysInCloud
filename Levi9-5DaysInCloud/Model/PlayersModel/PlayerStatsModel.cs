using Levi9_5DaysInCloud.Model.AdvancedStatsModel;
using Levi9_5DaysInCloud.Model.TraditionalStatsModel;
using System.Diagnostics.Contracts;

namespace Levi9_5DaysInCloud.Model.PlayersModel
{
    public class PlayerStatsModel
    {
        public string playerName { get; set; }
        public int gamesPlayed { get; set; }
        public TraditionalStats traditional { get; set; }
        public AdvancedStats advanced { get; set; }
    }
}
