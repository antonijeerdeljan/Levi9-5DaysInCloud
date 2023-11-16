namespace Levi9_5DaysInCloud.Model.TraditionalStatsModel
{
    public class FreeThrows : ShootingStats
    {
        public override ShootingStats GetRounded()
        {
            return new FreeThrows
            {
                atempts = Math.Round(atempts, 1),
                made = Math.Round(made, 1),
                shootingPercentage = Math.Round(shootingPercentage, 1)
            };
        }
    }
}
