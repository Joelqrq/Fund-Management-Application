using System;
using System.Collections.Generic;

namespace FundManagementApplication.Models
{
    public partial class FundsAndFundManager
    {
        public string FundsAndFundManagerFundId { get; set; }
        public string FundsAndFundManagerFundManagerId { get; set; }

        public virtual Funds FundsAndFundManagerFund { get; set; }
        public virtual FundManager FundsAndFundManagerFundManager { get; set; }
    }
}
