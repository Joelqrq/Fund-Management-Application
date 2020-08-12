using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FundManagementApplication.Models
{
    [Table("Global_DailyMovement")]
    public partial class GlobalDailyMovement
    {
        [Key]
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        [Column("GlobalDR", TypeName = "decimal(11, 10)")]
        public decimal GlobalDr { get; set; }
        [Column("Global_1R", TypeName = "decimal(11, 10)")]
        public decimal? Global1r { get; set; }
    }
}
