using Fantasty_Football_API.Models;
using Microsoft.Azure.Cosmos;

namespace Fantasty_Football_API.Data
{
    public class CosmosDbService : ICosmosDbService
    {
        private readonly Container _teamContainer;
        private readonly Container _playerContainer;
        private readonly IConfigurationSection _configurationSection;
        private string databaseName => _configurationSection.GetSection("DatabaseName").Value;
        private string teamContainerName => _configurationSection.GetSection("TeamContainerName").Value;
        private string playerContainerName => _configurationSection.GetSection("PlayerContainerName").Value;

        public CosmosDbService(CosmosClient dbClient, IConfigurationSection configurationSection)
        {
            _configurationSection = configurationSection;
            _teamContainer = dbClient.GetContainer(databaseName, teamContainerName);
            _playerContainer = dbClient.GetContainer(databaseName, playerContainerName);
        }

        public Task<List<Team>> GetTeams()
        {
            var query = new QueryDefinition($"SELECT * FROM C");
            return GetItems(query, _teamContainer);
        }

        public Task<List<Player>> GetPlayers()
        {
            var query = new QueryDefinition($"SELECT * FROM C");
            return GetItemsPlayers(query, _playerContainer);
        }

        private async Task<List<Player>> GetItemsPlayers(QueryDefinition query, Container container)
        {
            var results = new List<Player>();
            var iterator = container.GetItemQueryIterator<Player>(query);
            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync();
                results.AddRange(response.ToList());
            }

            return results;
        }

        private async Task<List<Team>> GetItems(QueryDefinition query, Container container)
        {
            var results = new List<Team>();
            var iterator = container.GetItemQueryIterator<Team>(query);
            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync();
                results.AddRange(response.ToList());
            }

            return results;
        }
    }
}
