using System;
using System.Collections.Generic;

namespace FundManagementApplication.Models
{
    public partial class NasdaqBidToBid
    {
        public DateTime NasdaqBidToBidDate { get; set; }
        public string NasdaqBidToBidFundId { get; set; }
        public decimal NasdaqBidToBidPrice { get; set; }
        public decimal NasdaqBidToBidYearToDate { get; set; }
        public decimal NasdaqBidToBidOneMonth { get; set; }
        public decimal NasdaqBidToBidThreeMonth { get; set; }
        public decimal NasdaqBidToBidSixMonth { get; set; }
        public decimal NasdaqBidToBidOneYear { get; set; }
        public decimal NasdaqBidToBidSinceInception { get; set; }
    }
}
