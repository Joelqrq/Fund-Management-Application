using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using FundManagementApplication.ViewModels;

namespace FundManagementApplication.Controllers
{
    public class InvestorController : Controller
    {
        public IActionResult listOfInvestor()
        {
            return View();
        }

        public IActionResult createNewInvestor()
        {
            return View();
        }

        public IActionResult editInvestorDetails()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Investor1([FromForm] InvestorViewModel model)
        {

            return Redirect("~/Investor/createNewInvestor");
        }

        public IActionResult Search(InvestorController model)
        {
            return View(model);
        }
    }
}
