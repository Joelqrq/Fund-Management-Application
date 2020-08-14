using System.Linq;
using System.Threading.Tasks;
using FundManagementApplication.DataAccess;
using FundManagementApplication.Utilities;
using FundManagementApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FundManagementApplication.Controllers {
    public class FundController : Controller {
        public AzureDbContext AzureDb { get; }

        public FundController(AzureDbContext azureDb) {
            AzureDb = azureDb;
        }

        [HttpGet]
        public async Task<IActionResult> EditFund() {

            var model = new FundViewModel();

            //Setup fund list
            model.Funds = await AzureDb.Funds.GetFundNames(User.Claims.GetIDFromToken());

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DisplayStock(string fundId) {

            if(!User.Identity.IsAuthenticated) return Unauthorized();

            var stocks = await AzureDb.Stock.Where(s => s.FundId == fundId).ToListAsync();
            var result = stocks.GroupBy(s => s.Ticker).Select(g => g.OrderByDescending(s => s.Date).First());

            return Json(result);
        }

        //[HttpPost]
        //public IActionResult AddStock([FromForm]string name, [FromForm]string ticker, [FromForm]) {
        //    var date = DateTime.Now.Date.AddDays(-1);
        //    ExecuteUIPathScrapper(name, ticker, date);
        //}
    }
}
