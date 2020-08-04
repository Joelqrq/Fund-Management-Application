using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FundManagementApplication.Models
{
    public partial class Shares_Weightage
    {
        public Shares_Weightage()
        {
            C = new HashSet<C>();
            C31_SI = new HashSet<C31_SI>();
            C52_SI = new HashSet<C52_SI>();
            C6L_SI = new HashSet<C6L_SI>();
            CC3_SI = new HashSet<CC3_SI>();
            D05_SI = new HashSet<D05_SI>();
            F = new HashSet<F>();
            GE = new HashSet<GE>();
            GM = new HashSet<GM>();
            GOOG = new HashSet<GOOG>();
            IBM = new HashSet<IBM>();
            JPM = new HashSet<JPM>();
            MSFT = new HashSet<MSFT>();
            O39_SI = new HashSet<O39_SI>();
            T39_SI = new HashSet<T39_SI>();
            U11_SI = new HashSet<U11_SI>();
            Uber = new HashSet<Uber>();
            V03_SI = new HashSet<V03_SI>();
            WMT = new HashSet<WMT>();
            Z74_SI = new HashSet<Z74_SI>();
        }

        [Required]
        [StringLength(10)]
        public string Shares_Weightage_Fund_ID { get; set; }
        [Required]
        [StringLength(45)]
        public string Shares_Weightage_StockName { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        public decimal Shares_Weightage_Weight { get; set; }
        [Key]
        [StringLength(45)]
        public string Shares_Weightage_Ticker { get; set; }

        [ForeignKey(nameof(Shares_Weightage_Ticker))]
        [InverseProperty(nameof(Stocks_Overview.Shares_Weightage))]
        public virtual Stocks_Overview Shares_Weightage_TickerNavigation { get; set; }
        [InverseProperty("TickerNavigation")]
        public virtual ICollection<C> C { get; set; }
        [InverseProperty("TickerNavigation")]
        public virtual ICollection<C31_SI> C31_SI { get; set; }
        [InverseProperty("TickerNavigation")]
        public virtual ICollection<C52_SI> C52_SI { get; set; }
        [InverseProperty("TickerNavigation")]
        public virtual ICollection<C6L_SI> C6L_SI { get; set; }
        [InverseProperty("TickerNavigation")]
        public virtual ICollection<CC3_SI> CC3_SI { get; set; }
        [InverseProperty("TickerNavigation")]
        public virtual ICollection<D05_SI> D05_SI { get; set; }
        [InverseProperty("TickerNavigation")]
        public virtual ICollection<F> F { get; set; }
        [InverseProperty("TickerNavigation")]
        public virtual ICollection<GE> GE { get; set; }
        [InverseProperty("TickerNavigation")]
        public virtual ICollection<GM> GM { get; set; }
        [InverseProperty("TickerNavigation")]
        public virtual ICollection<GOOG> GOOG { get; set; }
        [InverseProperty("TickerNavigation")]
        public virtual ICollection<IBM> IBM { get; set; }
        [InverseProperty("TickerNavigation")]
        public virtual ICollection<JPM> JPM { get; set; }
        [InverseProperty("TickerNavigation")]
        public virtual ICollection<MSFT> MSFT { get; set; }
        [InverseProperty("TickerNavigation")]
        public virtual ICollection<O39_SI> O39_SI { get; set; }
        [InverseProperty("TickerNavigation")]
        public virtual ICollection<T39_SI> T39_SI { get; set; }
        [InverseProperty("TickerNavigation")]
        public virtual ICollection<U11_SI> U11_SI { get; set; }
        [InverseProperty("TickerNavigation")]
        public virtual ICollection<Uber> Uber { get; set; }
        [InverseProperty("TickerNavigation")]
        public virtual ICollection<V03_SI> V03_SI { get; set; }
        [InverseProperty("TickerNavigation")]
        public virtual ICollection<WMT> WMT { get; set; }
        [InverseProperty("TickerNavigation")]
        public virtual ICollection<Z74_SI> Z74_SI { get; set; }
    }
}
