using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FundManagementApplication.DataAccess;
using FundManagementApplication.Utilities;
using FundManagementApplication.ViewModels;
using FundManagementApplication.Services;
using System.Threading.Tasks;
using Rotativa.AspNetCore;

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
        [AllowAnonymous]
        public async Task<IActionResult> Search([FromForm] string SelectedFund, [FromForm] string SelectedDate) {

            //Retrieve fund factsheet details
            DashboardViewModel model = await new DashboardGenerator(AzureDb).GenerateDashboardData(SelectedFund, SelectedDate);
            model.Funds = await AzureDb.Funds.GetFundNames(User.Claims.GetIDFromToken());
            model.SelectedFund = SelectedFund;
            return View("Dashboard", model);
        }

        [AllowAnonymous]
        [HttpGet("[controller]/FactSheet")]
        public async Task<IActionResult> ExecuteFactSheet(/*[FromForm]int inlineRadioOptions*/) {

            //FundFactSheetDto fundFactSheet = new FundFactSheetGenerator(AzureDb, SelectedFund, SelectedDate).GenerateFactSheet();
            var model = new DashboardViewModel();

            //You can access this method by typing Dashboard/FactSheet
            //The Index is the index.cshtml. You can change to your .cshtml to test it.
            return new ViewAsPdf("Dashboard", model);

            //var model = new DashboardViewModel() {
            //    Funds = await AzureDb.Funds.GetFundNames(User.Claims.GetIDFromToken())
            //};
            //switch(inlineRadioOptions) {
            //    case 1:

            //        break;
            //    case 2:
            //        Response.Headers.Add("Content-Disposition", "attachment; filename=test.pdf");
            //        return new ViewAsPdf("Index", model);
            //    case 3:
            //        return new ViewAsPdf("Index", model);
            //    default:
            //        return new ViewAsPdf("Index", model);
            //}

            //return View();
        }
    }
}
