using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FundManagementApplication.Models
{
    public partial class DowJones_BidToBid
    {
        [Key]
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        [Required]
        [StringLength(10)]
        public string Fund_ID { get; set; }
        [Column(TypeName = "decimal(13, 10)")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(11, 10)")]
        public decimal YTD { get; set; }
        [Column(TypeName = "decimal(11, 10)")]
        public decimal OneMonth { get; set; }
        [Column(TypeName = "decimal(11, 10)")]
        public decimal ThreeMonth { get; set; }
        [Column(TypeName = "decimal(11, 10)")]
        public decimal SixMonth { get; set; }
        [Column(TypeName = "decimal(11, 10)")]
        public decimal OneYear { get; set; }
        [Column(TypeName = "decimal(11, 10)")]
        public decimal SinceInception { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
    }
}
