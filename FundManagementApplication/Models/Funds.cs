using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FundManagementApplication.Models
{
    public partial class Funds
    {
        public Funds()
        {
            Stock = new HashSet<Stock>();
        }

        [Key]
        [Column("PK_Fund_ID")]
        [StringLength(10)]
        public string PkFundId { get; set; }
        [Required]
        [StringLength(45)]
        public string FundName { get; set; }
        [Required]
        [Column("FundManager_ID")]
        [StringLength(10)]
        public string FundManagerId { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        public decimal FundFee { get; set; }
        public DateTime InceptionDate { get; set; }
        [StringLength(1000)]
        public string FundProfile { get; set; }

        [ForeignKey(nameof(FundManagerId))]
        [InverseProperty("Funds")]
        public virtual FundManager FundManager { get; set; }
        [InverseProperty("Fund")]
        public virtual ICollection<Stock> Stock { get; set; }
    }
}
