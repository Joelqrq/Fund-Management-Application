using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace FundManagementApplication.Utilities {
    public static class TokenExtensions {
        
        public static string GetIDFromToken(this IEnumerable<Claim> claims) {
            return claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(c => c.Value).SingleOrDefault();
        }
    }
}
