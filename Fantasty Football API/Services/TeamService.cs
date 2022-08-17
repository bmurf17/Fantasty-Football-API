using Fantasty_Football_API.Data;
using Fantasty_Football_API.Models;

namespace Fantasty_Football_API.Services
{
    public class TeamService : ITeamService
    {
        private ICosmosDbService _cosmosService;
        public TeamService(ICosmosDbService cosmosService)
        {
            _cosmosService = cosmosService;
        }

        public async Task<List<Team>> GetTeams()
        {          
            return await _cosmosService.GetTeams();
        }
    }
}
