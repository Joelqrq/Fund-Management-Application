using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundManagementApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FundManagementApplication.Controllers
{
    public class Investor : Controller
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
        public async Task<IActionResult> Investor1([FromForm] InvestorViewModel model)
        {

            return Redirect("~/Investor/createNewInvestor");
        }

        public IActionResult Search(Investor model)
        {
            return View(model);
        }
    }
}
