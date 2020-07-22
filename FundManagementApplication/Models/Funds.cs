using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundManagementApplication.Models {
    public class Funds 
    {
        public int FundNav { get; set; }
        public float BidBid { get; set; }
        public float BidOffer { get; set; }
        public float BenchMark{ get; set; }
        public DateTime DateSelect { get; set; }
        public int SelectAction { get; set; }
    }


}
