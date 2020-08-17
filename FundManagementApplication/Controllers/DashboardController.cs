using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FundManagementApplication.DataAccess;
using FundManagementApplication.Utilities;
using FundManagementApplication.ViewModels;
using FundManagementApplication.Services;
using System.Threading.Tasks;
using FundManagementApplication.Models;
using System;
using System.Linq;

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
            model.SelectedFund = model.Funds.First().Value;

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string SelectedFund, string SelectedDate = null) {

            //Get today's date if it's past 5pm
            var time = DateTime.Now.TimeOfDay.Hours;
            SelectedDate = time < 17 ? DateTime.Today.AddDays(-1).ToString() : DateTime.Today.ToString();

            //Retrieve fund factsheet details
            var model = await new DashboardGenerator(AzureDb).GenerateDashboardData(SelectedFund, SelectedDate);
            model.Funds = await AzureDb.Funds.GetFundNames(User.Claims.GetIDFromToken());
            return View("Dashboard", model);
        }

        [HttpGet("[controller]/[action]/{fund}/{date}")]
        public async Task<IActionResult> ExecuteFactSheetAction(int SelectAction, [FromRoute]string fund, [FromRoute]string date = null) {

            //Format date properly
            //if(date != null)
            //    date = HttpUtility.UrlDecode(date);

            //Get today's date if it's past 5pm
            var time = DateTime.Now.TimeOfDay.Hours;
            date = time < 17 ? DateTime.Today.AddDays(-1).ToString() : DateTime.Today.ToString();

            FundFactSheetDto fundFactSheet = await new FundFactSheetGenerator(AzureDb).GenerateFactSheet(User.Claims.GetIDFromToken(), fund, date);

            switch(SelectAction) {

                case 1:
                    return View("Factsheet", fundFactSheet);
                case 2:
                    //Call ctrl + P
                    return View("Factsheet", fundFactSheet);
                case 3:
                    return View("Factsheet", fundFactSheet);
                default:
                    return RedirectToAction("Search", new { SelectedFund = fund, SelectedDate = DateTime.Today.ToString() });

            }
        }
    }
}
