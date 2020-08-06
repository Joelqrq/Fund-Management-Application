using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FundManagementApplication.Models
{
    public partial class Funds_and_Fund_Manager
    {
        [Required]
        [StringLength(10)]
        public string Funds_and_Fund_Manager_Fund_ID { get; set; }
        [Required]
        [StringLength(10)]
        public string Funds_and_Fund_Manager_FundManager_ID { get; set; }

        [ForeignKey(nameof(Funds_and_Fund_Manager_FundManager_ID))]
        public virtual Fund_Manager Funds_and_Fund_Manager_FundManager_ { get; set; }
        [ForeignKey(nameof(Funds_and_Fund_Manager_Fund_ID))]
        public virtual Funds Funds_and_Fund_Manager_Fund_ { get; set; }
    }
}
