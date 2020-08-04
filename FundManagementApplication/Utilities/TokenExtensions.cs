using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace FundManagementApplication.Utilities {
    public static class TokenExtensions {

        /// <summary>
        /// Retrieve fund manager id from token.
        /// </summary>
        /// <param name="claims">Claims to be iterated</param>
        /// <returns>Fund Manager ID</returns>
        public static string GetIDFromToken(this IEnumerable<Claim> claims) {
            return claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(c => c.Value).SingleOrDefault();
        }

        /// <summary>
        /// Retrieve fund manager name from token.
        /// </summary>
        /// <param name="claims">Claims to be iterated</param>
        /// <returns>Fund Manager Name</returns>
        public static string GetNameFromToken(this IEnumerable<Claim> claims) {
            return claims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).SingleOrDefault();
        }

        /// <summary>
        /// Retrieve fund manager email from token.
        /// </summary>
        /// <param name="claims">Claims to be iterated</param>
        /// <returns>Fund Manager Email</returns>
        public static string GetEmailFromToken(this IEnumerable<Claim> claims) {
            return claims.Where(c => c.Type == ClaimTypes.Email).Select(c => c.Value).SingleOrDefault();

        }
    }
}
