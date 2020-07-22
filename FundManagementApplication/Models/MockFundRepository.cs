using FundManagementApplication.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundManagementApplication.Models
{
    public class MockFundRepository : IFundRepository
    {
        private List<Funds>_fundList;


        public MockFundRepository()
        {
            _fundList = new List<Funds>()
            {
                new Funds() { FundNav = 10, BidBid = 20, BidOffer = 30, BenchMark = 40, DateSelect = DateTime.Now, SelectAction = 2 }
            };
        }


        public Funds GetFund(int FundNav)
        {
            return _fundList[FundNav];
            
        }
    }
}
