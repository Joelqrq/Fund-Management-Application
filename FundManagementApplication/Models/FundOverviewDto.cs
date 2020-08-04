using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundManagementApplication.Models {
    public class FundOverviewDto {
        public DateTime Date { get; set; }
        public decimal FundSize { get; set; }
        public decimal BidToBid { get; set; }
        public decimal OfferToBid { get; set; }
        public decimal BenchmarkBidToBid { get; set; }
    }
}
