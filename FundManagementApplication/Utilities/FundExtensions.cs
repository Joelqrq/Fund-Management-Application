using FundManagementApplication.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundManagementApplication.Utilities {
    public static class FundExtensions {
        public static async Task<List<SelectListItem>> GetFundNames(this DbSet<Funds> funds, string id) {
            return await funds.Where(f => f.FundManager_ID == id)
                                             .Select(f => new SelectListItem(f.FundName, f.PK_Fund_ID))
                                             .ToListAsync();
        }
    }
}
