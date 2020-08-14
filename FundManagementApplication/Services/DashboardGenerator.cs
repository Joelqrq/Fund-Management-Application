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

        public async Task<DashboardViewModel> GenerateDashboardData(string fund, string date) {

            FundOverviewDto data = new FundOverviewDto();
            data.Date = DateTime.Parse(date);

            if(fund == "PRES_01") {

                var priceNBB = await AzureDb.PrestigeBidToBid.Where(bb => bb.Date == data.Date).Select(bb => new { bb.Price, bb.OneMonth }).FirstAsync();
                data.FundSize = priceNBB.Price;
                data.BidToBid = priceNBB.OneMonth;
                data.OfferToBid = await AzureDb.PrestigeOfferToBid.Where(ob => ob.Date == data.Date).Select(ob => ob.OneMonth).FirstAsync();
                data.BenchmarkBidToBid = await AzureDb.StiBidToBid.Where(sbb => sbb.Date == data.Date).Select(sbb => sbb.OneMonth).FirstAsync();
            }
            else if(fund == "GLOB_01") {
                var priceNBB = await AzureDb.GlobalBidToBid.Where(bb => bb.Date == data.Date).Select(bb => new { bb.Price, bb.OneMonth }).FirstAsync();
                data.FundSize = priceNBB.Price;
                data.BidToBid = priceNBB.OneMonth;
                data.OfferToBid = await AzureDb.GlobalOfferToBid.Where(ob => ob.Date == data.Date).Select(ob => ob.OneMonth).FirstAsync();
                data.BenchmarkBidToBid = await AzureDb.NasdaqBidToBid.Where(sbb => sbb.Date == data.Date).Select(sbb => sbb.OneMonth).FirstAsync();
            }

            return new DashboardViewModel() {
                SelectedFund = fund,
                SelectedDate = data.Date,
                FundSize = data.FundSize.ToString("0.##"),
                BidToBid = data.BidToBid.ToString("0.##"),
                OfferToBid = data.OfferToBid.ToString("0.##"),
                BenchMark = data.BenchmarkBidToBid.ToString("0.##")
            };
        }
    }
}
