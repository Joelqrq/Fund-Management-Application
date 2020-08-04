using System;
using System.Collections.Generic;

namespace FundManagementApplication.Models
{
    public partial class Investor
    {
        public string PkInvestorId { get; set; }
        public string InvestorName { get; set; }
        public string InvestorEmail { get; set; }
        public DateTime InvestorDate { get; set; }
    }
}
