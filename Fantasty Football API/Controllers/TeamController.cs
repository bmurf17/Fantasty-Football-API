using Microsoft.AspNetCore.Mvc;
using Fantasty_Football_API.Models;
using Fantasty_Football_API.Services;

namespace Fantasty_Football_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : Controller
    {
        private ITeamService _teamService;

        public TeamController (ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Team>>> Get()
        {
            var teams = await _teamService.GetTeams();
            return Ok(teams);
        }
    }
}
