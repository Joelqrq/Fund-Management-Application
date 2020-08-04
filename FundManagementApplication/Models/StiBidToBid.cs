using System;
using System.Collections.Generic;

namespace FundManagementApplication.Models
{
    public partial class StiBidToBid
    {
        public DateTime StiBidToBidDate { get; set; }
        public string StiBidToBidFundId { get; set; }
        public decimal StiBidToBidPrice { get; set; }
        public decimal StiBidToBidYearToDate { get; set; }
        public decimal StiBidToBidOneMonth { get; set; }
        public decimal StiBidToBidThreeMonth { get; set; }
        public decimal StiBidToBidSixMonth { get; set; }
        public decimal StiBidToBidOneYear { get; set; }
        public decimal StiBidToBidSinceInception { get; set; }
    }
}
