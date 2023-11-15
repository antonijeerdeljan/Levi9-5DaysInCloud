using Levi9_5DaysInCloud.Model.AdvancedStatsModel;
using Levi9_5DaysInCloud.Model.TraditionalStatsModel;

namespace Levi9_5DaysInCloud.Dto
{
    public class PlayersStatsDto
    {
        public string playerName { get; set; }
        public int gamesPlayed { get; set; }
        public TraditionalStats traditional { get; set; }
        public AdvancedStats advanced { get; set; }
    }
}
