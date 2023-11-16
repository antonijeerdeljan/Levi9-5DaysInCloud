namespace Levi9_5DaysInCloud.Model.TraditionalStatsModel
{
    public class ThreePoints : ShootingStats
    {
        public override ShootingStats GetRounded()
        {
            return new ThreePoints
            {
                Attempts = Math.Round(Attempts, 1),
                Made = Math.Round(Made, 1),
                ShootingPercentage = Math.Round(ShootingPercentage, 1)
            };
        }

    }
}
