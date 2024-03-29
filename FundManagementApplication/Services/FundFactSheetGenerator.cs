﻿using FundManagementApplication.DataAccess;
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
        public string Currency { get; set; }
        public DateTime Date { get; set; }

        public FundFactSheetGenerator(AzureDbContext azureDb) {
            AzureDb = azureDb;
        }

        public async Task<FundFactSheetDto> GenerateFactSheet(string fundManagerId, string fundId, string date) {

            FundManagerId = fundManagerId;
            DateTime yearBegin = new DateTime(DateTime.Today.Year, 1, 1);
            Date = DateTime.Parse(date);

            //Retrieve information in database according to given date. (FundManager, Funds, Stocks)
            var fm = await AzureDb.FundManager.AsNoTracking().Where(fm => fm.PkFundManagerId == fundManagerId).FirstAsync();
            var fund = await AzureDb.Funds.Where(f => f.PkFundId == fundId).FirstAsync();
            Currency = fund.Currency;
            var stocks = await AzureDb.Stock.Where(s => s.FundId == fundId && s.Date >= yearBegin && s.Date <= Date).ToListAsync();
            var latestStocksData = stocks.Except(stocks.Where(s => s.Name == "STI" || s.Name == "DowsJones" || s.Name == "Nasdaq"))
                                         .GroupBy(s => s.Ticker)
                                         .Select(g => g.OrderByDescending(s => s.Date).First());

            var fundFactSheet = new FundFactSheetDto();

            fundFactSheet.FundProfile = fund.FundProfile;
            fundFactSheet.Holdings = RetrieveHoldingsData(latestStocksData);
            fundFactSheet.Sectors = RetrieveSectorData(latestStocksData);
            fundFactSheet.PerformanceCharts = await RetrievePerformanceChartData(fund.FundName);
            fundFactSheet.FundDetails = await RetrieveFundDetailsData(fm, fund, latestStocksData);
            fundFactSheet.PerformanceTable = await RetrievePerformanceTableData();
            return fundFactSheet;
        }

        private IEnumerable<HoldingsDto> RetrieveHoldingsData(IEnumerable<Stock> stocks) {

            decimal totalWeight = 0m;
            foreach(var stock in stocks) {
                totalWeight += stock.Weight;
            }

            //Sort them by weight in descending order and convert weight into percentage
            return stocks.OrderByDescending(s => s.Weight)
                                 .Take(10)
                                 .ConvertToPercentage(totalWeight)
                                 .TurnIntoHoldingsDto();
        }

        private IEnumerable<SectorDto> RetrieveSectorData(IEnumerable<Stock> stocks) {

            var stocksCount = stocks.Count();

            //Sort and convert industry into percentage
            return stocks.GroupBy(s => s.Industry, (key, result) => new SectorDto {
                Name = key,
                Percentage = (result.Count() * 100 / stocksCount).ToString()
            }).OrderByDescending(s => s.Percentage);
        }

        private async Task<PerformanceChartDto> RetrievePerformanceChartData(string fundName) {

            DateTime yearBegin = new DateTime(Date.Year, 1, 1);

            PerformanceChartDto chartDto = new PerformanceChartDto();

            if(Currency == "SGD") {

                var chartData = await AzureDb.PrestigePerformanceChart.Where(ppc => ppc.Date >= yearBegin && ppc.Date <= Date).ToListAsync();

                chartDto.Date = new List<DateTime>();
                var data1 = new PerformanceDto();
                var data2 = new PerformanceDto();

                data1.Name = fundName;
                data2.Name = await AzureDb.StiBidToBid.Select(pbb => pbb.Name).FirstAsync();
                data1.CumulativeReturns = new List<string>();
                data2.CumulativeReturns = new List<string>();

                foreach(var cd in chartData) {
                    chartDto.Date.Add(cd.Date);
                    data1.CumulativeReturns.Add(cd.PrestigeCr.ToString());
                    data2.CumulativeReturns.Add(cd.Sticr.ToString());
                }

                chartDto.Performances = new List<PerformanceDto>();
                chartDto.Performances.Add(data1);
                chartDto.Performances.Add(data2);
            }
            else if(Currency == "USD") {

                var chartData = await AzureDb.GlobalPerformanceChart.Where(gpc => gpc.Date >= yearBegin && gpc.Date <= Date).ToListAsync();

                chartDto.Date = new List<DateTime>();
                var data1 = new PerformanceDto();
                var data2 = new PerformanceDto();
                var data3 = new PerformanceDto();

                data1.Name = fundName;
                data2.Name = await AzureDb.NasdaqBidToBid.Select(nbb => nbb.Name).FirstAsync();
                data3.Name = await AzureDb.DowJonesBidToBid.Select(dbb => dbb.Name).FirstAsync();
                data1.CumulativeReturns = new List<string>();
                data2.CumulativeReturns = new List<string>();
                data3.CumulativeReturns = new List<string>();

                foreach (var cd in chartData) {
                    chartDto.Date.Add(cd.Date);
                    data1.CumulativeReturns.Add(cd.GlobalCr.ToString());
                    data2.CumulativeReturns.Add(cd.NasdaqCr.ToString());
                    data3.CumulativeReturns.Add(cd.DowJonesCr.ToString());
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
                InitialFee = fund.FundFee.ToString("P"),
                InceptionDate = fund.InceptionDate,
                FundManagerName = fm.FundManagerName,
                StockCurrency = stocks.Select(s => s.Currency).First(),
                FundName = fund.FundName,
                TotalHoldings = stocks.Count()
            };

            if(Currency == "SGD") {
                var details = await AzureDb.PrestigeBidToBid.OrderByDescending(b => b.Date).FirstAsync();
                fundDetails.FundSize = details.Price.ToString("C");
                fundDetails.AnnualizeReturns = details.SinceInception.ToString("P");
                fundDetails.BenchmarkNames = new List<string>() {
                    AzureDb.StiBidToBid.Select(sti => sti.Name).First()
                };
            }
            else if(Currency == "USD") {
                var details = await AzureDb.GlobalBidToBid.OrderByDescending(b => b.Date).FirstAsync();
                fundDetails.FundSize = details.Price.ToString("C");
                fundDetails.AnnualizeReturns = details.SinceInception.ToString("P");
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

            if(Currency == "SGD") {
                var bidToBidData = await AzureDb.PrestigeBidToBid.OrderByDescending(b => b.Date).FirstAsync();
                var bidToBid = new PerformanceTableColumnDto() {
                    Name = "Bid to Bid %",
                    OneMonth = bidToBidData.OneMonth.ToString("P"),
                    ThreeMonth = bidToBidData.ThreeMonth.ToString("P"),
                    SixMonth = bidToBidData.SixMonth.ToString("P"),
                    OneYear = bidToBidData.OneYear.ToString("P"),
                    SinceInception = bidToBidData.SinceInception.ToString("P"),
                    YearToDate = bidToBidData.Ytd.ToString("P")
                };
                var offerToBidData = await AzureDb.PrestigeOfferToBid.OrderByDescending(b => b.Date).FirstAsync();
                var offerToBid = new PerformanceTableColumnDto() {
                    Name = "Offer to Bid %",
                    OneMonth = offerToBidData.OneMonth.ToString("P"),
                    ThreeMonth = offerToBidData.ThreeMonth.ToString("P"),
                    SixMonth = offerToBidData.SixMonth.ToString("P"),
                    OneYear = offerToBidData.OneYear.ToString("P"),
                    SinceInception = offerToBidData.SinceInception.ToString("P"),
                    YearToDate = offerToBidData.Ytd.ToString("P")
                };
                var benchMarkData = await AzureDb.StiBidToBid.OrderByDescending(b => b.Date).FirstAsync();
                var benchMark = new PerformanceTableColumnDto() {
                    Name = $"{benchMarkData.Name} %",
                    OneMonth = benchMarkData.OneMonth.ToString("P"),
                    ThreeMonth = benchMarkData.ThreeMonth.ToString("P"),
                    SixMonth = benchMarkData.SixMonth.ToString("P"),
                    OneYear = benchMarkData.OneYear.ToString("P"),
                    SinceInception = benchMarkData.SinceInception.ToString("P"),
                    YearToDate = benchMarkData.Ytd.ToString("P")
                };

                performanceTable.Performances.Add(bidToBid);
                performanceTable.Performances.Add(offerToBid);
                performanceTable.Performances.Add(benchMark);
            }
            else if(Currency == "USD") {
                var bidToBidData = await AzureDb.GlobalBidToBid.OrderByDescending(b => b.Date).FirstAsync();
                var bidToBid = new PerformanceTableColumnDto() {
                    Name = "Bid to Bid %",
                    OneMonth = bidToBidData.OneMonth.ToString("P"),
                    ThreeMonth = bidToBidData.ThreeMonth.ToString("P"),
                    SixMonth = bidToBidData.SixMonth.ToString("P"),
                    OneYear = bidToBidData.OneYear.ToString("P"),
                    SinceInception = bidToBidData.SinceInception.ToString("P"),
                    YearToDate = bidToBidData.Ytd.ToString("P")
                };
                var offerToBidData = await AzureDb.GlobalOfferToBid.OrderByDescending(b => b.Date).FirstAsync();
                var offerToBid = new PerformanceTableColumnDto() {
                    Name = "Offer to Bid %",
                    OneMonth = offerToBidData.OneMonth.ToString("P"),
                    ThreeMonth = offerToBidData.ThreeMonth.ToString("P"),
                    SixMonth = offerToBidData.SixMonth.ToString("P"),
                    OneYear = offerToBidData.OneYear.ToString("P"),
                    SinceInception = offerToBidData.SinceInception.ToString("P"),
                    YearToDate = offerToBidData.Ytd.ToString("P")
                };
                var djBenchMarkData = await AzureDb.DowJonesBidToBid.OrderByDescending(b => b.Date).FirstAsync();
                var djBenchMark = new PerformanceTableColumnDto() {
                    Name = $"{djBenchMarkData.Name} %",
                    OneMonth = djBenchMarkData.OneMonth.ToString("P"),
                    ThreeMonth = djBenchMarkData.ThreeMonth.ToString("P"),
                    SixMonth = djBenchMarkData.SixMonth.ToString("P"),
                    OneYear = djBenchMarkData.OneYear.ToString("P"),
                    SinceInception = djBenchMarkData.SinceInception.ToString("P"),
                    YearToDate = djBenchMarkData.Ytd.ToString("P")
                };
                var nqBenchMarkData = await AzureDb.NasdaqBidToBid.OrderByDescending(b => b.Date).FirstAsync();
                var nqBenchMark = new PerformanceTableColumnDto() {
                    Name = $"{nqBenchMarkData.Name} %",
                    OneMonth = nqBenchMarkData.OneMonth.ToString("P"),
                    ThreeMonth = nqBenchMarkData.ThreeMonth.ToString("P"),
                    SixMonth = nqBenchMarkData.SixMonth.ToString("P"),
                    OneYear = nqBenchMarkData.OneYear.ToString("P"),
                    SinceInception = nqBenchMarkData.SinceInception.ToString("P"),
                    YearToDate = nqBenchMarkData.Ytd.ToString("P")
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
