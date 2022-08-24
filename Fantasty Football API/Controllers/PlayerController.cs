using Microsoft.AspNetCore.Mvc;
using Fantasty_Football_API.Models;
using Fantasty_Football_API.Services;

namespace Fantasty_Football_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : Controller
    {
        private IPlayerService _playerService;

        public PlayerController(IPlayerService teamService)
        {
            _playerService = teamService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Player>>> Get()
        {
            var teams = await _playerService.GetPlayers();
            return Ok(teams);
        }
    }
}
