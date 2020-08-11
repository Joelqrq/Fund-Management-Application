using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FundManagementApplication.Models
{
    [Table("Global_Performance_Chart")]
    public partial class GlobalPerformanceChart
    {
        [Key]
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        [Column("GlobalCR", TypeName = "decimal(11, 10)")]
        public decimal GlobalCr { get; set; }
        [Column("NasdaqCR", TypeName = "decimal(11, 10)")]
        public decimal NasdaqCr { get; set; }
        [Column("DowJonesCR", TypeName = "decimal(11, 10)")]
        public decimal DowJonesCr { get; set; }
    }
}
