using FundManagementApplication.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundManagementApplication.Models
{
    public class MockFundRepository : IFundRepository
    {
        private List<DashboardViewModel>_fundList;


        public MockFundRepository()
        {
            _fundList = new List<DashboardViewModel>()
            {
                new DashboardViewModel() { FundNav = 10, BidBid = 20, BidOffer = 30, BenchMark = 40, DateSelect = DateTime.Now, SelectAction = 2 }
            };
        }


        public DashboardViewModel GetFund(int FundNav)
        {
            return _fundList[FundNav];
            
        }
    }
}
