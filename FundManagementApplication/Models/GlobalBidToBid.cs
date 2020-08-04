using System;
using System.Collections.Generic;

namespace FundManagementApplication.Models
{
    public partial class GlobalBidToBid
    {
        public DateTime GlobalBidToBidDate { get; set; }
        public string GlobalBidToBidFundId { get; set; }
        public decimal GlobalBidToBidPrice { get; set; }
        public decimal GlobalBidToBidYearToDate { get; set; }
        public decimal GlobalBidToBidOneMonth { get; set; }
        public decimal GlobalBidToBidThreeMonth { get; set; }
        public decimal GlobalBidToBidSixMonth { get; set; }
        public decimal GlobalBidToBidOneYear { get; set; }
        public decimal GlobalBidToBidSinceInception { get; set; }
    }
}
