using System;
using System.Collections.Generic;

namespace FundManagementApplication.Models
{
    public partial class SharesWeightage
    {
        public SharesWeightage()
        {
            C = new HashSet<C>();
            C31Si = new HashSet<C31Si>();
            C52Si = new HashSet<C52Si>();
            C6lSi = new HashSet<C6lSi>();
            Cc3Si = new HashSet<Cc3Si>();
            D05Si = new HashSet<D05Si>();
            F = new HashSet<F>();
            Ge = new HashSet<Ge>();
            Gm = new HashSet<Gm>();
            Goog = new HashSet<Goog>();
            Ibm = new HashSet<Ibm>();
            Jpm = new HashSet<Jpm>();
            Msft = new HashSet<Msft>();
            O39Si = new HashSet<O39Si>();
            T39Si = new HashSet<T39Si>();
            U11Si = new HashSet<U11Si>();
            Uber = new HashSet<Uber>();
            V03Si = new HashSet<V03Si>();
            Wmt = new HashSet<Wmt>();
            Z74Si = new HashSet<Z74Si>();
        }

        public string SharesWeightageFundId { get; set; }
        public string SharesWeightageStockName { get; set; }
        public decimal SharesWeightageWeight { get; set; }
        public string SharesWeightageTicker { get; set; }

        public virtual StocksOverview SharesWeightageTickerNavigation { get; set; }
        public virtual ICollection<C> C { get; set; }
        public virtual ICollection<C31Si> C31Si { get; set; }
        public virtual ICollection<C52Si> C52Si { get; set; }
        public virtual ICollection<C6lSi> C6lSi { get; set; }
        public virtual ICollection<Cc3Si> Cc3Si { get; set; }
        public virtual ICollection<D05Si> D05Si { get; set; }
        public virtual ICollection<F> F { get; set; }
        public virtual ICollection<Ge> Ge { get; set; }
        public virtual ICollection<Gm> Gm { get; set; }
        public virtual ICollection<Goog> Goog { get; set; }
        public virtual ICollection<Ibm> Ibm { get; set; }
        public virtual ICollection<Jpm> Jpm { get; set; }
        public virtual ICollection<Msft> Msft { get; set; }
        public virtual ICollection<O39Si> O39Si { get; set; }
        public virtual ICollection<T39Si> T39Si { get; set; }
        public virtual ICollection<U11Si> U11Si { get; set; }
        public virtual ICollection<Uber> Uber { get; set; }
        public virtual ICollection<V03Si> V03Si { get; set; }
        public virtual ICollection<Wmt> Wmt { get; set; }
        public virtual ICollection<Z74Si> Z74Si { get; set; }
    }
}
