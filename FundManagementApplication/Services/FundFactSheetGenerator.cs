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

        //private async Task<IEnumerable<>>
    }
}
