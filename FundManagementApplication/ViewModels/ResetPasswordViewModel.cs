using System.ComponentModel.DataAnnotations;

namespace FundManagementApplication.ViewModels {
    public class ResetPasswordViewModel {

        [Required, DataType(DataType.EmailAddress), EmailAddress]
        public string Email { get; set; }
    }
}
