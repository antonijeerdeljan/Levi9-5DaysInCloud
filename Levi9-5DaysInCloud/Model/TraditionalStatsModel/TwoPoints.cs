namespace Levi9_5DaysInCloud.Model.TraditionalStatsModel
{
    public class TwoPoints : ShootingStats
    {
        public override ShootingStats GetRounded()
        {
            return new TwoPoints
            {
                atempts = Math.Round(atempts, 1),
                made = Math.Round(made, 1),
                shootingPercentage = Math.Round(shootingPercentage, 1)
            };
        }
    }
}
