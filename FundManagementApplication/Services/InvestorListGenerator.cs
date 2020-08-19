using FundManagementApplication.DataAccess;
using FundManagementApplication.Models;
using FundManagementApplication.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundManagementApplication.Services
{
    public class InvestorListGenerator
    {
        public AzureDbContext AzureDb { get; }
        public string FundId { get; set; }

        public string InvestorName { get; set; }

        public string InvestorEmail { get; set; }

        public InvestorListGenerator(AzureDbContext azureDb) {

            AzureDb = azureDb;
        }

        public async Task<InvestorViewModel> GenerateInvestorListData(string fundId, string investorName, string investorEmail) {
            FundId = fundId;
            InvestorName = investorName;
            InvestorEmail = InvestorEmail;


            //Retrieve information in database according to given date. (FundManager, Funds, Stocks)
          //  var info = await AzureDb.Investor.Where(i => i.Name == InvestorName && i.Fund_ID == FundId || i.Email == InvestorEmail && i.Fund_ID == FundId).Select(i => new { i.PkId, i.Email, i.Name, i.Fund_ID }).ToListAsync();
            var info = await AzureDb.Investor.Where(i => i.Name == InvestorName && i.Fund_ID == FundId || i.Email == InvestorEmail && i.Fund_ID == FundId).Select(i => new Investor { PkId = i.PkId, Email = i.Email, Name = i.Name, Fund_ID=i.Fund_ID }).ToListAsync();

            var investorInfo = new InvestorViewModel();

            investorInfo.GetInvestorDetails = RetrieveInvestorInformation(info);


            return investorInfo;

        }
           

      


        private IEnumerable<InvestorDetails> RetrieveInvestorInformation(IEnumerable<Investor> info)
        {

            foreach (var investor in info)
            {
                yield return new InvestorDetails()
                {
                    InvestorID = investor.PkId,
                    InvestorEmail = investor.Email,
                    InvestorName = investor.Name,
                    FundName = investor.Fund_ID

                };
            }

        }
    }

    
}
