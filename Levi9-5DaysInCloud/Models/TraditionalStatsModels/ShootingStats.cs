using System.Security.Cryptography.X509Certificates;

namespace Levi9_5DaysInCloud.Model.TraditionalStatsModel
{
    public class ShootingStats
    {
        private decimal Atempts { get; set; }
        private decimal Made { get; set; }
        private decimal ShootingPercentage { get; set; }

        int RoundForAdvancesStats = 3;

        public decimal atempts
        {
            get => Math.Round(Atempts, RoundForAdvancesStats);
            set => Atempts = Math.Round(value, RoundForAdvancesStats);
        }

        public decimal made
        {
            get => Math.Round(Made, RoundForAdvancesStats);
            set => Made = Math.Round(value, RoundForAdvancesStats);
        }

        public decimal shootingPercentage
        {
            get => Math.Round(ShootingPercentage, RoundForAdvancesStats);
            set => ShootingPercentage = Math.Round(value, RoundForAdvancesStats);
        }

        public virtual ShootingStats GetRounded()
        {
            return new ShootingStats
            {
                Atempts = Math.Round(Atempts, 1),
                Made = Math.Round(Made, 1),
                ShootingPercentage = Math.Round(ShootingPercentage, 1)
            };
        }
    }
}
