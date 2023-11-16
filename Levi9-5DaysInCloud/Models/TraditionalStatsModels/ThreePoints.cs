namespace Levi9_5DaysInCloud.Model.TraditionalStatsModel
{
    public class ThreePoints : ShootingStats
    {
        public override ShootingStats GetRounded()
        {
            return new ThreePoints
            {
                atempts = Math.Round(atempts, 1),
                made = Math.Round(made, 1),
                shootingPercentage = Math.Round(shootingPercentage, 1)
            };
        }

    }
}
