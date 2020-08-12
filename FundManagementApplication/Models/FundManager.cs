using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FundManagementApplication.Models
{
    [Table("Fund_Manager")]
    public partial class FundManager
    {
        public FundManager()
        {
            Funds = new HashSet<Funds>();
            Investor = new HashSet<Investor>();
        }

        [Key]
        [Column("PK_FundManager_ID")]
        [StringLength(10)]
        public string PkFundManagerId { get; set; }
        [Required]
        [StringLength(45)]
        public string FundManagerName { get; set; }
        [Required]
        [StringLength(60)]
        public string FundManagerEmail { get; set; }
        [Required]
        [StringLength(20)]
        public string FundManagerPassword { get; set; }

        [InverseProperty("FundManager")]
        public virtual ICollection<Funds> Funds { get; set; }
        [InverseProperty("FundManager")]
        public virtual ICollection<Investor> Investor { get; set; }
    }
}
