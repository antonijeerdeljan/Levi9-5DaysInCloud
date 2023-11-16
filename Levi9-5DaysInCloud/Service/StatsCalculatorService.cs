using Levi9_5DaysInCloud.Dto;
using Levi9_5DaysInCloud.Helper;
using Levi9_5DaysInCloud.IRepository;
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
        private decimal CalculateEffectiveFieldGoalPercentage(TraditionalStats traditional)
        {
            decimal efg = (traditional.twoPoints.made + traditional.threePoints.made + 0.5M * traditional.threePoints.made) / (traditional.twoPoints.atempts + traditional.threePoints.atempts) * 100;
            return efg;
        }
        private decimal CalculateValorization(TraditionalStats traditional)
        {
            decimal valorization = (traditional.freeThrows.made +
                        2M * traditional.twoPoints.made +
                        3M * traditional.threePoints.made +
                        traditional.rebounds +
                        traditional.blocks +
                        traditional.assists +
                        traditional.steals) -
                       (traditional.freeThrows.atempts - traditional.freeThrows.made +
                        traditional.twoPoints.atempts - traditional.twoPoints.made +
                        traditional.threePoints.atempts - traditional.threePoints.made +
                        traditional.turnovers);
            return valorization;

        }

    }
        
}
