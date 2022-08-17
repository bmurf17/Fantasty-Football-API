using Fantasty_Football_API.Models;

namespace Fantasty_Football_API.Services
{
    public interface ITeamService
    {
        public Task<List<Team>> GetTeams();
    }
}
