using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Microsoft.Extensions.Logging;
using RealPortfolioWebsite.Models;
using RealPortfolioWebsite.Service;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RealPortfolioWebsite.Pages
{
    public class IndexModel : PageModel
    {
        private const string Query = "SELECT * FROM c";
        private readonly ILogger<IndexModel> _logger;
        private readonly ICosmosDbService db;
        private object _cosmosDbService;

        public IndexModel(ILogger<IndexModel> logger, ICosmosDbService IC)
        {
            _logger = logger;
            db = IC;
        }
        public List<PortfolioModel> portfolio { get; set; }
        public async void OnGet()
        {
            //var t = db.AddItemAsync(new PortfolioModel { BlobImg = "https://rpwebsitestorage.blob.core.windows.net/portfolioblobf861f93e-d94a-4b20-82e5-eb87ffe4b4de/ProfilBillede.jpg", Description = "Noget andet", Id = "1" });
            Task<PortfolioModel> s = db.GetItemAsync("1");

            Task<List<PortfolioModel>> r = db.GetItemsAsync(Query);

            portfolio = r.Result;
        }


    }
}
