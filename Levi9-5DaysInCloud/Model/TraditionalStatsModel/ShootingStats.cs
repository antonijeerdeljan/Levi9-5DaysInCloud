namespace Levi9_5DaysInCloud.Model.TraditionalStatsModel
{
    public class ShootingStats
    {
        private decimal Atempts { get; set; }
        private decimal Made { get; set; }
        private decimal ShootingPercentage { get; set; }

        public decimal atempts
        {
            get => Math.Round(Atempts,2);
            set => Atempts = Math.Round(value, 1);
        }

        public decimal made
        {
            get => Math.Round(Made, 2);
            set => Made = Math.Round(value, 1);
        }

        public decimal shootingPercentage
        {
            get => Math.Round(ShootingPercentage, 2);
            set => ShootingPercentage = Math.Round(value, 1);
        }
    }
}
