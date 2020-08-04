using System;
using System.Collections.Generic;

namespace FundManagementApplication.Models
{
    public partial class DowJonesBidToBid
    {
        public DateTime DowJonesBidToBidDate { get; set; }
        public string DowJonesBidToBidFundId { get; set; }
        public decimal DowJonesBidToBidPrice { get; set; }
        public decimal DowJonesBidToBidYearToDate { get; set; }
        public decimal DowJonesBidToBidOneMonth { get; set; }
        public decimal DowJonesBidToBidThreeMonth { get; set; }
        public decimal DowJonesBidToBidSixMonth { get; set; }
        public decimal DowJonesBidToBidOneYear { get; set; }
        public decimal DowJonesBidToBidSinceInception { get; set; }
    }
}
