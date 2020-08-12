using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FundManagementApplication.Models
{
    [Table("Prestige_Performance_Chart")]
    public partial class PrestigePerformanceChart
    {
        [Key]
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        [Column("PrestigeCR", TypeName = "decimal(11, 10)")]
        public decimal PrestigeCr { get; set; }
        [Column("STICR", TypeName = "decimal(11, 10)")]
        public decimal Sticr { get; set; }
    }
}
