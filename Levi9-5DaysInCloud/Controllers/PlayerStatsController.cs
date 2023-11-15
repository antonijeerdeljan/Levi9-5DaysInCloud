using Levi9_5DaysInCloud.Dto;
using Levi9_5DaysInCloud.Model;
using Levi9_5DaysInCloud.Model.PlayersModel;
using Levi9_5DaysInCloud.Repository;
using Levi9_5DaysInCloud.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Levi9_5DaysInCloud.Controllers
{
    [ApiController]
    [Route("stats/player")]
    public class PlayerStatsController : ControllerBase
    {
        private readonly ILogger<PlayerStatsController> _logger;
        private readonly StatsCalculatorService statsCalculatorService;
        public PlayerStatsController(ILogger<PlayerStatsController> logger)
        {
            _logger = logger;
            statsCalculatorService= new StatsCalculatorService();
        }


        [HttpGet("{playerFullName}", Name = "GetPlayerStats")]
        public IActionResult GetPlayerStats(string playerFullName)
        {
            PlayersStatsDto playerStats = statsCalculatorService.CalculatePlayersStats(playerFullName);

            if (playerStats == null)
            {
                return NotFound($"Player not found");
            }

            return Ok(playerStats);
        }

    }
}
