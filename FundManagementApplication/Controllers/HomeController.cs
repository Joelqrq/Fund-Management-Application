using System.Collections.Generic;
using System.Threading.Tasks;
using FundManagementApplication.DataAccess;
using FundManagementApplication.Models;
using FundManagementApplication.Services;
using FundManagementApplication.Utilities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FundManagementApplication.Controllers {
    public class HomeController : Controller {

        public AzureDbContext AzureDb { get; }

        public HomeController(AzureDbContext azureDb) {
            AzureDb = azureDb;
        }

        public async Task<IActionResult> FactSheetHtml() {

            var date = "03/08/2020";
            var fund = "PRES_01";

            FundFactSheetDto fundFactSheet = await new FundFactSheetGenerator(AzureDb).GenerateFactSheet(User.Claims.GetIDFromToken(), fund, date);

            return View("../Dashboard/Factsheet", fundFactSheet);
        }
    }
}