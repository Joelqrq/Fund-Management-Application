using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FundManagementApplication.Models
{
    [Table("Prestige_DailyMovement")]
    public partial class PrestigeDailyMovement
    {
        [Key]
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        [Column("PrestigeDR", TypeName = "decimal(11, 10)")]
        public decimal PrestigeDr { get; set; }
        [Column("Prestige_1R", TypeName = "decimal(11, 10)")]
        public decimal? Prestige1r { get; set; }
    }
}
