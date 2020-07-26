using System;
using System.ComponentModel.DataAnnotations;

namespace FundManagementApplication.Models {
    public class DashboardViewModel {
        public int FundNav { get; set; }
        public float BidBid { get; set; }
        public float BidOffer { get; set; }
        public float BenchMark { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "dd-mm-yyyy", ApplyFormatInEditMode = true)]
        public DateTime DateSelect { get; set; }
        public int SelectAction { get; set; }
    }
}
