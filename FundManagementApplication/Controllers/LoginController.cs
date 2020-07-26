using System.Linq;
using System.Threading.Tasks;
using FundManagementApplication.DataAccess;
using FundManagementApplication.Interfaces;
using FundManagementApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FundManagementApplication.Controllers {
    public class LoginController : Controller {
        public IConfiguration Configuration { get; }
        public IJWTAuthenticationManager JwtAuthentication { get; }
        public AzureDbContext AzureDb { get; }

        public LoginController(IConfiguration configuration, IJWTAuthenticationManager jwtAuthentication, AzureDbContext azureDb) {
            Configuration = configuration;
            JwtAuthentication = jwtAuthentication;
            AzureDb = azureDb;
        }

        [HttpGet]
        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromForm]LoginViewModel model) {

            if(ModelState.IsValid) {

                //FundManager userAccount = AzureDb.FundManager.AsNoTracking()
                //                                              .Single(fm => fm.Email == model.Email);

                //if(userAccount == null || userAccount.Password != model.Password) {
                //    ModelState.AddModelError("", $"Email or password is invalid.");
                //    return View();
                //}

                //var token = JwtAuthentication.GenerateToken(userAccount.Email);

                var token = JwtAuthentication.GenerateToken("joel@gmail.com");

                HttpContext.Response.Cookies.Append("JWToken", token);

                return Redirect("~/Home/Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword() {
            return View();
        }

        [HttpPost]
        public IActionResult ResetPassword([FromForm]ResetPasswordViewModel model) {

            if(ModelState.IsValid) {

                //var user = AzureDb.FundManager.AsNoTracking()
                //                               .Single(fm => fm.Email == model.Email);

                //if(user == null) {
                //    ModelState.AddModelError(string.Empty, $"Email {model.Email} does not exist.");
                //    return View();
                //}
                //else
                return RedirectToAction("Login");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Logout() {
            HttpContext.Response.Cookies.Delete("JWToken");
            return RedirectToAction("Login");
        }
    }
}
