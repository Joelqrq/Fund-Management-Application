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
        public async Task<IActionResult> Search(string SelectedFund, string SelectedDate) {

            //Retrieve fund factsheet details
            var model = await new DashboardGenerator(AzureDb).GenerateDashboardData(SelectedFund, SelectedDate);
            model.Funds = await AzureDb.Funds.GetFundNames(User.Claims.GetIDFromToken());
            return View("Dashboard", model);
        }

        [HttpGet("[controller]/[action]/{fund}/{date}")]
        public async Task<IActionResult> ExecuteFactSheetAction(int SelectAction, [FromRoute]string fund, [FromRoute]string date) {

            //Format date properly
            date = HttpUtility.UrlDecode(date);

            FundFactSheetDto fundFactSheet = await new FundFactSheetGenerator(AzureDb).GenerateFactSheet(User.Claims.GetIDFromToken(), fund, date);

            switch(SelectAction) {
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

            return RedirectToAction("Search", new { SelectedFund = fund, SelectedDate = date });
        }
    }
}
