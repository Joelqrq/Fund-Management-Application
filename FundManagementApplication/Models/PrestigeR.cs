using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FundManagementApplication.Models
{
    [Table("Prestige_R")]
    public partial class PrestigeR
    {
        [Column("STI_1R", TypeName = "decimal(11, 10)")]
        public decimal? Sti1r { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Date { get; set; }
    }
}
