using Microsoft.Azure.Cosmos;

namespace Fantasty_Football_API.Data
{
    public class ConfigCosmos
    {
        public static CosmosDbService InitializeCosmosDbClient(IConfiguration _configuration)
        {
            var setting = _configuration.GetSection("CosmosSetting");
            string endpoint = setting.GetSection("Endpoint").Value;
            string cosmosApiKey = setting.GetSection("ApiKey").Value;
                
            CosmosClient cosmosClient = new CosmosClient(endpoint, cosmosApiKey);
            var cosmosDbService = new CosmosDbService(cosmosClient, _configuration.GetSection("CosmosSetting"));
            return cosmosDbService;
        }
    }
}
