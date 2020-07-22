using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundManagementApplication.Models {
    public class FundManager : UserAccount {
        public Investor[] Investors { get; set; }
    }
}
