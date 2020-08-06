using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FundManagementApplication.Models
{
    public partial class Stocks_Overview
    {
        [Required]
        [StringLength(10)]
        public string Stocks_Overview_Fund_ID { get; set; }
        [Key]
        [StringLength(45)]
        public string Stocks_Overview_Ticker { get; set; }
        [Required]
        [StringLength(45)]
        public string Stocks_Overview_StockName { get; set; }
        [Required]
        [StringLength(20)]
        public string Stocks_Overview_Currency { get; set; }
        [Required]
        [StringLength(45)]
        public string Stocks_Overview_Industry { get; set; }

        [ForeignKey(nameof(Stocks_Overview_Fund_ID))]
        [InverseProperty(nameof(Funds.Stocks_Overview))]
        public virtual Funds Stocks_Overview_Fund_ { get; set; }
        [InverseProperty("Shares_Weightage_TickerNavigation")]
        public virtual Shares_Weightage Shares_Weightage { get; set; }
    }
}
