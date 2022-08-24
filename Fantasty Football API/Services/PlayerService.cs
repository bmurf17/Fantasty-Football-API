using Fantasty_Football_API.Data;
using Fantasty_Football_API.Models;

namespace Fantasty_Football_API.Services
{
    public class PlayerService : IPlayerService
    {
        private ICosmosDbService _cosmosService;
        public PlayerService(ICosmosDbService cosmosService)
        {
            _cosmosService = cosmosService;
        }

        public async Task<List<Player>> GetPlayers()
        {          
            return await _cosmosService.GetPlayers();
        }
    }
}
