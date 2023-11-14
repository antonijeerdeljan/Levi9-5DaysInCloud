namespace Levi9_5DaysInCloud.Model.TraditionalStatsModel
{
    public class TraditionalStats
    {
        public FreeThrows freeThrows { get; set; }
        public TwoPoints twoPoints { get; set; }
        public ThreePoints threePoints { get; set; }
        private decimal Points { get; set; }
        private decimal Rebounds { get; set; }
        private decimal Blocks { get; set; }
        private decimal Assists { get; set; }
        private decimal Steals { get; set; }
        private decimal Turnovers { get; set; }

        public decimal points
        {
            get => Math.Round(Points, 2);
            set => Points = Math.Round(value, 1);
        }
        public decimal rebounds
        {
            get => Math.Round(Rebounds, 2);
            set => Rebounds = Math.Round(value, 1);
        }
        public decimal blocks
        {
            get => Math.Round(Blocks, 2);
            set => Blocks = Math.Round(value, 1);
        }
        public decimal assists
        {
            get => Math.Round(Assists, 2);
            set => Assists = Math.Round(value, 1);
        }
        public decimal steals
        {
            get => Math.Round(Steals, 2);
            set => Steals = Math.Round(value, 1);
        }
        public decimal turnovers
        {
            get => Math.Round(Turnovers, 2);
            set => Turnovers = Math.Round(value, 1);
        }

    }
}
