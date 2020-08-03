using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FundManagementApplication.DataAccess;
using FundManagementApplication.Utilities;
using FundManagementApplication.ViewModels;
using FundManagementApplication.Models;
using FundManagementApplication.Services;
using System.Threading.Tasks;
using Rotativa.AspNetCore;

namespace FundManagementApplication.Controllers {

    [Authorize]
    public class DashboardController : Controller {
        public AzureDbContext AzureDb { get; }
        public FundFactSheetGenerator FundFactSheetGenerator { get; }

        public DashboardController(AzureDbContext azureDb, FundFactSheetGenerator fundFactSheetGenerator) {
            AzureDb = azureDb;
            FundFactSheetGenerator = fundFactSheetGenerator;
        }

        [HttpGet]
        public async Task<IActionResult> Dashboard() {

            //Setup fund list
            var model = new DashboardViewModel() { 
                Funds = await AzureDb.Funds.GetFundNames(User.Claims.GetIDFromToken()) 
            };
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Search([FromForm] string SelectedFund, [FromForm] string SelectedDate) {

            //Retrieve fund factsheet details
            var userId = User.Claims.GetIDFromToken();
            FundFactSheetDto fundFactSheet = await FundFactSheetGenerator.GenerateFactSheet(AzureDb, SelectedFund, SelectedDate);
           
            return View();
        }

        [AllowAnonymous]
        [HttpGet("[controller]/FactSheet")]
        public async Task<IActionResult> ExecuteFactSheet(/*[FromForm]int inlineRadioOptions*/) {

            var model = new DashboardViewModel();

            //You can access this method by typing Dashboard/FactSheet
            //The Index is the index.cshtml. You can change to your .cshtml to test it.
            return new ViewAsPdf("Index", model);

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

        [HttpGet]
        public IActionResult Profile() {
            return View();
        }
    }
}
