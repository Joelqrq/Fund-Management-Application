namespace FundManagementApplication.Models {
    public class Investor {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Funds[] Funds { get; set; }
    }
}
