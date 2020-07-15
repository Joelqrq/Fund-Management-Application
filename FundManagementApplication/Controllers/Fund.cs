using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FundManagementApplication.Controllers
{
    public class Fund : Controller
    {
        public IActionResult createNewFund()
        {
            return View();
        }

        public IActionResult editFund()
        {
            return View();
        }
    }
}
