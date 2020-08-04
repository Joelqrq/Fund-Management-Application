using System;
using System.Collections.Generic;

namespace FundManagementApplication.Models
{
    public partial class GlobalOfferToBid
    {
        public DateTime GlobalOfferToBidDate { get; set; }
        public string GlobalOfferToBidFundId { get; set; }
        public decimal GlobalOfferToBidPrice { get; set; }
        public decimal GlobalOfferToBidPriceAfterAdmin { get; set; }
        public decimal GlobalOfferToBidYearToDate { get; set; }
        public decimal GlobalOfferToBidOneMonth { get; set; }
        public decimal GlobalOfferToBidThreeMonth { get; set; }
        public decimal GlobalOfferToBidSixMonth { get; set; }
        public decimal GlobalOfferToBidOneYear { get; set; }
        public decimal GlobalOfferToBidSinceInception { get; set; }
    }
}
