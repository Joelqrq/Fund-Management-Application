using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundManagementApplication.DataAccess;
using FundManagementApplication.Utilities;
using FundManagementApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FundManagementApplication.Controllers
{
    public class FundController : Controller
    {
        public AzureDbContext AzureDb { get; }

        public FundController(AzureDbContext azureDb) {
            AzureDb = azureDb;
        }

        public async Task<IActionResult> EditFund() {
            
            var model = new FundViewModel();

            //Setup fund list
            model.Funds = await AzureDb.Funds.GetFundNames(User.Claims.GetIDFromToken());

            return View(model);
        }

        public JsonResult DisplayStock(string fundId) {

            var fund = AzureDb.Funds.Where(f => f.PkFundId == fundId).Include(f => f.Stock).FirstAsync();


            return null;// Json();
        }

        //[HttpPost]
        //public IActionResult AddStock([FromForm]string name, [FromForm]string ticker) {
        //    var date = DateTime.Now.Date.AddDays(-1);
        //    ExecuteUIPathScrapper(name, ticker, date);
        //}
    }
}
