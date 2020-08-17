using FundManagementApplication.DataAccess;
using FundManagementApplication.Models;
using FundManagementApplication.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundManagementApplication.Services {
    public class DashboardGenerator {

        public AzureDbContext AzureDb { get; }

        public DashboardGenerator(AzureDbContext azureDb) {
            AzureDb = azureDb;
        }

        public async Task<DashboardViewModel> GenerateDashboardData(string fundId, string date) {

            FundOverviewDto data = new FundOverviewDto();
            data.Date = DateTime.Parse(date);

            if(fundId == "PRES_01") {

                var fundBB = await AzureDb.PrestigeBidToBid.OrderByDescending(b => b.Date).Select(b => new { b.Price, b.OneMonth }).FirstAsync();
                data.FundSize = fundBB.Price;
                data.BidToBid = fundBB.OneMonth;
                data.OfferToBid = await AzureDb.PrestigeOfferToBid.OrderByDescending(b => b.Date).Select(b => b.OneMonth).FirstAsync();
                data.BenchmarkBidToBid = await AzureDb.StiBidToBid.OrderByDescending(b => b.Date).Select(b => b.OneMonth).FirstAsync();
            }
            else if(fundId == "GLOB_01") {
                var fundBB = await AzureDb.GlobalBidToBid.OrderByDescending(b => b.Date).Select(b => new { b.Price, b.OneMonth }).FirstAsync();
                data.FundSize = fundBB.Price;
                data.BidToBid = fundBB.OneMonth;
                data.OfferToBid = await AzureDb.GlobalOfferToBid.OrderByDescending(b => b.Date).Select(b => b.OneMonth).FirstAsync();
                data.BenchmarkBidToBid = await AzureDb.NasdaqBidToBid.OrderByDescending(b => b.Date).Select(b => b.OneMonth).FirstAsync();
            }

            return new DashboardViewModel() {
                SelectedFund = fundId,
                SelectedDate = data.Date,
                FundSize = data.FundSize.ToString(),
                BidToBid = data.BidToBid.ToString(),
                OfferToBid = data.OfferToBid.ToString(),
                BenchMark = data.BenchmarkBidToBid.ToString()
            };
        }
    }
}
