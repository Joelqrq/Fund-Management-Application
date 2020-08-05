using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FundManagementApplication.DataAccess;
using FundManagementApplication.Utilities;
using FundManagementApplication.ViewModels;
using FundManagementApplication.Services;
using System.Threading.Tasks;
using FundManagementApplication.Models;

namespace FundManagementApplication.Controllers {

    [Authorize]
    public class DashboardController : Controller {
        public AzureDbContext AzureDb { get; }

        public DashboardController(AzureDbContext azureDb) {
            AzureDb = azureDb;
        }

        [HttpGet]
        public async Task<IActionResult> Dashboard() {

            //Setup fund list
            var model = new DashboardViewModel() { 
                Funds = await AzureDb.Funds.GetFundNames(User.Claims.GetIDFromToken())
            };

            model.SelectedFund = model.Funds[0].Value;
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Search([FromForm] string SelectedFund, [FromForm] string SelectedDate) {

            //Retrieve fund factsheet details
            DashboardViewModel model = await new DashboardGenerator(AzureDb).GenerateDashboardData(SelectedFund, SelectedDate);
            model.Funds = await AzureDb.Funds.GetFundNames(User.Claims.GetIDFromToken());
            model.SelectedFund = SelectedFund;
            return View("Dashboard", model);
        }

        [HttpPost]
        public async Task<IActionResult> ExecuteFactSheet([FromForm]int inlineRadioOptions) {


            //var model = new DashboardViewModel() {
            //    Funds = await AzureDb.Funds.GetFundNames(User.Claims.GetIDFromToken())
            //};

            //FundFactSheetDto fundFactSheet = new FundFactSheetGenerator(AzureDb).GenerateFactSheet(SelectedFund, SelectedDate);

            switch(inlineRadioOptions) {
                case 1:

                    break;
                //case 2:
                //    Response.Headers.Add("Content-Disposition", "attachment; filename=test.pdf");
                //    return new FileStreamResult(pdfstream, "application/pdf");
                //case 3:
                //    return new FileStreamResult(pdfstream, "application/pdf");
                //default:
                //    return new FileStreamResult(pdfstream, "application/pdf");
            }

            return View();
        }
    }
}
