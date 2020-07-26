using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FundManagementApplication.Models {
    public class LoginViewModel {
        [Required, DataType(DataType.EmailAddress), EmailAddress, MaxLength(60)]
        public string Email { get; set; }
        [Required, DataType(DataType.Password), StringLength(20, MinimumLength = 8, ErrorMessage = "Password must have at least 8 characters.")]
        public string Password { get; set; }
        public bool IsRemember { get; set; }
    }
}
