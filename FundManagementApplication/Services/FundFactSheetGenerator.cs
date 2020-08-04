using FundManagementApplication.DataAccess;
using FundManagementApplication.Models;
using FundManagementApplication.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundManagementApplication.Services {
    public class FundFactSheetGenerator {

        public FundFactSheetGenerator() {

        }

        public async Task<FundFactSheetDto> GenerateFactSheet(AzureDbContext azureDb, string fund, string date) {

            FundFactSheetDto fundFactSheetModel = new FundFactSheetDto();

            //Retrieve information in database according to given date.
            fundFactSheetModel.Holdings = await RetrieveHoldingsData(azureDb.SharesWeightage, fund);
            fundFactSheetModel.Sectors = await RetrieveSectorData(azureDb.StocksOverview, fund);

            return fundFactSheetModel;
        }

        private async Task<IEnumerable<HoldingsDto>> RetrieveHoldingsData(DbSet<SharesWeightage> sharesWeightage, string fund) {

            //Retrieve data from database
            var weightages = await sharesWeightage.AsNoTracking()
                                                  .Where(sw => sw.SharesWeightageFundId == fund)
                                                  .ToListAsync();

            //Sum total weight with retrieved list
            var totalWeight = weightages.Select(sw => sw.SharesWeightageWeight)
                                        .Sum();

            //Sort them by weight in descending order and convert weight into percentage
            return weightages.OrderByDescending(sw => sw.SharesWeightageWeight)
                             .ConvertToPercentage(totalWeight)
                             .TurnIntoHoldingsDto();
        }

        private async Task<IEnumerable<SectorDto>> RetrieveSectorData(DbSet<StocksOverview> stocksOverviews, string fund) {

            //Retrieve data from database
            var industryList = await stocksOverviews.AsNoTracking()
                                                    .Where(so => so.StocksOverviewFundId == fund)
                                                    .ToListAsync();

            //Sort and convert industry into percentage
            return industryList.GroupBy(so => so.StocksOverviewIndustry, (key, result) => new SectorDto {
                Name = key,
                Percentage = (result.Count() * 100 / industryList.Count()).ToString("0.##")
            }).OrderByDescending(so => so.Percentage);
        }

        //private async Task<IEnumerable<>>
    }
}
