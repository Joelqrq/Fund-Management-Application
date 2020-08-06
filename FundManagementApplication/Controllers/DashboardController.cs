using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FundManagementApplication.DataAccess;
using FundManagementApplication.Utilities;
using FundManagementApplication.ViewModels;
using FundManagementApplication.Services;
using System.Threading.Tasks;
using FundManagementApplication.Models;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace FundManagementApplication.Controllers {

    [Authorize]
    public class DashboardController : Controller {
        public AzureDbContext AzureDb { get; }
        public List<SelectListItem> FundList { get; set; }

        public DashboardController(AzureDbContext azureDb) {
            AzureDb = azureDb;
        }

        [HttpGet]
        public async Task<IActionResult> Dashboard() {

            var model = new DashboardViewModel();

            if(FundList == null) {
                //Setup fund list
                FundList = await AzureDb.Funds.GetFundNames(User.Claims.GetIDFromToken());
                model.SelectedFund = FundList[0].Value;
            }
            
            model.Funds = FundList;

            return View("Dashboard", model);
        }

        [HttpPost]
        public async Task<IActionResult> Search([FromForm]string SelectedFund, [FromForm]string SelectedDate) {
            
            //Retrieve fund factsheet details
            var model = await new DashboardGenerator(AzureDb).GenerateDashboardData(SelectedFund, SelectedDate);

            return RedirectToAction("Dashboard", model);
        }

        [HttpPost]
        public async Task<IActionResult> GetFactSheet([FromForm]int inlineRadioOptions) {


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
