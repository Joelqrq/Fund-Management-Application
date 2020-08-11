using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FundManagementApplication.Models
{
    public partial class Investor
    {
        [Key]
        [Column("PK_ID")]
        [StringLength(10)]
        public string PkId { get; set; }
        [Required]
        [StringLength(45)]
        public string Name { get; set; }
        [Required]
        [StringLength(45)]
        public string Email { get; set; }
        public DateTime Date { get; set; }
        [Column("FundManagerID")]
        [StringLength(10)]
        public string FundManagerId { get; set; }

        [ForeignKey(nameof(FundManagerId))]
        [InverseProperty("Investor")]
        public virtual FundManager FundManager { get; set; }
    }
}
