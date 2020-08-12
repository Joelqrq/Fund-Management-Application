using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FundManagementApplication.Models
{
    public partial class Stock
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [StringLength(45)]
        public string Ticker { get; set; }
        [Required]
        [StringLength(45)]
        public string Name { get; set; }
        [Required]
        [StringLength(20)]
        public string Currency { get; set; }
        [Required]
        [StringLength(45)]
        public string Industry { get; set; }
        [Column("date", TypeName = "datetime")]
        public DateTime Date { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        public decimal Weight { get; set; }
        [Column("DR", TypeName = "decimal(13, 10)")]
        public decimal Dr { get; set; }
        [Required]
        [StringLength(10)]
        public string FundId { get; set; }

        [ForeignKey(nameof(FundId))]
        [InverseProperty(nameof(Funds.Stock))]
        public virtual Funds Fund { get; set; }
    }
}
