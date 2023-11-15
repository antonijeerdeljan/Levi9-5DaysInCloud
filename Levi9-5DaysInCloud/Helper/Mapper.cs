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
                playerName = playerStatsModel.playerName,
                gamesPlayed = playerStatsModel.gamesPlayed,
                traditional = playerStatsModel.traditional,
                advanced = playerStatsModel.advanced,
            };
            try
            {
                if (playersStatsDto.traditional != null && playersStatsDto.traditional.freeThrows != null)
                {
                    playersStatsDto.traditional.freeThrows = (FreeThrows)playersStatsDto.traditional.freeThrows.GetRounded();
                    playersStatsDto.traditional.twoPoints = (TwoPoints)playersStatsDto.traditional.twoPoints.GetRounded();
                    playersStatsDto.traditional.threePoints = (ThreePoints)playersStatsDto.traditional.threePoints.GetRounded();
                    playersStatsDto.traditional.points = Math.Round(playersStatsDto.traditional.points, 1);
                    playersStatsDto.traditional.rebounds = Math.Round(playersStatsDto.traditional.rebounds, 1);
                    playersStatsDto.traditional.blocks = Math.Round(playersStatsDto.traditional.blocks, 1);
                    playersStatsDto.traditional.assists = Math.Round(playersStatsDto.traditional.assists, 1);
                    playersStatsDto.traditional.steals = Math.Round(playersStatsDto.traditional.steals, 1);
                    playersStatsDto.traditional.turnovers = Math.Round(playersStatsDto.traditional.turnovers, 1);
                    playersStatsDto.advanced = playersStatsDto.advanced.GetRounded();
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
