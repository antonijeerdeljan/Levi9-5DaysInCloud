using Levi9_5DaysInCloud.Model.PlayersModel;

namespace Levi9_5DaysInCloud.IRepository
{
    public interface IPlayerPerformanceRepository
    {
        public IEnumerable<PlayerPerformanceModel> MapCsvToPlayerPerformances();
    }
}
