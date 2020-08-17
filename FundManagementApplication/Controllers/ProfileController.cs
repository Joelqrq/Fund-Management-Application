using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundManagementApplication.DataAccess;
using FundManagementApplication.Models;
using FundManagementApplication.Utilities;
using FundManagementApplication.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FundManagementApplication.Controllers {
    
    [Authorize]
    public class ProfileController : Controller {
        public AzureDbContext AzureDb { get; }

        public ProfileController(AzureDbContext azureDb) {
            AzureDb = azureDb;
        }

        [HttpGet]
        public IActionResult Profile() {

            var id = User.Claims.GetIDFromToken();
            var fundManagerAccount = AzureDb.FundManager.Where(fm => fm.PkFundManagerId == id).Single();
            
            return View(new ProfileViewModel() {
                ManagerID = id,
                ManagerName = fundManagerAccount.FundManagerName,
                ManagerEmail = fundManagerAccount.FundManagerEmail
            });
        }
        
        private FundManager ValidateFM(string MID)
        {
            return AzureDb.FundManager.Where(a => a.PkFundManagerId == MID).FirstOrDefault();
        }

        private void UpdateDb(FundManager fundManager) {

            AzureDb.FundManager.Update(fundManager);
            AzureDb.SaveChanges();
        }

        /// <summary>
        /// Update fund manager profile.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Update([FromForm]string name, [FromForm]string email) {

            ProfileViewModel model = new ProfileViewModel()
            {
                ManagerID = User.Claims.GetIDFromToken(),
                ManagerName = name,
                ManagerEmail = email
            };
  
            var fmAccount = ValidateFM(model.ManagerID);
            if (fmAccount != null)
            {
                fmAccount.FundManagerName = name;
                fmAccount.FundManagerEmail = email;
                UpdateDb(fmAccount);
            }
                
          
            return View("Profile", model);
        }

        /// <summary>
        /// Clear all input fields.
        /// </summary>
        [HttpPost]
        public IActionResult Cancel() {
            return RedirectToAction("Profile");
        }
    }
}