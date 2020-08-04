using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundManagementApplication.DataAccess;
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
                ManagerName = User.Claims.GetNameFromToken(),
                ManagerEmail = User.Claims.GetEmailFromToken()
            };

            return View(model);
        }

        /// <summary>
        /// Update fund manager profile.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Update(ProfileViewModel model, [FromForm]string name, [FromForm]string email) {
            model.ManagerEmail = email;
            model.ManagerName = name;

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