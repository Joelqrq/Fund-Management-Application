using FundManagementApplication.Interfaces;
using FundManagementApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FundManagementApplication.Services {
    public class JWTAuthenticationManager : IJWTAuthenticationManager {

        private readonly string tokenKey;

        public JWTAuthenticationManager(string tokenKey) {
            this.tokenKey = tokenKey;
        }

        public string GenerateToken(Fund_Manager account) {

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, account.FundManagerEmail),
                    new Claim(ClaimTypes.Name, account.FundManagerName),
                    new Claim(ClaimTypes.NameIdentifier, account.PK_FundManager_ID)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tokenKey)),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        /// <summary>
        /// Check if user was logged in previously.
        /// </summary>
        /// <param name="request">HttpRequest</param>
        /// <returns></returns>
        public static bool IsUserLoggedIn(HttpRequest request) {
            return !string.IsNullOrEmpty(request.Cookies["JWToken"]);
        }
    }
}
