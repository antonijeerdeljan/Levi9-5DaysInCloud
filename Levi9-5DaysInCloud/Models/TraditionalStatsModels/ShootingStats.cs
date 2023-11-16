
namespace Levi9_5DaysInCloud.Model.TraditionalStatsModel
{
    public class ShootingStats
    {
        private decimal _attempts;
        private decimal _made;
        private decimal _shootingPercentage;

        int RoundForAdvancesStats = 3;

        public decimal Attempts
        {
            get => Math.Round(_attempts, RoundForAdvancesStats);
            set => _attempts = Math.Round(value, RoundForAdvancesStats);
        }

        public decimal Made
        {
            get => Math.Round(_made, RoundForAdvancesStats);
            set => _made = Math.Round(value, RoundForAdvancesStats);
        }

        public decimal ShootingPercentage
        {
            get => Math.Round(_shootingPercentage, RoundForAdvancesStats);
            set => _shootingPercentage = Math.Round(value, RoundForAdvancesStats);
        }

        public virtual ShootingStats GetRounded()
        {
            return new ShootingStats
            {
                _attempts = Math.Round(_attempts, 1),
                _made = Math.Round(_made, 1),
                _shootingPercentage = Math.Round(_shootingPercentage, 1)
            };
        }
    }
}
