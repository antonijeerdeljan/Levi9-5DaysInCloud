using Levi9_5DaysInCloud.Common;
using Levi9_5DaysInCloud.Dto;
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

        private readonly IPlayerPerformanceRepository playerPerformanceRepository;

        public StatsCalculatorService(IPlayerPerformanceRepository playerPerformance)
        {
            playerPerformanceRepository = playerPerformance;
            playerPerformanceModels = playerPerformanceRepository.MapCsvToPlayerPerformances();
        }

        private IEnumerable<PlayerPerformanceModel> GetPlayersStats(string playerName)
        {
           return onePlayerStats = playerPerformanceModels.Where(p => p.Name == playerName).ToList();
        }    

        public PlayersStatsDto CalculatePlayersStats(string playerName)
        {
            PlayerStatsModel playerStatsModel = new PlayerStatsModel();
            playerStatsModel.PlayerName = playerName;
            playerStatsModel.GamesPlayed = GetPlayersStats(playerName).Count();
            if (playerStatsModel.GamesPlayed == 0)
                return null;
            TraditionalStats traditional = CalculateTraditionalStats(onePlayerStats);
            playerStatsModel.Traditional = traditional;
            //Traditional.RoundDataForAdvancesStats();
            playerStatsModel.Advanced = CalculateAdvancedStats(onePlayerStats, traditional);
            return Mapper.ReturnPlayerDto(playerStatsModel);
        }

        public AdvancedStats CalculateAdvancedStats(IEnumerable<PlayerPerformanceModel> onePlayerStats,TraditionalStats traditional)
        {
            return new AdvancedStats
            {
                Valorization = CalculateValorization(traditional),
                EffectiveFieldGoalPercentage = CalculateEffectiveFieldGoalPercentage(traditional),
                TrueShootingPercentage = CalculateTrueShootingPercentage(traditional),
                HollingerAssistRatio = CalculateHollingerAssistRatio(traditional)
            };
        }

        public TraditionalStats CalculateTraditionalStats(IEnumerable<PlayerPerformanceModel> onePlayerStats)
        {
            TraditionalStats traditionalStats = new TraditionalStats
            {
                FreeThrows = CalculateFreeThrows(onePlayerStats),
                TwoPoints = CalculateTwoPoints(onePlayerStats),
                ThreePoints = CalculateThreePoints(onePlayerStats),
                Points = CalculatePoints(onePlayerStats),
                Rebounds = CalculateRebounds(onePlayerStats),
                Blocks = CalculateBlocks(onePlayerStats),
                Assists = CalculateAssists(onePlayerStats),
                Steals = CalculateSteals(onePlayerStats),
                Turnovers = CalculateTurnovers(onePlayerStats)
            };

            return traditionalStats;
        }
        private FreeThrows CalculateFreeThrows(IEnumerable<PlayerPerformanceModel> onePlayerStats)
        {
            FreeThrows freeThrows = new FreeThrows();
            foreach(var stats in onePlayerStats)
            {
                freeThrows.Attempts += stats.FreeThrowAttempted;
                freeThrows.Made += stats.FreeThrowMade;
            }
            freeThrows.Attempts = freeThrows.Attempts / onePlayerStats.Count();
            freeThrows.Made = freeThrows.Made / onePlayerStats.Count();
            freeThrows.ShootingPercentage = (freeThrows.Made / freeThrows.Attempts) * 100;
            return freeThrows;
        }
        private TwoPoints CalculateTwoPoints(IEnumerable<PlayerPerformanceModel> onePlayerStats)
        {
            TwoPoints twoThrows = new TwoPoints();
            foreach (var stats in onePlayerStats)
            {
                twoThrows.Attempts += stats.TwoPointsAttempted;
                twoThrows.Made += stats.TwoPointsMade;
            }
            twoThrows.Attempts = twoThrows.Attempts / onePlayerStats.Count();
            twoThrows.Made = twoThrows.Made / onePlayerStats.Count();
            twoThrows.ShootingPercentage = (twoThrows.Made / twoThrows.Attempts) * 100;
            return twoThrows;
        }
        private ThreePoints CalculateThreePoints(IEnumerable<PlayerPerformanceModel> onePlayerStats)
        {
            ThreePoints threeThrows = new ThreePoints();
            foreach (var stats in onePlayerStats)
            {
                threeThrows.Attempts += stats.ThreePointsAttempted;
                threeThrows.Made += stats.ThreePointsMade;
            }
            threeThrows.Attempts = threeThrows.Attempts / onePlayerStats.Count();
            threeThrows.Made = threeThrows.Made / onePlayerStats.Count();
            threeThrows.ShootingPercentage = (threeThrows.Made / threeThrows.Attempts) * 100;
            return threeThrows;
        }
        private decimal CalculatePoints(IEnumerable<PlayerPerformanceModel> onePlayerStats)
        {
            decimal points = 0;

            foreach (var stats in onePlayerStats)
            {
                points += stats.FreeThrowMade + 2 * stats.TwoPointsMade + 3 * stats.ThreePointsMade;
            }
            
            points = Math.Round(points/onePlayerStats.Count(),3);
            return points;
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

        private decimal CalculateHollingerAssistRatio(TraditionalStats traditional)
        {
             
             decimal hast = traditional.Assists /
                    (traditional.TwoPoints.Attempts + traditional.ThreePoints.Attempts + 0.475M * traditional.FreeThrows.Attempts +
                    traditional.Assists + traditional.Turnovers) * 100;

            return hast;
        }
        private decimal CalculateTrueShootingPercentage(TraditionalStats traditional)
        {
            decimal ts = (traditional.Points / (2 * (traditional.TwoPoints.Attempts + traditional.ThreePoints.Attempts + 0.475M * traditional.FreeThrows.Attempts)) * 100);

            return ts;
        }
        private decimal CalculateEffectiveFieldGoalPercentage(TraditionalStats traditional)
        {
            decimal efg = (traditional.TwoPoints.Made + traditional.ThreePoints.Made + 0.5M * traditional.ThreePoints.Made) / (traditional.TwoPoints.Attempts + traditional.ThreePoints.Attempts) * 100;
            return efg;
        }
        private decimal CalculateValorization(TraditionalStats traditional)
        {
            decimal valorization = (traditional.FreeThrows.Made +
                        2M * traditional.TwoPoints.Made +
                        3M * traditional.ThreePoints.Made +
                        traditional.Rebounds +
                        traditional.Blocks +
                        traditional.Assists +
                        traditional.Steals) -
                       (traditional.FreeThrows.Attempts - traditional.FreeThrows.Made +
                        traditional.TwoPoints.Attempts - traditional.TwoPoints.Made +
                        traditional.ThreePoints.Attempts - traditional.ThreePoints.Made +
                        traditional.Turnovers);
            return valorization;

        }

    }
        
}
