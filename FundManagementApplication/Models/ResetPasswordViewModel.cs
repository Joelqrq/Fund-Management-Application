using System.ComponentModel.DataAnnotations;

namespace FundManagementApplication.Models {
    public class ResetPasswordViewModel {

        [Required, DataType(DataType.EmailAddress), EmailAddress]
        public string Email { get; set; }
    }
}
