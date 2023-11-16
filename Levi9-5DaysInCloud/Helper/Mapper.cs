using Levi9_5DaysInCloud.Dto;
using Levi9_5DaysInCloud.Model.PlayersModel;
using Levi9_5DaysInCloud.Model.TraditionalStatsModel;

namespace Levi9_5DaysInCloud.Helper
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
                if (playersStatsDto.Traditional != null && playersStatsDto.Traditional.freeThrows != null)
                {
                    playersStatsDto.Traditional.freeThrows = (FreeThrows)playersStatsDto.Traditional.freeThrows.GetRounded();
                    playersStatsDto.Traditional.twoPoints = (TwoPoints)playersStatsDto.Traditional.twoPoints.GetRounded();
                    playersStatsDto.Traditional.threePoints = (ThreePoints)playersStatsDto.Traditional.threePoints.GetRounded();
                    playersStatsDto.Traditional.points = Math.Round(playersStatsDto.Traditional.points, 1);
                    playersStatsDto.Traditional.rebounds = Math.Round(playersStatsDto.Traditional.rebounds, 1);
                    playersStatsDto.Traditional.blocks = Math.Round(playersStatsDto.Traditional.blocks, 1);
                    playersStatsDto.Traditional.assists = Math.Round(playersStatsDto.Traditional.assists, 1);
                    playersStatsDto.Traditional.steals = Math.Round(playersStatsDto.Traditional.steals, 1);
                    playersStatsDto.Traditional.turnovers = Math.Round(playersStatsDto.Traditional.turnovers, 1);
                    playersStatsDto.Advanced = playersStatsDto.Advanced.GetRounded();
                }
            }catch(Exception ex)
            {
                // Catch any other unexpected exceptions
                // Logging or handling other exceptions can go here
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

            return playersStatsDto;
        }
    }
}
