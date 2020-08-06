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
            Stocks_Overview = new HashSet<Stocks_Overview>();
        }

        [Key]
        [StringLength(10)]
        public string PK_Fund_ID { get; set; }
        [Required]
        [StringLength(45)]
        public string FundName { get; set; }
        [Required]
        [StringLength(10)]
        public string FundManager_ID { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        public decimal FundFee { get; set; }
        public DateTime InceptionDate { get; set; }

        [InverseProperty("Stocks_Overview_Fund_")]
        public virtual ICollection<Stocks_Overview> Stocks_Overview { get; set; }
    }
}
