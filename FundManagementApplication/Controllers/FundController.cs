using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FundManagementApplication.DataAccess;
using FundManagementApplication.Models;
using FundManagementApplication.Utilities;
using FundManagementApplication.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FundManagementApplication.Controllers {

    [Authorize]
    public class FundController : Controller {
        public AzureDbContext AzureDb { get; }
        public IHttpClientFactory ClientFactory { get; }

        public FundController(AzureDbContext azureDb, IHttpClientFactory clientFactory) {
            AzureDb = azureDb;
            ClientFactory = clientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> ViewFund() {

            var model = new FundViewModel();

            //Setup fund list
            model.Funds = await AzureDb.Funds.GetFundNames(User.Claims.GetIDFromToken());

            return View(model);
        }

        [Produces("application/json")]
        [HttpGet]
        public async Task<IActionResult> DisplayStock(string fundId) {

            if(!User.Identity.IsAuthenticated) return Unauthorized();

            var stocks = await AzureDb.Stock.Where(s => s.FundId == fundId && s.Name != "STI" && s.Name != "DowsJones" && s.Name != "Nasdaq").ToListAsync();
            var result = stocks.GroupBy(s => s.Ticker)
                               .Select(g => g.OrderByDescending(s => s.Date).First());

            foreach(var stock in result) {
                stock.Weight *= 100;
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStockList([FromBody]IEnumerable<StockViewModel> stockModelList) {

            var fundId = stockModelList.First().FundId;

            var stockListFromInput = stockModelList.ConvertIntoStock();

            //Retrieve existing stocks from database
            var unsortedStockListInDb = await AzureDb.Stock.AsNoTracking().Where(s => s.FundId == fundId && s.Name != "STI" && s.Name != "DowsJones" && s.Name != "Nasdaq")
                                                    .ToListAsync();
            var stockListInDb = unsortedStockListInDb.GroupBy(s => s.Ticker)
                                                     .Select(g => g.OrderByDescending(s => s.Date).First());

            //Get ticker from input list
            var stocksTickerFromInput = stockListFromInput.Select(s => s.Ticker);
            //Get ticker from database list
            var stockTickerInDb = stockListInDb.Select(s => s.Ticker);

            //New stocks that are to be added
            var stockToBeAdded = stockListFromInput.Where(s => !stockTickerInDb.Contains(s.Ticker)).ToList();
            foreach(var stock in stockToBeAdded) {
                stock.Date = DateTime.Today;
                stock.Weight = stock.Weight / 100;
                stock.Currency = stock.Currency;
                stock.Industry = stock.Industry;
            }

            //Add new stock
            AzureDb.Stock.AddRange(stockToBeAdded);

            //Filter stock list from database
            var filteredStockGroup = stockListInDb.GroupBy(s => stocksTickerFromInput.Contains(s.Ticker));
            var stockToBeUpdated = new List<Stock>();
            var stockToBeRemoved = new List<Stock>();
            //Assign stock group to their respective list
            foreach(var group in filteredStockGroup) {
                if(group.Key) {
                    stockToBeUpdated.AddRange(group);
                }
                else {
                    stockToBeRemoved.AddRange(group);
                }
            }

            var stockTickerToBeRemoved = stockToBeRemoved.Select(s => s.Ticker);
            stockToBeRemoved = unsortedStockListInDb.Where(s => stockTickerToBeRemoved.Contains(s.Ticker)).ToList();
            //Delete stocks in database
            AzureDb.Stock.RemoveRange(stockToBeRemoved);

            //List of stock to be updated
            var stockTickerToBeUpdated = stockToBeUpdated.Select(s => s.Ticker);
            var stockList = stockListFromInput.Where(s => stockTickerToBeUpdated.Contains(s.Ticker));
            foreach(var stock in stockToBeUpdated) {
                var weight = stockList.Where(s => s.Ticker == stock.Ticker).Select(s => s.Weight).First();
                stock.Weight = weight / 100;
                AzureDb.Stock.Attach(stock);
                AzureDb.Entry(stock).Property(s => s.Weight).IsModified = true;
            }

            await AzureDb.SaveChangesAsync();
            return Ok(stockToBeUpdated);
        }

        [Produces("application/json")]
        [HttpGet]
        public async Task<IActionResult> GetStockList(string fundId, string term) {

            var currency = await AzureDb.Funds.Where(f => f.PkFundId == fundId).Select(f => f.Currency).FirstAsync();
            var stockNames = await AzureDb.Search.AsNoTracking().Where(s => (currency == "SGD" ? s.ExchangeMarket == "SGX" : s.ExchangeMarket != "SGX") && s.StockName.Contains(term)).Select(s => new { value = s.StockName, ticker = s.Ticker, industry = s.Industry, currency = s.ExchangeMarket == "SGX" ? "SGD" : "USD" }).ToListAsync();

            return Ok(stockNames);
        }
    }
}
