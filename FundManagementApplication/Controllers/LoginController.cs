using System;
using System.Threading.Tasks;
using FundManagementApplication.DataAccess;
using FundManagementApplication.Interfaces;
using FundManagementApplication.Services;
using FundManagementApplication.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FundManagementApplication.Controllers {
    public class LoginController : Controller {
        public IJWTAuthenticationManager JwtAuthentication { get; }
        public AzureDbContext AzureDb { get; }

        public LoginController(IJWTAuthenticationManager jwtAuthentication, AzureDbContext azureDb) {
            JwtAuthentication = jwtAuthentication;
            AzureDb = azureDb;
        }

        [HttpGet]
        public IActionResult Login() {

            if(JWTAuthenticationManager.IsUserLoggedIn(Request)) {
                return RedirectToAction("Dashboard", "Dashboard");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm]LoginViewModel model) {

            if(ModelState.IsValid) {

                //Search for account in database
                var userAccount = await AzureDb.FundManager.AsNoTracking()
                                                            .SingleOrDefaultAsync(fm => fm.FundManagerEmail == model.Email);

                if(userAccount == null || userAccount.FundManagerPassword != model.Password) {
                    ModelState.AddModelError("", $"Email or password is invalid.");
                    return View();
                }

                //Generate JWToken
                var token = JwtAuthentication.GenerateToken(userAccount);

                var cookieOpt = new CookieOptions() { HttpOnly = true, Secure = true };
                //Make cookie persist for a year
                if(model.IsRemember)
                    cookieOpt.Expires = DateTime.Now.AddDays(365);

                Response.Cookies.Append("JWToken", token, cookieOpt);
                return RedirectToAction("Dashboard", "Dashboard");
            }

            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword([FromForm]ResetPasswordViewModel model) {

            if(ModelState.IsValid) {

                //Search for account in database
                var userAccount = await AzureDb.FundManager.AsNoTracking()
                                                           .SingleOrDefaultAsync(fm => fm.FundManagerEmail == model.Email);

                if(userAccount == null) {
                    ModelState.AddModelError(string.Empty, $"Email {model.Email} does not exist.");
                    return View();
                }
                else
                    return RedirectToAction("Login");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Logout() {
            Response.Cookies.Delete("JWToken");
            return RedirectToAction("Login");
        }
    }
}
