using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FundManagementApplication.Models;
using Microsoft.AspNetCore.Authorization;
using FundManagementApplication.DataAccess;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FundManagementApplication.Controllers {

    [Authorize]
    public class HomeController : Controller {
        public AzureDbContext AzureDb { get; }

        public HomeController(AzureDbContext azureDb) {
            AzureDb = azureDb;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //var model = AzureDb.StocksOverview.Include(so => so.SharesWeightage)
            //            .Where(sw => sw.StocksOverviewFundId == "string");
            var model = new DashboardViewModel();
            return View(model);
            //return View();
        }

        [HttpPost]
        public IActionResult Search(DashboardViewModel model)
        {
            return View(model);
        }

        [HttpGet]
        public IActionResult Profile()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
