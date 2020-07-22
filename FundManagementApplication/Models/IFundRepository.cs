using FundManagementApplication.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundManagementApplication.Models
{
    public interface IFundRepository
    {
        Funds GetFund(int FundNav);
    }
}
