using System.Collections.Generic;

namespace FundManagementApplication.Models
{
    public partial class Funds
    {
        public Funds()
        {
            StocksOverview = new HashSet<StocksOverview>();
        }

        public string PkFundId { get; set; }
        public string FundName { get; set; }
        public string FundManagerId { get; set; }
        public decimal FundFee { get; set; }

        public virtual ICollection<StocksOverview> StocksOverview { get; set; }
    }
}
