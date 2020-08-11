using FundManagementApplication.DataAccess;
using FundManagementApplication.Models;
using FundManagementApplication.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundManagementApplication.Services {
    public class FundFactSheetGenerator {

        public AzureDbContext AzureDb { get; }
        public string FundManagerId { get; set; }
        public string FundId { get; set; }
        public DateTime Date { get; set; }

        public FundFactSheetGenerator(AzureDbContext azureDb) {
            AzureDb = azureDb;
        }

        public async Task<FundFactSheetDto> GenerateFactSheet(string fundManagerId, string fundId, string date) {

            FundManagerId = fundManagerId;
            FundId = fundId;
            DateTime yearBegin = new DateTime(DateTime.Today.Year, 1, 1);
            Date = DateTime.Parse(date);

            //Retrieve information in database according to given date. (FundManager, Funds, Stocks)
            var fm = await AzureDb.FundManager.AsNoTracking().Where(fm => fm.PkFundManagerId == fundManagerId).FirstAsync();
            var fund = await AzureDb.Funds.Where(f => f.PkFundId == fundId).FirstAsync();
            var stocks = await AzureDb.Stock.Where(s => s.FundId == fundId && s.Date >= yearBegin && s.Date <= Date).ToListAsync();

            var fundFactSheet = new FundFactSheetDto();

            fundFactSheet.FundProfile = fund.FundProfile;
            fundFactSheet.Holdings = RetrieveHoldingsData(stocks);
            fundFactSheet.Sectors = RetrieveSectorData(stocks);
            fundFactSheet.PerformanceCharts = await RetrievePerformanceChartData(fund);
            fundFactSheet.FundDetails = await RetrieveFundDetailsData(fm, fund, stocks);
            fundFactSheet.PerformanceTable = await RetrievePerformanceTableData();
            return fundFactSheet;
        }

        private IEnumerable<HoldingsDto> RetrieveHoldingsData(IEnumerable<Stock> stocks) {

            decimal totalWeight = 0m;
            foreach(var stock in stocks) {
                totalWeight += stock.Weight;
            }

            var filteredStocks = stocks.Except(stocks.Where(s => s.Name == "STI" || s.Name == "DowsJones" || s.Name == "Nasdaq"));

            //Sort them by weight in descending order and convert weight into percentage
            return filteredStocks.OrderByDescending(s => s.Weight)
                                 .Take(10)
                                 .ConvertToPercentage(totalWeight)
                                 .TurnIntoHoldingsDto();
        }

        private IEnumerable<SectorDto> RetrieveSectorData(IEnumerable<Stock> stocks) {

            var filteredStocks = stocks.Except(stocks.Where(s => s.Name == "STI" || s.Name == "DowsJones" || s.Name == "Nasdaq"));
            var stocksCount = filteredStocks.Count();

            //Sort and convert industry into percentage
            return filteredStocks.GroupBy(s => s.Industry, (key, result) => new SectorDto {
                Name = key,
                Percentage = (result.Count() * 100 / stocksCount).ToString("0.##")
            }).OrderByDescending(s => s.Percentage);
        }

        private async Task<PerformanceChartDto> RetrievePerformanceChartData(Funds fund) {

            DateTime yearBegin = new DateTime(Date.Year, 1, 1);

            PerformanceChartDto chartDto = new PerformanceChartDto();

            if(FundId == "PRES_01") {

                var chartData = await AzureDb.PrestigePerformanceChart.Where(ppc => ppc.Date >= yearBegin && ppc.Date <= Date).ToListAsync();

                chartDto.Date = new List<DateTime>();
                var data1 = new PerformanceDto();
                var data2 = new PerformanceDto();

                data1.Name = fund.FundName;
                data2.Name = await AzureDb.StiBidToBid.Select(pbb => pbb.Name).FirstAsync();
                data1.CumulativeReturns = new List<string>();
                data2.CumulativeReturns = new List<string>();

                foreach(var cd in chartData) {
                    chartDto.Date.Add(cd.Date);
                    data1.CumulativeReturns.Add(cd.PrestigeCr.ToString("0.##"));
                    data2.CumulativeReturns.Add(cd.Sticr.ToString("0.##"));
                }

                chartDto.Performances = new List<PerformanceDto>();
                chartDto.Performances.Add(data1);
                chartDto.Performances.Add(data2);
            }
            else if(FundId == "GLOB_01") {

                var chartData = await AzureDb.GlobalPerformanceChart.Where(gpc => gpc.Date >= yearBegin && gpc.Date <= Date).ToListAsync();

                chartDto.Date = new List<DateTime>();
                var data1 = new PerformanceDto();
                var data2 = new PerformanceDto();
                var data3 = new PerformanceDto();

                data1.Name = fund.FundName;
                data2.Name = await AzureDb.NasdaqBidToBid.Select(nbb => nbb.Name).FirstAsync();
                data3.Name = await AzureDb.DowJonesBidToBid.Select(dbb => dbb.Name).FirstAsync();
                data1.CumulativeReturns = new List<string>();
                data2.CumulativeReturns = new List<string>();

                foreach(var cd in chartData) {
                    chartDto.Date.Add(cd.Date);
                    data1.CumulativeReturns.Add(cd.GlobalCr.ToString("0.##"));
                    data2.CumulativeReturns.Add(cd.NasdaqCr.ToString("0.##"));
                    data3.CumulativeReturns.Add(cd.DowJonesCr.ToString("0.##"));
                }

                chartDto.Performances = new List<PerformanceDto>();
                chartDto.Performances.Add(data1);
                chartDto.Performances.Add(data2);
                chartDto.Performances.Add(data3);
            }
            else return null;

            return chartDto;
        }

        private async Task<FundDetailsDto> RetrieveFundDetailsData(FundManager fm, Funds fund, IEnumerable<Stock> stocks) {

            var fundDetails = new FundDetailsDto() {
                InitialFee = fund.FundFee.ToString("0.##"),
                InceptionDate = fund.InceptionDate,
                FundManagerName = fm.FundManagerName,
                StockCurrency = stocks.Select(s => s.Currency).First(),
                FundName = fund.FundName,
                TotalHoldings = stocks.Count()
            };

            if(FundId == "PRES_01") {
                var details = await AzureDb.PrestigeBidToBid.Where(pbb => pbb.Date == Date).FirstAsync();
                fundDetails.FundSize = details.Price;
                fundDetails.AnnualizeReturns = details.SinceInception.ToString("0.##");
                fundDetails.BenchmarkNames = new List<string>() {
                    AzureDb.StiBidToBid.Select(sti => sti.Name).First()
                };
            }
            else if(FundId == "GLOB_01") {
                var details = await AzureDb.GlobalBidToBid.Where(gbb => gbb.Date == Date).FirstAsync();
                fundDetails.FundSize = details.Price;
                fundDetails.AnnualizeReturns = details.SinceInception.ToString("0.##");
                fundDetails.BenchmarkNames = new List<string>() {
                    AzureDb.NasdaqBidToBid.Select(sti => sti.Name).First(),
                    AzureDb.DowJonesBidToBid.Select(sti => sti.Name).First()
                };
            }

            return fundDetails;
        }

        private async Task<PerformanceTableDto> RetrievePerformanceTableData() {

            var performanceTable = new PerformanceTableDto();
            performanceTable.Performances = new List<PerformanceTableColumnDto>();

            if(FundId == "PRES_01") {
                var bidToBidData = await AzureDb.PrestigeBidToBid.Where(pbb => pbb.Date == Date).FirstAsync();
                var bidToBid = new PerformanceTableColumnDto() {
                    Name = "Bid to Bid %",
                    OneMonth = bidToBidData.OneMonth.ToString("0.##"),
                    ThreeMonth = bidToBidData.ThreeMonth.ToString("0.##"),
                    SixMonth = bidToBidData.SixMonth.ToString("0.##"),
                    OneYear = bidToBidData.OneYear.ToString("0.##"),
                    SinceInception = bidToBidData.SinceInception.ToString("0.##"),
                    YearToDate = bidToBidData.Ytd.ToString("0.##")
                };
                var offerToBidData = await AzureDb.PrestigeOfferToBid.Where(pob => pob.Date == Date).FirstAsync();
                var offerToBid = new PerformanceTableColumnDto() {
                    Name = "Offer to Bid %",
                    OneMonth = offerToBidData.OneMonth.ToString("0.##"),
                    ThreeMonth = offerToBidData.ThreeMonth.ToString("0.##"),
                    SixMonth = offerToBidData.SixMonth.ToString("0.##"),
                    OneYear = offerToBidData.OneYear.ToString("0.##"),
                    SinceInception = offerToBidData.SinceInception.ToString("0.##"),
                    YearToDate = offerToBidData.Ytd.ToString("0.##")
                };
                var benchMarkData = await AzureDb.StiBidToBid.Where(sbb => sbb.Date == Date).FirstAsync();
                var benchMark = new PerformanceTableColumnDto() {
                    Name = $"{benchMarkData.Name} %",
                    OneMonth = benchMarkData.OneMonth.ToString("0.##"),
                    ThreeMonth = benchMarkData.ThreeMonth.ToString("0.##"),
                    SixMonth = benchMarkData.SixMonth.ToString("0.##"),
                    OneYear = benchMarkData.OneYear.ToString("0.##"),
                    SinceInception = benchMarkData.SinceInception.ToString("0.##"),
                    YearToDate = benchMarkData.Ytd.ToString("0.##")
                };

                performanceTable.Performances.Add(bidToBid);
                performanceTable.Performances.Add(offerToBid);
                performanceTable.Performances.Add(benchMark);
            }
            else if(FundId == "GLOB_01") {
                var bidToBidData = await AzureDb.GlobalBidToBid.Where(pbb => pbb.Date == Date).FirstAsync();
                var bidToBid = new PerformanceTableColumnDto() {
                    Name = "Bid to Bid %",
                    OneMonth = bidToBidData.OneMonth.ToString("0.##"),
                    ThreeMonth = bidToBidData.ThreeMonth.ToString("0.##"),
                    SixMonth = bidToBidData.SixMonth.ToString("0.##"),
                    OneYear = bidToBidData.OneYear.ToString("0.##"),
                    SinceInception = bidToBidData.SinceInception.ToString("0.##"),
                    YearToDate = bidToBidData.Ytd.ToString("0.##")
                };
                var offerToBidData = await AzureDb.GlobalOfferToBid.Where(pob => pob.Date == Date).FirstAsync();
                var offerToBid = new PerformanceTableColumnDto() {
                    Name = "Offer to Bid %",
                    OneMonth = offerToBidData.OneMonth.ToString("0.##"),
                    ThreeMonth = offerToBidData.ThreeMonth.ToString("0.##"),
                    SixMonth = offerToBidData.SixMonth.ToString("0.##"),
                    OneYear = offerToBidData.OneYear.ToString("0.##"),
                    SinceInception = offerToBidData.SinceInception.ToString("0.##"),
                    YearToDate = offerToBidData.Ytd.ToString("0.##")
                };
                var djBenchMarkData = await AzureDb.DowJonesBidToBid.Where(sbb => sbb.Date == Date).FirstAsync();
                var djBenchMark = new PerformanceTableColumnDto() {
                    Name = $"{djBenchMarkData.Name} %",
                    OneMonth = djBenchMarkData.OneMonth.ToString("0.##"),
                    ThreeMonth = djBenchMarkData.ThreeMonth.ToString("0.##"),
                    SixMonth = djBenchMarkData.SixMonth.ToString("0.##"),
                    OneYear = djBenchMarkData.OneYear.ToString("0.##"),
                    SinceInception = djBenchMarkData.SinceInception.ToString("0.##"),
                    YearToDate = djBenchMarkData.Ytd.ToString("0.##")
                };
                var nqBenchMarkData = await AzureDb.NasdaqBidToBid.Where(sbb => sbb.Date == Date).FirstAsync();
                var nqBenchMark = new PerformanceTableColumnDto() {
                    Name = $"{nqBenchMarkData.Name} %",
                    OneMonth = nqBenchMarkData.OneMonth.ToString("0.##"),
                    ThreeMonth = nqBenchMarkData.ThreeMonth.ToString("0.##"),
                    SixMonth = nqBenchMarkData.SixMonth.ToString("0.##"),
                    OneYear = nqBenchMarkData.OneYear.ToString("0.##"),
                    SinceInception = nqBenchMarkData.SinceInception.ToString("0.##"),
                    YearToDate = nqBenchMarkData.Ytd.ToString("0.##")
                };

                performanceTable.Performances.Add(bidToBid);
                performanceTable.Performances.Add(offerToBid);
                performanceTable.Performances.Add(djBenchMark);
                performanceTable.Performances.Add(nqBenchMark);
            }

            return performanceTable;
        }
    }
}
