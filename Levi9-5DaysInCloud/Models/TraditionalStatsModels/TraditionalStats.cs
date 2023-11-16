namespace Levi9_5DaysInCloud.Model.TraditionalStatsModel
{
    public class TraditionalStats
    {
        public FreeThrows FreeThrows { get; set; }
        public TwoPoints TwoPoints { get; set; }
        public ThreePoints ThreePoints { get; set; }

        private decimal _points;
        private decimal _rebounds;
        private decimal _blocks;
        private decimal _assists;
        private decimal _steals;
        private decimal _turnovers;

        private const int ROUND_FOR_ADVANCED_STATS = 3;

        public decimal Points
        {
            get => Math.Round(_points, ROUND_FOR_ADVANCED_STATS);
            set => _points = Math.Round(value, ROUND_FOR_ADVANCED_STATS);
        }
        public decimal Rebounds
        {
            get => Math.Round(_rebounds, ROUND_FOR_ADVANCED_STATS);
            set => _rebounds = Math.Round(value, ROUND_FOR_ADVANCED_STATS);
        }
        public decimal Blocks
        {
            get => Math.Round(_blocks, ROUND_FOR_ADVANCED_STATS);
            set => _blocks = Math.Round(value, ROUND_FOR_ADVANCED_STATS);
        }
        public decimal Assists
        {
            get => Math.Round(_assists, ROUND_FOR_ADVANCED_STATS);
            set => _assists = Math.Round(value, ROUND_FOR_ADVANCED_STATS);
        }
        public decimal Steals
        {
            get => Math.Round(_steals, ROUND_FOR_ADVANCED_STATS);
            set => _steals = Math.Round(value, ROUND_FOR_ADVANCED_STATS);
        }
        public decimal Turnovers
        {
            get => Math.Round(_turnovers, ROUND_FOR_ADVANCED_STATS);
            set => _turnovers = Math.Round(value, ROUND_FOR_ADVANCED_STATS);
        }

    }
}
