using Levi9_5DaysInCloud.Dto;
using Levi9_5DaysInCloud.IRepository;
using Levi9_5DaysInCloud.Model.PlayersModel;
using Levi9_5DaysInCloud.Service;
using NSubstitute;

namespace UnitTests
{
    public class PlayerStatsTests
    {
        public StatsCalculatorService StatsCalculatorService;

        public PlayerStatsTests()
        {
            var mockedRepo = Substitute.For<IPlayerPerformanceRepository>();
            mockedRepo.MapCsvToPlayerPerformances().Returns(new List<PlayerPerformanceModel> { new PlayerPerformanceModel("Tunde Nathi", Levi9_5DaysInCloud.Enum.Position.C,2,4,6,8,6,8,4,2,1,0,2),
                                                                                               new PlayerPerformanceModel("Tunde Nathi", Levi9_5DaysInCloud.Enum.Position.C,6,7,3,4,3,4,7,1,1,0,1)});
            StatsCalculatorService = new StatsCalculatorService(mockedRepo);
        }
        
        [Fact]
        public void CalculateAdvancedStats()
        {
            PlayersStatsDto result = StatsCalculatorService.CalculatePlayersStats("Tunde Nathi");
            Assert.Equal(typeof(PlayersStatsDto), result.GetType());
            Assert.Equal((decimal)93.8, result.Advanced.EffectiveFieldGoalPercentage);
            Assert.Equal((decimal)28.5, result.Advanced.Valorization);
            Assert.Equal((decimal)5.8, result.Advanced.HollingerAssistRatio);
            Assert.Equal((decimal)90.7, result.Advanced.TrueShootingPercentage);
        }






    }
}