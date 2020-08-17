using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FundManagementApplication.ViewModels {
    public class DashboardViewModel {
        public IEnumerable<SelectListItem> Funds { get; set; }
        public string SelectedFund { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "dd-mm-yyyy", ApplyFormatInEditMode = true)]
        public DateTime SelectedDate { get; set; }
        public string FundSize { get; set; } = "--";
        public string BidToBid { get; set; } = "--";
        public string OfferToBid { get; set; } = "--";
        public string BenchMark { get; set; } = "--";
        public int SelectAction { get; set; } = 1;
    }
}
