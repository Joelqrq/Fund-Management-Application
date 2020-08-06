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
        public string Fund { get; set; }
        public DateTime Date { get; set; }

        public FundFactSheetGenerator(AzureDbContext azureDb) {
            AzureDb = azureDb;
        }

        public async Task<FundFactSheetDto> GenerateFactSheet(string fund, string date) {

            Fund = fund;
            Date = DateTime.Parse(date);

            FundFactSheetDto fundFactSheetModel = new FundFactSheetDto();

            //Retrieve information in database according to given date.
            fundFactSheetModel.Holdings = await RetrieveHoldingsData();
            fundFactSheetModel.Sectors = await RetrieveSectorData();
            fundFactSheetModel.PerformanceCharts = await RetrievePerformanceChartData();

            return fundFactSheetModel;
        }

        private async Task<IEnumerable<HoldingsDto>> RetrieveHoldingsData() {

            //Retrieve data from database
            var weightages = await AzureDb.Shares_Weightage.AsNoTracking()
                                                  .Where(sw => sw.Shares_Weightage_Fund_ID == Fund)
                                                  .ToListAsync();

            //Sum total weight with retrieved list
            var totalWeight = weightages.Select(sw => sw.Shares_Weightage_Weight)
                                        .Sum();

            //Sort them by weight in descending order and convert weight into percentage
            return weightages.OrderByDescending(sw => sw.Shares_Weightage_Weight)
                             .ConvertToPercentage(totalWeight)
                             .TurnIntoHoldingsDto();
        }

        private async Task<IEnumerable<SectorDto>> RetrieveSectorData() {

            //Retrieve data from database
            var industryList = await AzureDb.Stocks_Overview.AsNoTracking()
                                                    .Where(so => so.Stocks_Overview_Fund_ID == Fund)
                                                    .ToListAsync();

            //Sort and convert industry into percentage
            return industryList.GroupBy(so => so.Stocks_Overview_Industry, (key, result) => new SectorDto {
                Name = key,
                Percentage = (result.Count() * 100 / industryList.Count()).ToString("0.##")
            }).OrderByDescending(so => so.Percentage);
        }

        private async Task<PerformanceChartDto> RetrievePerformanceChartData() {

            PerformanceChartDto chartDto = null;

            DateTime yearBegin = new DateTime(DateTime.Today.Year, 1, 1);

            if(Fund == "PRES_01") {
               
                var chartData = await AzureDb.Prestige_Performance_Chart.Where(ppc => ppc.Date >= yearBegin && ppc.Date <= Date).ToListAsync();

                chartDto.Date = new List<string>();
                var data1 = new PerformanceDto(); 
                var data2 = new PerformanceDto();

                data1.Name = await AzureDb.Funds.Where(f => f.PK_Fund_ID == Fund).Select(f => f.FundName).SingleAsync();
                data2.Name = await AzureDb.STI_BidToBid.Select(pbb => pbb.Name).SingleAsync();

                foreach(var cd in chartData) {
                    chartDto.Date.Add(cd.Date.ToString());
                    data1.CumulativeReturns.Add(cd.PrestigeCR);
                    data2.CumulativeReturns.Add(cd.STICR);
                }
                chartDto.Performances.Add(data1);
                chartDto.Performances.Add(data2);
            }
            else if(Fund == "GLOB_01") {
               
                var chartData = await AzureDb.Global_Performance_Chart.Where(gpc => gpc.Date >= yearBegin && gpc.Date <= Date).ToListAsync();

                chartDto.Date = new List<string>();
                var data1 = new PerformanceDto();
                var data2 = new PerformanceDto();
                var data3 = new PerformanceDto();

                data1.Name = await AzureDb.Funds.Where(f => f.PK_Fund_ID == Fund).Select(f => f.FundName).SingleAsync();
                data2.Name = await AzureDb.Nasdaq_BidToBid.Select(nbb => nbb.Name).SingleAsync();
                data3.Name = await AzureDb.DowJones_BidToBid.Select(dbb => dbb.Name).SingleAsync();

                foreach(var cd in chartData) {
                    chartDto.Date.Add(cd.Date.ToString());
                    data1.CumulativeReturns.Add(cd.GlobalCR);
                    data2.CumulativeReturns.Add(cd.NasdaqCR);
                    data3.CumulativeReturns.Add(cd.DowJonesCR);
                }
                chartDto.Performances.Add(data1);
                chartDto.Performances.Add(data2);
                chartDto.Performances.Add(data3);
            }
            else return null;

            return chartDto;
        }
    }
}
