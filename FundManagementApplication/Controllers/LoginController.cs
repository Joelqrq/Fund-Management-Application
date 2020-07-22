using System.Threading.Tasks;
using FundManagementApplication.Data;
using FundManagementApplication.Interfaces;
using FundManagementApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FundManagementApplication.Controllers
{
    public class LoginController : Controller
    {
        public IConfiguration Configuration { get; }
        public IJWTAuthenticationManager JwtAuthentication { get; }
        public UserAccountContext UAContext { get; }

        public LoginController(IConfiguration configuration, IJWTAuthenticationManager jwtAuthentication, UserAccountContext userAccountContext) {
            Configuration = configuration;
            JwtAuthentication = jwtAuthentication;
            UAContext = userAccountContext;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm]LoginViewModel model) {

            //UserAccount userAccount = null;
            //userAccount = await UAContext.UserAccounts.FindAsync(model.Email);

            //if(userAccount.Password != model.Password) return Unauthorized();

            //var token = JwtAuthentication.Authenticate(userAccount.Email);
            var token = JwtAuthentication.Authenticate("joel@gmail.com");

            if(token == null) return Unauthorized();

            HttpContext.Response.Cookies.Append("JWToken", token);

            return Redirect("~/Home/Index");
        }

        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Logout() {
            HttpContext.Response.Cookies.Delete("JWToken");
            return RedirectToAction("Login");
        }
    }
}
