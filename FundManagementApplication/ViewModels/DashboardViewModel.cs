using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FundManagementApplication.ViewModels {
    public class DashboardViewModel {
        public List<SelectListItem> Funds { get; set; }
        public string FundNav { get; set; } = "--";
        public string BidBid { get; set; } = "--";
        public string BidOffer { get; set; } = "--";
        public string BenchMark { get; set; } = "--";
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "dd-mm-yyyy", ApplyFormatInEditMode = true)]
        public DateTime SelectedDate { get; set; }
        public int SelectAction { get; set; } = 1;
    }
}
