using System;
using System.Collections.Generic;

namespace FundManagementApplication.Models
{
    public partial class PrestigeBidToBid
    {
        public DateTime PrestigeBidToBidDate { get; set; }
        public string PrestigeBidToBidFundId { get; set; }
        public decimal PrestigeBidToBidPrice { get; set; }
        public decimal PrestigeBidToBidYearToDate { get; set; }
        public decimal PrestigeBidToBidOneMonth { get; set; }
        public decimal PrestigeBidToBidThreeMonth { get; set; }
        public decimal PrestigeBidToBidSixMonth { get; set; }
        public decimal PrestigeBidToBidOneYear { get; set; }
        public decimal PrestigeBidToBidSinceInception { get; set; }
    }
}
