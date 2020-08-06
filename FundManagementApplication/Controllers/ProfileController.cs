using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundManagementApplication.DataAccess;
using FundManagementApplication.Models;
using FundManagementApplication.Utilities;
using FundManagementApplication.ViewModels;
using Microsoft.AspNetCore.Authorization;
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

            ProfileViewModel model = new ProfileViewModel() {
                ManagerID = User.Claims.GetIDFromToken(),
               
            };
            model.ManagerName = AzureDb.Fund_Manager.Where(w => w.PK_FundManager_ID == model.ManagerID).Select(c => c.FundManagerName).Single();
            model.ManagerEmail = AzureDb.Fund_Manager.Where(w => w.PK_FundManager_ID == model.ManagerID).Select(c => c.FundManagerEmail).Single();

            return View(model);
        }


        public Fund_Manager UpdateDB(string MID)
        {
            var test = AzureDb.Fund_Manager.Where(a => a.PK_FundManager_ID == MID).FirstOrDefault();

            return test;

        }

      
        public void Update_Post(Models.Fund_Manager fund_Manager) {

            AzureDb.Fund_Manager.Update(fund_Manager);
            AzureDb.SaveChanges();
            

        }

        /// <summary>
        /// Update fund manager profile.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Update([FromForm]string name, [FromForm]string email) {

            ProfileViewModel model = new ProfileViewModel()
            {
                ManagerID = User.Claims.GetIDFromToken(),
                ManagerEmail = email,
                ManagerName = name
            };
  

            var testValid = UpdateDB(model.ManagerID);
            if (testValid != null)
            {
                testValid.FundManagerEmail = email;
                testValid.FundManagerName = name;

                Update_Post(testValid);

            }
                
          
            return View("Profile",model);


        }


        /// <summary>
        /// Clear all input fields.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Cancel(ProfileViewModel model) {

            return View(model);
        }
    }
}