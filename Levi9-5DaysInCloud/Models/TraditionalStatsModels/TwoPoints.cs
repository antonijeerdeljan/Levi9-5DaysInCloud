namespace Levi9_5DaysInCloud.Model.TraditionalStatsModel
{
    public class TwoPoints : ShootingStats
    {
        public override ShootingStats GetRounded()
        {
            return new TwoPoints
            {
                Attempts = Math.Round(Attempts, 1),
                Made = Math.Round(Made, 1),
                ShootingPercentage = Math.Round(ShootingPercentage, 1)
            };
        }
    }
}
