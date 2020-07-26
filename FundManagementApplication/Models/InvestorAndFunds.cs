using System;
using System.Collections.Generic;

namespace FundManagementApplication.Models
{
    public partial class InvestorAndFunds
    {
        public string InvestorAndFundsInvestorId { get; set; }
        public string InvestorAndFundsFundId { get; set; }

        public virtual Funds InvestorAndFundsFund { get; set; }
        public virtual Investor InvestorAndFundsInvestor { get; set; }
    }
}
