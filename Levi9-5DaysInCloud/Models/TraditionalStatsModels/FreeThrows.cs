namespace Levi9_5DaysInCloud.Model.TraditionalStatsModel
{
    public class FreeThrows : ShootingStats
    {
        public override ShootingStats GetRounded()
        {
            return new FreeThrows
            {
                Attempts = Math.Round(Attempts, 1),
                Made = Math.Round(Made, 1),
                ShootingPercentage = Math.Round(ShootingPercentage, 1)
            };
        }
    }
}
