using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealPortfolioWebsite.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Configuration;
using RealPortfolioWebsite.Service;

public class CosmosDbService : ICosmosDbService
{
    private Container _container;

    public CosmosDbService(
        CosmosClient dbClient,
        string databaseName,
        string containerName)
    {
        this._container = dbClient.GetContainer(databaseName, containerName);
    }

    public async Task AddItemAsync(PortfolioModel item)
    {
        await this._container.CreateItemAsync<PortfolioModel>(item, new PartitionKey(item.Id));
    }

    public async Task DeleteItemAsync(string id)
    {
        await this._container.DeleteItemAsync<PortfolioModel>(id, new PartitionKey(id));
    }

    public async Task<PortfolioModel> GetItemAsync(string id)
    {
        try
        {
            ItemResponse<PortfolioModel> response = await this._container.ReadItemAsync<PortfolioModel>(id, new PartitionKey(id));
            return response.Resource;
        }
        catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return null;
        }

    }

    public async Task<List<PortfolioModel>> GetItemsAsync(string queryString)
    {
        var query = this._container.GetItemQueryIterator<PortfolioModel>(new QueryDefinition(queryString));
        List<PortfolioModel> results = new List<PortfolioModel>();
        while (query.HasMoreResults)
        {
            var response = await query.ReadNextAsync();

            results.AddRange(response.ToList());
        }

        return results;
    }

    public async Task UpdateItemAsync(string id, PortfolioModel item)
    {
        await this._container.UpsertItemAsync<PortfolioModel>(item, new PartitionKey(id));
    }
}
