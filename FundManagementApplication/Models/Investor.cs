using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FundManagementApplication.Models
{
    public partial class Investor
    {
        [Key]
        [StringLength(10)]
        public string PK_Investor_ID { get; set; }
        [Required]
        [StringLength(45)]
        public string InvestorName { get; set; }
        [Required]
        [StringLength(45)]
        public string InvestorEmail { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime InvestorDate { get; set; }
    }
}
