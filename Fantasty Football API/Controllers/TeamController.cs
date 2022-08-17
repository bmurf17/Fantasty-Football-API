using Microsoft.AspNetCore.Mvc;
using Fantasty_Football_API.Models;

namespace Fantasty_Football_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : Controller
    {
        [HttpGet]
        public async Task<ActionResult<Team>> Get()
        {
            var team = new Team { Id = 1, Name = "Tyler's League", Record = "0-0", Path="tyler" };
            return Ok(team);
        }
    }
}
