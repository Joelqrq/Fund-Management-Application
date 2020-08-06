using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FundManagementApplication.Models
{
    public partial class Fund_Manager
    {
        [Key]
        [StringLength(10)]
        public string PK_FundManager_ID { get; set; }
        [Required]
        [StringLength(45)]
        public string FundManagerName { get; set; }
        [Required]
        [StringLength(60)]
        public string FundManagerEmail { get; set; }
        [Required]
        [StringLength(20)]
        public string FundManagerPassword { get; set; }
    }
}
