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
        int RoundForAdvancesStats = 3;

        public decimal points
        {
            get => Math.Round(Points, RoundForAdvancesStats);
            set => Points = Math.Round(value, RoundForAdvancesStats);
        }
        public decimal rebounds
        {
            get => Math.Round(Rebounds, RoundForAdvancesStats);
            set => Rebounds = Math.Round(value, RoundForAdvancesStats);
        }
        public decimal blocks
        {
            get => Math.Round(Blocks, RoundForAdvancesStats);
            set => Blocks = Math.Round(value, RoundForAdvancesStats);
        }
        public decimal assists
        {
            get => Math.Round(Assists, RoundForAdvancesStats);
            set => Assists = Math.Round(value, RoundForAdvancesStats);
        }
        public decimal steals
        {
            get => Math.Round(Steals, RoundForAdvancesStats);
            set => Steals = Math.Round(value, RoundForAdvancesStats);
        }
        public decimal turnovers
        {
            get => Math.Round(Turnovers, RoundForAdvancesStats);
            set => Turnovers = Math.Round(value, RoundForAdvancesStats);
        }

    }
}
