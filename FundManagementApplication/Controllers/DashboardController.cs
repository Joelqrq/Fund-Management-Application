using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FundManagementApplication.DataAccess;
using FundManagementApplication.Utilities;
using FundManagementApplication.ViewModels;
using FundManagementApplication.Services;
using System.Threading.Tasks;
using System.Text;
using System.Web;
using FundManagementApplication.Models;
using System;

namespace FundManagementApplication.Controllers {

    [Authorize]
    public class DashboardController : Controller {
        public AzureDbContext AzureDb { get; }

        public DashboardController(AzureDbContext azureDb) {
            AzureDb = azureDb;
        }

        [HttpGet]
        public async Task<IActionResult> Dashboard() {

            var model = new DashboardViewModel();

            //Setup fund list
            model.Funds = await AzureDb.Funds.GetFundNames(User.Claims.GetIDFromToken());
            model.SelectedFund = model.Funds[0].Value;

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string SelectedFund, string SelectedDate = null) {

            //Retrieve fund factsheet details
            var model = await new DashboardGenerator(AzureDb).GenerateDashboardData(SelectedFund, DateTime.Today.ToString());
            model.Funds = await AzureDb.Funds.GetFundNames(User.Claims.GetIDFromToken());
            return View("Dashboard", model);
        }

        [HttpGet("[controller]/[action]/{fund}/{date}")]
        public async Task<IActionResult> ExecuteFactSheetAction(int SelectAction, [FromRoute]string fundId, [FromRoute]string date = null) {

            //Format date properly
            //if(date != null)
            //    date = HttpUtility.UrlDecode(date);

            FundFactSheetDto fundFactSheet = await new FundFactSheetGenerator(AzureDb).GenerateFactSheet(User.Claims.GetIDFromToken(), fundId, DateTime.Today.ToString());

            switch(SelectAction) {

                case 1:
                    return View("Factsheet", fundFactSheet);
                case 2:
                    //Call ctrl + P
                    return View("Factsheet", fundFactSheet);
                case 3:
                    return View("Factsheet", fundFactSheet);
                default:
                    return RedirectToAction("Search", new { SelectedFund = fundId, SelectedDate = DateTime.Today.ToString() });

            }
        }
    }
}
