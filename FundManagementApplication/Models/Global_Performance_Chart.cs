using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FundManagementApplication.Models
{
    public partial class Global_Performance_Chart
    {
        [Key]
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        [Column(TypeName = "decimal(11, 10)")]
        public decimal GlobalCR { get; set; }
        [Column(TypeName = "decimal(11, 10)")]
        public decimal NasdaqCR { get; set; }
        [Column(TypeName = "decimal(11, 10)")]
        public decimal DowJonesCR { get; set; }
    }
}
