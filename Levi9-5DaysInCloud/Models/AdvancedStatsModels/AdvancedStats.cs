using Levi9_5DaysInCloud.Model.TraditionalStatsModel;

namespace Levi9_5DaysInCloud.Model.AdvancedStatsModel
{
    public class AdvancedStats
    {
        private decimal valorization;
        private decimal effectiveFieldGoalPercentage;
        private decimal trueShootingPercentage;
        private decimal hollingerAssistRatio;

        public decimal Valorization
        {
            get => Math.Round(valorization, 3);
            set => valorization = Math.Round(value, 3);
        }

        public decimal EffectiveFieldGoalPercentage
        {
            get => Math.Round(effectiveFieldGoalPercentage, 3);
            set => effectiveFieldGoalPercentage = Math.Round(value, 3);
        }

        public decimal TrueShootingPercentage
        {
            get => Math.Round(trueShootingPercentage, 3);
            set => trueShootingPercentage = Math.Round(value, 3);
        }

        public decimal HollingerAssistRatio
        {
            get => Math.Round(hollingerAssistRatio, 3);
            set => hollingerAssistRatio = Math.Round(value, 3);
        }

        public AdvancedStats GetRounded()
        {
            return new AdvancedStats
            {
                Valorization = Math.Round(Valorization, 1),
                EffectiveFieldGoalPercentage = Math.Round(EffectiveFieldGoalPercentage, 1),
                TrueShootingPercentage = Math.Round(TrueShootingPercentage, 1),
                HollingerAssistRatio = Math.Round(HollingerAssistRatio, 1),
            };
        }
    }
}
