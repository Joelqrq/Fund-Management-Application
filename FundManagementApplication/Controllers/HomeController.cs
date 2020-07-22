using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FundManagementApplication.Models;
using Microsoft.AspNetCore.Authorization;

namespace FundManagementApplication.Controllers {

    [Authorize]
    public class HomeController : Controller {

        public HomeController() { }

        [HttpGet]
        public IActionResult Index()
        {
            MockFundRepository mockFundRepository = new MockFundRepository();

            Funds model = mockFundRepository.GetFund(0);
            return View(model);
        }

        public IActionResult Search(Funds model)
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
