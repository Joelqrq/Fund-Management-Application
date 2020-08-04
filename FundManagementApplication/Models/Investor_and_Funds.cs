using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FundManagementApplication.Models
{
    public partial class Investor_and_Funds
    {
        [Required]
        [StringLength(10)]
        public string Investor_and_Funds_Investor_ID { get; set; }
        [Required]
        [StringLength(10)]
        public string Investor_and_Funds_Fund_ID { get; set; }

        [ForeignKey(nameof(Investor_and_Funds_Fund_ID))]
        public virtual Funds Investor_and_Funds_Fund_ { get; set; }
        [ForeignKey(nameof(Investor_and_Funds_Investor_ID))]
        public virtual Investor Investor_and_Funds_Investor_ { get; set; }
    }
}
