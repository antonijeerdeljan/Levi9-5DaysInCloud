using Levi9_5DaysInCloud.Model.PlayersModel;

namespace Levi9_5DaysInCloud.Repository
{
    public interface IPlayerPerformanceRepository
    {
        public IReadOnlyList<PlayerPerformanceModel> MapCsvToPlayerPerformances();
    }
}
