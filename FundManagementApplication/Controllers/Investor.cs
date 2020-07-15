using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
        
    }
}
