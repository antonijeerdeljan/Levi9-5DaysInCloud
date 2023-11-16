using Levi9_5DaysInCloud.Model.AdvancedStatsModel;
using Levi9_5DaysInCloud.Model.TraditionalStatsModel;

namespace Levi9_5DaysInCloud.Dto
{
    public class PlayersStatsDto
    {
        public string PlayerName { get; set; }
        public int GamesPlayed { get; set; }
        public TraditionalStats Traditional { get; set; }
        public AdvancedStats Advanced { get; set; }
    }
}
