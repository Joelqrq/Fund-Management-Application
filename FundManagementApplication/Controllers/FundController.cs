using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FundManagementApplication.Controllers
{
    public class FundController : Controller
    {

        public IActionResult createNewFund()
        {
            return View();
        }

        public IActionResult editFund()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult AddStock([FromForm]string name, [FromForm]string ticker) {
        //    var date = DateTime.Now.Date.AddDays(-1);
        //    ExecuteUIPathScrapper(name, ticker, date);
        //}
    }
}
