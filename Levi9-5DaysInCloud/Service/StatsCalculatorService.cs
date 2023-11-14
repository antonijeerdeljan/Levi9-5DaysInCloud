using Levi9_5DaysInCloud.Model.AdvancedStatsModel;
using Levi9_5DaysInCloud.Model.PlayersModel;
using Levi9_5DaysInCloud.Model.TraditionalStatsModel;
using Levi9_5DaysInCloud.Repository;

namespace Levi9_5DaysInCloud.Service
{
    public class StatsCalculatorService
    {
        private static IEnumerable<PlayerPerformanceModel> playerPerformanceModels { get; set; }
        private IEnumerable<PlayerPerformanceModel> onePlayerStats { get; set; }

        public StatsCalculatorService()
        {
            playerPerformanceModels = PlayerPerformanceRepository.MapCsvToPlayerPerformances();
        }

        private IEnumerable<PlayerPerformanceModel> GetPlayersStats(string playerName)
        {
            return onePlayerStats = playerPerformanceModels.Where(p => p.Name == playerName).ToList();
        }

        public PlayerStatsModel CalculatePlayersStats(string playerName)
        {
            PlayerStatsModel playerStatsModel = new PlayerStatsModel();
            playerStatsModel.playerName = playerName;
            playerStatsModel.gamesPlayed = GetPlayersStats(playerName).Count();
            TraditionalStats traditional = CalculateTraditionalStats(onePlayerStats);
            playerStatsModel.traditional = traditional;
            playerStatsModel.advanced = CalculateAdvancedStats(onePlayerStats, traditional);
            return playerStatsModel;
        }

        public AdvancedStats CalculateAdvancedStats(IEnumerable<PlayerPerformanceModel> onePlayerStats,TraditionalStats traditional)
        {
            return new AdvancedStats
            {
                //valorization = CalculateValorization(onePlayerStats),
                Valorization = CalculateValorization(onePlayerStats),
                EffectiveFieldGoalPercentage = CalculateEffectiveFieldGoalPercentage(onePlayerStats),
                TrueShootingPercentage = CalculateTrueShootingPercentage(traditional),
                HollingerAssistRatio = CalculateHollingerAssistRatio(traditional)
            };
        }

        public TraditionalStats CalculateTraditionalStats(IEnumerable<PlayerPerformanceModel> onePlayerStats)
        {
            TraditionalStats traditionalStats = new TraditionalStats
            {
                freeThrows = CalculateFreeThrows(onePlayerStats),
                twoPoints = CalculateTwoPoints(onePlayerStats),
                threePoints = CalculateThreePoints(onePlayerStats),
                points = CalculatePoints(onePlayerStats),
                rebounds = CalculateRebounds(onePlayerStats),
                blocks = CalculateBlocks(onePlayerStats),
                assists = CalculateAssists(onePlayerStats),
                steals = CalculateSteals(onePlayerStats),
                turnovers = CalculateTurnovers(onePlayerStats)
            };

            return traditionalStats;
        }
        private decimal CalculateHollingerAssistRatio(TraditionalStats traditional)
        {
             
             decimal hast = traditional.assists /
                    (traditional.twoPoints.atempts + traditional.threePoints.atempts + 0.475M * traditional.freeThrows.atempts +
                    traditional.assists + traditional.turnovers) * 100;

            return hast;
        }

        private decimal CalculateTrueShootingPercentage(TraditionalStats traditional)
        {
            decimal ts = (traditional.points / (2 * (traditional.twoPoints.atempts + traditional.threePoints.atempts + 0.475M * traditional.freeThrows.atempts)) * 100);

            return ts;
        }


        private decimal CalculateAssists(IEnumerable<PlayerPerformanceModel> onePlayerStats)
        {
            decimal assists = 0;
            foreach (var stats in onePlayerStats)
            {
                assists += stats.Assists;
            }
            return assists / onePlayerStats.Count();
        }

        private decimal CalculateSteals(IEnumerable<PlayerPerformanceModel> onePlayerStats)
        {
            decimal steals = 0;
            foreach (var stats in onePlayerStats)
            {
                steals += stats.Steals;
            }
            return steals / onePlayerStats.Count();
        }

        private decimal CalculateTurnovers(IEnumerable<PlayerPerformanceModel> onePlayerStats)
        {
            decimal turnovers = 0;
            foreach (var stats in onePlayerStats)
            {
                turnovers += stats.Turnovers;
            }
            return turnovers / onePlayerStats.Count();
        }


        private decimal CalculatePoints(IEnumerable<PlayerPerformanceModel> onePlayerStats)
        {
            decimal points = 0;

            foreach (var stats in onePlayerStats)
            {
                points += stats.FreeThrowMade + 2 * stats.TwoPointsMade + 3 * stats.ThreePointsMade;
            }
            return points/onePlayerStats.Count();
        }

        private FreeThrows CalculateFreeThrows(IEnumerable<PlayerPerformanceModel> onePlayerStats)
        {
            FreeThrows freeThrows = new FreeThrows();
            foreach(var stats in onePlayerStats)
            {
                freeThrows.atempts += stats.FreeThrowAttempted;
                freeThrows.made += stats.FreeThrowMade;
            }
            freeThrows.atempts = freeThrows.atempts / onePlayerStats.Count();
            freeThrows.made = freeThrows.made / onePlayerStats.Count();
            freeThrows.shootingPercentage = (freeThrows.made / freeThrows.atempts) * 100;
            return freeThrows;
        }
        private TwoPoints CalculateTwoPoints(IEnumerable<PlayerPerformanceModel> onePlayerStats)
        {
            TwoPoints twoThrows = new TwoPoints();
            foreach (var stats in onePlayerStats)
            {
                twoThrows.atempts += stats.TwoPointsAttempted;
                twoThrows.made += stats.TwoPointsMade;
            }
            twoThrows.atempts = twoThrows.atempts / onePlayerStats.Count();
            twoThrows.made = twoThrows.made / onePlayerStats.Count();
            twoThrows.shootingPercentage = (twoThrows.made / twoThrows.atempts) * 100;
            return twoThrows;
        }
        private ThreePoints CalculateThreePoints(IEnumerable<PlayerPerformanceModel> onePlayerStats)
        {
            ThreePoints threeThrows = new ThreePoints();
            foreach (var stats in onePlayerStats)
            {
                threeThrows.atempts += stats.ThreePointsAttempted;
                threeThrows.made += stats.ThreePointsMade;
            }
            threeThrows.atempts = threeThrows.atempts / onePlayerStats.Count();
            threeThrows.made = threeThrows.made / onePlayerStats.Count();
            threeThrows.shootingPercentage = (threeThrows.made / threeThrows.atempts) * 100;
            return threeThrows;
        }
        private decimal CalculateEffectiveFieldGoalPercentage(IEnumerable<PlayerPerformanceModel> onePlayerStats)
        {
            decimal efg = 0;
            foreach(var stats in onePlayerStats)
            {
                efg += (decimal)(stats.TwoPointsMade + stats.ThreePointsMade + 0.5 * stats.ThreePointsMade) / (stats.TwoPointsAttempted + stats.ThreePointsAttempted) * 100;
            }
            return efg/onePlayerStats.Count();
        }
        private decimal CalculateValorization(IEnumerable<PlayerPerformanceModel> onePlayerStats)
        {
            decimal valorization = 0;
            foreach(var stats in onePlayerStats)
            {
                valorization += (stats.FreeThrowMade + 2 * stats.TwoPointsMade + 3 * stats.ThreePointsMade + stats.Rebounds + stats.Blocks + stats.Assists + stats.Steals) - (stats.FreeThrowAttempted - stats.FreeThrowMade + stats.TwoPointsAttempted - stats.TwoPointsMade + stats.TwoPointsAttempted - stats.TwoPointsMade + stats.Turnovers);
            }
            return valorization/onePlayerStats.Count();

        }
        private decimal CalculateRebounds(IEnumerable<PlayerPerformanceModel> onePlayerStats)
        {
            decimal rebounds = 0;
            foreach (var stats in onePlayerStats)
            {
                rebounds += stats.Rebounds;
            }
            return rebounds / onePlayerStats.Count();
        }
        private decimal CalculateBlocks(IEnumerable<PlayerPerformanceModel> onePlayerStats)
        {
            decimal blocks = 0;
            foreach (var stats in onePlayerStats)
            {
                blocks += stats.Blocks;
            }
            return blocks / onePlayerStats.Count();
        }

    }
        
}
