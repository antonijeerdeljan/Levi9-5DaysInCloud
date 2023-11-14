namespace Levi9_5DaysInCloud.Model.AdvancedStatsModel
{
    public class AdvancedStats
    {
        private decimal valorization { get; set; }
        private decimal effectiveFieldGoalPercentage { get; set; }
        private decimal trueShootingPercentage { get; set; }
        private decimal hollingerAssistRatio { get; set; }

        public decimal Valorization
        {
            get => Math.Round(valorization, 2);
            set => valorization = Math.Round(value, 1);
        }

        public decimal EffectiveFieldGoalPercentage
        {
            get => Math.Round(effectiveFieldGoalPercentage, 2);
            set => effectiveFieldGoalPercentage = Math.Round(value, 1);
        }

        public decimal TrueShootingPercentage
        {
            get => Math.Round(trueShootingPercentage, 2);
            set => trueShootingPercentage = Math.Round(value, 1);
        }

        public decimal HollingerAssistRatio
        {
            get => Math.Round(hollingerAssistRatio, 2);
            set => hollingerAssistRatio = Math.Round(value, 1);
        }
    }
}
