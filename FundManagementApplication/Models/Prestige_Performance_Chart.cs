using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FundManagementApplication.Models
{
    public partial class Prestige_Performance_Chart
    {
        [Key]
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        [Column(TypeName = "decimal(11, 10)")]
        public decimal PrestigeCR { get; set; }
        [Column(TypeName = "decimal(11, 10)")]
        public decimal STICR { get; set; }
    }
}
