using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealPortfolioWebsite.Models;

namespace RealPortfolioWebsite.Service
{
    public interface ICosmosDbService
    {
        Task<List<PortfolioModel>> GetItemsAsync(string query);
        Task<PortfolioModel> GetItemAsync(string id);
        Task AddItemAsync(PortfolioModel item);
        Task UpdateItemAsync(string id, PortfolioModel item);
        Task DeleteItemAsync(string id);
    }
}
