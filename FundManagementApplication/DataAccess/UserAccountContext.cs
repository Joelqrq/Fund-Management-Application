using FundManagementApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundManagementApplication.Data {
    public class UserAccountContext : DbContext {

        public DbSet<UserAccount> UserAccounts { get; set; }

        public UserAccountContext(DbContextOptions options) : base(options) {   }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            
        }


    }
}
