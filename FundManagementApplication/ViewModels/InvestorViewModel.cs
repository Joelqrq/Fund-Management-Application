using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FundManagementApplication.ViewModels {
    public class InvestorViewModel
    {
        public IEnumerable<SelectListItem> Funds { get; set; }
        public IEnumerable<InvestorDetails> GetInvestorDetails { get; set; } = new List<InvestorDetails> ();
        public string SelectedFund { get; set; }
        public string newInvestorName { get; set; }
        public string newInvestorEmail { get; set; } 


    }

    public class InvestorDetails{

        public string InvestorID { get; set; } 
        public string InvestorEmail { get; set; } 
        public string InvestorName { get; set; } 
        public string FundName { get; set; } 


    }
}
