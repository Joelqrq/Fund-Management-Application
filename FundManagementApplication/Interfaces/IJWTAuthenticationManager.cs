using FundManagementApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundManagementApplication.Interfaces {
    public interface IJWTAuthenticationManager {
        string GenerateToken(FundManager account);
    }
}
