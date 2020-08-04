using System;
using System.Collections.Generic;

namespace FundManagementApplication.Models
{
    public partial class PrestigeOfferToBid
    {
        public DateTime PrestigeOfferToBidDate { get; set; }
        public string PrestigeOfferToBidFundId { get; set; }
        public decimal PrestigeOfferToBidPrice { get; set; }
        public decimal PrestigeOfferToBidPriceAfterAdmin { get; set; }
        public decimal PrestigeOfferToBidYearToDate { get; set; }
        public decimal PrestigeOfferToBidOneMonth { get; set; }
        public decimal PrestigeOfferToBidThreeMonth { get; set; }
        public decimal PrestigeOfferToBidSixMonth { get; set; }
        public decimal PrestigeOfferToBidOneYear { get; set; }
        public decimal PrestigeOfferToBidSinceInception { get; set; }
    }
}
