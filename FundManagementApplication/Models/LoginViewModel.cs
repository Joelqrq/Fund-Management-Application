using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FundManagementApplication.Models {
    public class LoginViewModel {
        [Required, EmailAddress]
        //[Remote(action: "Test", controller: "Test")]
        public string Email { get; set; }
        [Required, DataType(DataType.Password), StringLength(60, MinimumLength = 8)]
        public string Password { get; set; }
        public bool IsRemember { get; set; }
    }
}
