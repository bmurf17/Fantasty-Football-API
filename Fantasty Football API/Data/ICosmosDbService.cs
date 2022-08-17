using Fantasty_Football_API.Models;

namespace Fantasty_Football_API.Data
{
    public interface ICosmosDbService
    {
        public Task<List<Team>> GetTeams();
    }
}
