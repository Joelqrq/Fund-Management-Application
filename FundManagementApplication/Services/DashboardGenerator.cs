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
        public string Fund { get; set; }
        public DateTime Date { get; set; }

        public DashboardGenerator(AzureDbContext azureDb) {
            AzureDb = azureDb;
        }

        public async Task<DashboardViewModel> GenerateDashboardData(string fund, string date) {

            Fund = fund;
            Date = DateTime.Parse(date);

            dynamic bidToBid;
            dynamic offerToBid;
            dynamic benchmarkBidToBid;

            //AzureDb.BenchmarkOverviews.

            if(fund == "PRES_01") {
                bidToBid = AzureDb.Set<Prestige_BidToBid>();
                offerToBid = AzureDb.Set<Prestige_OfferToBid>();
                benchmarkBidToBid = AzureDb.Set<STI_BidToBid>();
            }
            else if(fund == "GLOB_01") {
                bidToBid = AzureDb.Set<Prestige_BidToBid>();
                offerToBid = AzureDb.Set<Prestige_OfferToBid>();
                benchmarkBidToBid = new Tuple<DbSet<Nasdaq_BidToBid>, DbSet<DowJones_BidToBid>>(AzureDb.Set<Nasdaq_BidToBid>(), AzureDb.Set<DowJones_BidToBid>());
            }

            var data = await AzureDb.Prestige_BidToBid.Join(AzureDb.Prestige_OfferToBid, bb => bb.Date, ob => ob.Date, (bb, ob) => new FundOverviewDto {
                Date = bb.Date,
                FundSize = bb.Price,
                BidToBid = bb.OneMonth,
                OfferToBid = ob.OneMonth,
            }).Join(AzureDb.STI_BidToBid, fod => fod.Date, sbb => sbb.Date, (fod, sbb) => new FundOverviewDto {
                Date = fod.Date,
                FundSize = fod.FundSize,
                BidToBid = fod.BidToBid,
                OfferToBid = fod.OfferToBid,
                BenchmarkBidToBid = sbb.OneMonth
            }).SingleOrDefaultAsync(d => d.Date == Date);

            return new DashboardViewModel() {
                FundSize = data.FundSize.ToString("0.##"),
                BidToBid = data.BidToBid.ToString("0.##"),
                OfferToBid = data.OfferToBid.ToString("0.##"),
                BenchMark = data.BenchmarkBidToBid.ToString("0.##")
            };
        }
    }
}
