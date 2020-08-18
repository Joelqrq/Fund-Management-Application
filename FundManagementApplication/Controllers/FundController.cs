using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        public async Task<IActionResult> EditFund() {

            var model = new FundViewModel();

            //Setup fund list
            model.Funds = await AzureDb.Funds.GetFundNames(User.Claims.GetIDFromToken());

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetStaticStockList(string fundId) {

            var listOfStock = fundId == "PRES_01" ? StaticListOfStocks.PrestigeStaticListOfStocks : StaticListOfStocks.GlobalStaticListOfStocks;

            return Json(listOfStock);
        }

        [HttpGet]
        public async Task<IActionResult> DisplayStock(string fundId) {

            if(!User.Identity.IsAuthenticated) return Unauthorized();

            var stocks = await AzureDb.Stock.Where(s => s.FundId == fundId && s.Name != "STI" && s.Name != "DowsJones" && s.Name != "Nasdaq").ToListAsync();
            var result = stocks.GroupBy(s => s.Ticker)
                               .Select(g => g.OrderByDescending(s => s.Date).First());

            return Json(result);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateStockList([FromBody]IEnumerable<StockViewModel> stockModelList) {

            var fundId = stockModelList.First().FundId;

            var stocks = new List<Stock>();
            foreach(var stockModel in stockModelList) {
                stocks.Add(new Stock() { 
                    Name = stockModel.ShareName, 
                    Ticker = stockModel.Ticker, 
                    Industry = stockModel.Sector,
                    Weight = decimal.Parse(stockModel.ShareAllocation), 
                    FundId = stockModel.FundId,
                });
            }


            //Delete stocks in database
            var client = ClientFactory.CreateClient("ModifyStock");
            using var httpResponse = await client.DeleteAsync($"/fund/deletestocks/{stocks}");
            httpResponse.EnsureSuccessStatusCode();

            //Retrieve existing stocks from database
            var existingStocks = await AzureDb.Stock.Where(s => s.FundId == fundId && s.Name != "STI" && s.Name != "DowsJones" && s.Name != "Nasdaq")
                                                    .ToListAsync();

            var stockListInDb = existingStocks.Except(stocks)
                                              .GroupBy(s => s.Ticker)
                                              .Select(g => g.OrderByDescending(s => s.Date).First());

            //AzureDb.Stock.UpdateRange()

            //var newStockList = stockList.Except(stockListInDb);

            return Json(existingStocks);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStocks(IEnumerable<Stock> stocks) {

            AzureDb.Stock.RemoveRange(stocks);
            await AzureDb.SaveChangesAsync();
            return Ok();
        }
    }
}
