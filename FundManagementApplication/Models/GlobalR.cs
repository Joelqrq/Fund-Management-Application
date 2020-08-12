using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FundManagementApplication.Models
{
    [Table("Global_R")]
    public partial class GlobalR
    {
        [Column("Nasdaq_1R", TypeName = "decimal(11, 10)")]
        public decimal? Nasdaq1r { get; set; }
        [Column("DowsJones_1R", TypeName = "decimal(11, 10)")]
        public decimal? DowsJones1r { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Date { get; set; }
    }
}
