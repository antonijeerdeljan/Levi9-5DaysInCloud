using Levi9_5DaysInCloud.Dto;
using Levi9_5DaysInCloud.Model.PlayersModel;
using Levi9_5DaysInCloud.Model.TraditionalStatsModel;

namespace Levi9_5DaysInCloud.Common
{
    public static class Mapper
    {
        public static PlayersStatsDto ReturnPlayerDto(PlayerStatsModel playerStatsModel)
        {
            if (playerStatsModel == null)
            {
                throw new ArgumentNullException(nameof(playerStatsModel));
            }

            PlayersStatsDto playersStatsDto = new PlayersStatsDto
            {
                PlayerName = playerStatsModel.PlayerName,
                GamesPlayed = playerStatsModel.GamesPlayed,
                Traditional = playerStatsModel.Traditional,
                Advanced = playerStatsModel.Advanced,
            };
            try
            {
                if (playersStatsDto.Traditional != null && playersStatsDto.Traditional.FreeThrows != null)
                {
                    playersStatsDto.Traditional.FreeThrows = (FreeThrows)playersStatsDto.Traditional.FreeThrows.GetRounded();
                    playersStatsDto.Traditional.TwoPoints = (TwoPoints)playersStatsDto.Traditional.TwoPoints.GetRounded();
                    playersStatsDto.Traditional.ThreePoints = (ThreePoints)playersStatsDto.Traditional.ThreePoints.GetRounded();
                    playersStatsDto.Traditional.Points = Math.Round(playersStatsDto.Traditional.Points, 1);
                    playersStatsDto.Traditional.Rebounds = Math.Round(playersStatsDto.Traditional.Rebounds, 1);
                    playersStatsDto.Traditional.Blocks = Math.Round(playersStatsDto.Traditional.Blocks, 1);
                    playersStatsDto.Traditional.Assists = Math.Round(playersStatsDto.Traditional.Assists, 1);
                    playersStatsDto.Traditional.Steals = Math.Round(playersStatsDto.Traditional.Steals, 1);
                    playersStatsDto.Traditional.Turnovers = Math.Round(playersStatsDto.Traditional.Turnovers, 1);
                    playersStatsDto.Advanced = playersStatsDto.Advanced.GetRounded();
                }
            }
            catch (Exception ex)
            {
                // Catch any other unexpected exceptions
                // Logging or handling other exceptions can go here
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

            return playersStatsDto;
        }
    }
}
