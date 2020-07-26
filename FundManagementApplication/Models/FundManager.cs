using System;
using System.Collections.Generic;

namespace FundManagementApplication.Models
{
    public partial class FundManager
    {
        public string PkFundManagerId { get; set; }
        public string FundManagerName { get; set; }
        public string FundManagerEmail { get; set; }
        public string FundManagerPassword { get; set; }
    }
}
