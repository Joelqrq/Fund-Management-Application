using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FundManagementApplication.Models {

    [Table("Fund_Manager")]
    public class UserAccount {
        [Key]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [Required, StringLength(60, MinimumLength = 5)]
        [Column("FundManagerEmail")]
        public string Email { get; set; }
        [Required, StringLength(20, MinimumLength = 8, ErrorMessage = "Password needs to be at least 8 characters.")]
        [Column("FundManagerPassword")]
        public string Password { get; set; }
    }
}
