using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FundManagementApplication.Models
{
    public partial class Search
    {
        [Required]
        [StringLength(255)]
        public string StockName { get; set; }
        [StringLength(255)]
        public string Ticker { get; set; }
        [StringLength(255)]
        public string ExchangeMarket { get; set; }
        [StringLength(500)]
        public string Industry { get; set; }
        [Key]
        public int SearchId { get; set; }
    }
}
