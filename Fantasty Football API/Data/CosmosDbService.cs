using Fantasty_Football_API.Models;
using Microsoft.Azure.Cosmos;

namespace Fantasty_Football_API.Data
{
    public class CosmosDbService : ICosmosDbService
    {
        private readonly Container _container;
        private readonly IConfigurationSection _configurationSection;
        private string databaseName => _configurationSection.GetSection("DatabaseName").Value;
        private string containerName => _configurationSection.GetSection("ContainerName").Value;

        public CosmosDbService(CosmosClient dbClient, IConfigurationSection configurationSection)
        {
            _configurationSection = configurationSection;
            _container = dbClient.GetContainer(databaseName, containerName);
        }

        public Task<List<Team>> GetTeams()
        {
            var query = new QueryDefinition($"SELECT * FROM C");
            return GetItems(query);
        }


        private async Task<List<Team>> GetItems(QueryDefinition query)
        {
            var results = new List<Team>();
            var iterator = this._container.GetItemQueryIterator<Team>(query);
            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync();
                results.AddRange(response.ToList());
            }

            return results;
        }
    }
}
