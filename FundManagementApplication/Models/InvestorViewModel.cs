using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FundManagementApplication.Models
{
    public class InvestorViewModel
    {
        public string investorEmail { get; set; }
        public string investorName { get; set; }
        public string newInvestorName { get; set; }
        public string newInvestorEmail { get; set; }
    }

}
