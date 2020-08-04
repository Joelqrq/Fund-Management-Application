using System;
using System.Collections.Generic;

namespace FundManagementApplication.Models
{
    public partial class StocksOverview
    {
        public string StocksOverviewFundId { get; set; }
        public string StocksOverviewTicker { get; set; }
        public string StocksOverviewStockName { get; set; }
        public string StocksOverviewCurrency { get; set; }
        public string StocksOverviewIndustry { get; set; }

        public virtual Funds StocksOverviewFund { get; set; }
        public virtual SharesWeightage SharesWeightage { get; set; }
    }
}
