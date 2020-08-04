using System;
using System.Collections.Generic;

namespace FundManagementApplication.Models
{
    public partial class Z74Si
    {
        public DateTime Date { get; set; }
        public string Ticker { get; set; }
        public decimal Price { get; set; }
        public decimal Dr { get; set; }

        public virtual SharesWeightage TickerNavigation { get; set; }
    }
}
