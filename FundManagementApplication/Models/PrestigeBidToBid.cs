using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FundManagementApplication.Models
{
    [Table("Prestige_BidToBid")]
    public partial class PrestigeBidToBid
    {
        [Key]
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        [Required]
        [Column("Fund_ID")]
        [StringLength(10)]
        public string FundId { get; set; }
        [Column(TypeName = "decimal(13, 10)")]
        public decimal Price { get; set; }
        [Column("YTD", TypeName = "decimal(11, 10)")]
        public decimal Ytd { get; set; }
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
        public int Id { get; set; }
    }
}
