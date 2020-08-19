using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using FundManagementApplication.ViewModels;
using FundManagementApplication.DataAccess;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using FundManagementApplication.Utilities;
using FundManagementApplication.Services;

namespace FundManagementApplication.Controllers
{
    [Authorize]
    public class InvestorController : Controller{
        public AzureDbContext AzureDb { get; }
        public IHttpClientFactory ClientFactory { get; }

        public InvestorController(AzureDbContext azureDb, IHttpClientFactory clientFactory) {
            AzureDb = azureDb;
            ClientFactory = clientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> listOfInvestor()
        {
            var model = new InvestorViewModel();
            // Setup fund list
            model.Funds = await AzureDb.Funds.GetFundNames(User.Claims.GetIDFromToken());
            //check what does model.Funds.First means
            model.SelectedFund = model.Funds.First().Value;
            return View(model);
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

        [HttpGet]
        
        public async Task<IActionResult> Search(string SelectedFund, string newInvestorName, string newInvestorEmail )
        {
            var model = await new InvestorListGenerator(AzureDb).GenerateInvestorListData(SelectedFund, newInvestorName, newInvestorEmail);
            model.Funds = await AzureDb.Funds.GetFundNames(User.Claims.GetIDFromToken());
            return View("listOfInvestor", model);
        }
    }
}
