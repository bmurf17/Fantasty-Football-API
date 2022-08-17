using Microsoft.AspNetCore.Mvc;
using Fantasty_Football_API.Models;

namespace Fantasty_Football_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : Controller
    {
        [HttpGet]
        public async Task<ActionResult<List<Team>>> Get()
        {
            Player[] players = Array.Empty<Player>();
            List<Team> teams = new List<Team>();
            var team = new Team { Id = 1, Name = "Tyler's League", Path = "tyler", Record = "0-0", Cols=2, Rows=1,  Players= players };
            teams.Add(team);
            return Ok(teams);
        }
    }
}
